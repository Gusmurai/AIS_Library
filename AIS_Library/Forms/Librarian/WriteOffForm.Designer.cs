namespace AIS_Library.Forms.Librarian
{
    partial class WriteOffForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblInfo = new Label();
            label2 = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            cmbReason = new ComboBox();
            SuspendLayout();
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblInfo.Location = new Point(34, 29);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(208, 23);
            lblInfo.TabIndex = 0;
            lblInfo.Text = "Списание экземпляра №";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(34, 71);
            label2.Name = "label2";
            label2.Size = new Size(153, 23);
            label2.TabIndex = 1;
            label2.Text = "Укажите причину:";
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSave.DialogResult = DialogResult.OK;
            btnSave.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnSave.Location = new Point(322, 134);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(98, 36);
            btnSave.TabIndex = 3;
            btnSave.Text = "Списать";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnCancel.Location = new Point(217, 134);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(99, 36);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // cmbReason
            // 
            cmbReason.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbReason.FormattingEnabled = true;
            cmbReason.Location = new Point(195, 71);
            cmbReason.Name = "cmbReason";
            cmbReason.Size = new Size(194, 28);
            cmbReason.TabIndex = 5;
            // 
            // WriteOffForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(432, 178);
            Controls.Add(cmbReason);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(label2);
            Controls.Add(lblInfo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "WriteOffForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "WriteOffForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblInfo;
        private Label label2;
        private Button btnSave;
        private Button btnCancel;
        private ComboBox cmbReason;
    }
}