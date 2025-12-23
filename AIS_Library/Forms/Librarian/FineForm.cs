using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;
using AIS_Library.Database;

namespace AIS_Library.Forms.Librarian
{
    public partial class FineForm : Form
    {
        private int _lendingId;
        private int _daysOverdue;

        public int SelectedArticleId { get; private set; }
        public bool WasPaid { get; private set; }


        // КОНСТРУКТОР 1: АВТОМАТИЧЕСКАЯ ПРОСРОЧКА (int, int)

        public FineForm(int lendingId, int daysOverdue)
        {
            InitializeComponent();
            _lendingId = lendingId;
            _daysOverdue = daysOverdue;

            LoadArticles();

            this.Text = "Штраф: Просрочка возврата";

            // Выбираем статью "Просрочка" (ID = 1) и блокируем
            SetFixedArticle(1);
        }

        // КОНСТРУКТОР 2: ФИКСИРОВАННАЯ СТАТЬЯ (Утеря/Порча)
        // Добавили "bool isFixedMode", чтобы отличаться от первого конструктора!

        public FineForm(int lendingId, int fixedArticleId, bool isFixedMode)
        {
            InitializeComponent();
            _lendingId = lendingId;
            _daysOverdue = 0;

            LoadArticles();

            // Жестко выбираем статью
            SetFixedArticle(fixedArticleId);

            if (fixedArticleId == 3) this.Text = "Штраф: Утеря книги";
            else if (fixedArticleId == 2) this.Text = "Штраф: Порча книги";
        }


        // КОНСТРУКТОР 3: РУЧНОЙ РЕЖИМ (int)
     
        public FineForm(int lendingId)
        {
            InitializeComponent();
            _lendingId = lendingId;
            _daysOverdue = 0;
            LoadArticles();
            this.Text = "Оформление штрафа";
        }

        private void LoadArticles()
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                var da = new NpgsqlDataAdapter("SELECT article_id, name, base_amount FROM fine_articles ORDER BY article_id", conn);
                var dt = new DataTable();
                da.Fill(dt);

                cboArticles.DisplayMember = "name";
                cboArticles.ValueMember = "article_id";
                cboArticles.DataSource = dt;
            }
        }

        private void SetFixedArticle(int articleId)
        {
            cboArticles.SelectedValue = articleId;
            cboArticles.Enabled = false; // Блокируем выбор
        }

        private void cboArticles_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Защита от сбоев
            if (cboArticles.SelectedItem == null || cboArticles.SelectedValue == null) return;

            // Получаем ID выбранной статьи
            // (DataRowView нужно, если привязка через DataSource, иначе просто берем SelectedValue)
            int articleId;
            if (int.TryParse(cboArticles.SelectedValue.ToString(), out articleId))
            {
                using (var conn = DbHelper.GetConnection())
                {
                    conn.Open();
                    try
                    {
                        // Вызываем функцию расчета
                        using (var cmd = new NpgsqlCommand("SELECT fn_calculate_fine_amount(@lid, @aid, @days)", conn))
                        {
                            cmd.Parameters.AddWithValue("lid", _lendingId);
                            cmd.Parameters.AddWithValue("aid", articleId);
                            cmd.Parameters.AddWithValue("days", _daysOverdue); // Если просрочки нет, здесь 0

                            object result = cmd.ExecuteScalar();

                            if (result != null && result != DBNull.Value)
                            {
                                nudAmount.Value = Convert.ToDecimal(result);
                            }
                            else
                            {
                                nudAmount.Value = 0;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    
                        nudAmount.Value = 0;
                    }
                }


                // 2. НАСТРАИВАЕМ БЛОКИРОВКУ ПОЛЯ
                // Получаем строку данных, чтобы проверить, что это за статья
                DataRowView row = (DataRowView)cboArticles.SelectedItem;

                // Сценарий А: УТЕРЯ КНИГИ (base_amount в БД равен NULL)
                if (row["base_amount"] == DBNull.Value)
                {
                    // Сумма равна цене книги, менять нельзя!
                    nudAmount.Enabled = false;
                }
                // Сценарий Б: ПРОСРОЧКА (ID = 1)
                else if (articleId == 1)
                {
                    // Сумма посчитана по дням, менять нельзя!
                    nudAmount.Enabled = false;
                }
                // Сценарий В: ПОРЧА (или другие штрафы)
                else
                {
                    // Тут разрешаем менять, так как ущерб может быть частичным
                    nudAmount.Enabled = true;
                }



            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Валидация
            if (cboArticles.SelectedIndex < 0)
            {
                MessageBox.Show("Выберите статью штрафа!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Получаем данные для вопроса
            decimal finalAmount = nudAmount.Value;
            string articleName = cboArticles.Text; // Название нарушения

            // 3. ПОДТВЕРЖДЕНИЕ (Новый блок)
            // Показываем сумму и причину, чтобы библиотекарь точно знал, что делает
            if (MessageBox.Show($"Вы действительно хотите оформить штраф?\n\nНарушение: {articleName}\nСумма к оплате: {finalAmount:C2}",
                "Подтверждение штрафа", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                this.DialogResult = DialogResult.None; // Остаемся на форме
                return;
            }

            // 4. Подготовка данных для сохранения
            SelectedArticleId = Convert.ToInt32(cboArticles.SelectedValue);
            WasPaid = chkIsPaid.Checked;

            // Формируем комментарий
            string systemNote = _daysOverdue > 0 ? $"[Просрочка: {_daysOverdue} дн.] " : "";
            string userNote = txtComment.Text.Trim();
            string finalComment = (systemNote + userNote).Trim();

            // 5. Сохранение в БД
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                try
                {
                    // Вызываем процедуру
                    string query = "CALL sp_create_fine(@lid, @aid, @amount, @paid, @comment, @days)";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("lid", _lendingId);
                        cmd.Parameters.AddWithValue("aid", SelectedArticleId);

                        // Передаем сумму (важно для фиксации цены)
                        cmd.Parameters.AddWithValue("amount", finalAmount);

                        cmd.Parameters.AddWithValue("paid", WasPaid);
                        cmd.Parameters.AddWithValue("comment", finalComment);

                        // Передаем дни просрочки (для внутренней логики процедуры)
                        cmd.Parameters.AddWithValue("days", _daysOverdue);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Штраф успешно оформлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при сохранении: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None; // Не закрываем форму при ошибке
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
