namespace gq_kp_client
{
    partial class ImportForm
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
            textBox1 = new TextBox();
            btn_select = new Button();
            btn_import = new Button();
            btn_cancel = new Button();
            progressBar1 = new ProgressBar();
            openFileDialog1 = new OpenFileDialog();
            label1 = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(18, 39);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(359, 23);
            textBox1.TabIndex = 0;
            // 
            // btn_select
            // 
            btn_select.Location = new Point(392, 33);
            btn_select.Name = "btn_select";
            btn_select.Size = new Size(78, 32);
            btn_select.TabIndex = 1;
            btn_select.Text = "Выбрать";
            btn_select.UseVisualStyleBackColor = true;
            btn_select.Click += btn_select_Click;
            // 
            // btn_import
            // 
            btn_import.Location = new Point(311, 139);
            btn_import.Name = "btn_import";
            btn_import.Size = new Size(72, 32);
            btn_import.TabIndex = 2;
            btn_import.Text = "Импорт";
            btn_import.UseVisualStyleBackColor = true;
            btn_import.Click += btn_import_ClickAsync;
            // 
            // btn_cancel
            // 
            btn_cancel.Location = new Point(398, 139);
            btn_cancel.Name = "btn_cancel";
            btn_cancel.Size = new Size(72, 32);
            btn_cancel.TabIndex = 3;
            btn_cancel.Text = "Отмена";
            btn_cancel.UseVisualStyleBackColor = true;
            btn_cancel.Click += btn_cancel_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(18, 91);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(452, 23);
            progressBar1.TabIndex = 4;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 148);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 5;
            label1.Text = "Статус:";
            // 
            // ImportForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(491, 191);
            Controls.Add(label1);
            Controls.Add(progressBar1);
            Controls.Add(btn_cancel);
            Controls.Add(btn_import);
            Controls.Add(btn_select);
            Controls.Add(textBox1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ImportForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Модуль импорта";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button btn_select;
        private Button btn_import;
        private Button btn_cancel;
        private ProgressBar progressBar1;
        private OpenFileDialog openFileDialog1;
        private Label label1;
    }
}