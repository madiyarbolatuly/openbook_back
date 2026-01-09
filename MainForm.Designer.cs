namespace gq_kp_client
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            ImportToolStripMenuItem = new ToolStripMenuItem();
            ExitStripMenuItem2 = new ToolStripMenuItem();
            panel1 = new Panel();
            btn_search = new Button();
            txb_search = new TextBox();
            dataGridView1 = new DataGridView();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(784, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ImportToolStripMenuItem, ExitStripMenuItem2 });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(48, 20);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // ImportToolStripMenuItem
            // 
            ImportToolStripMenuItem.Name = "ImportToolStripMenuItem";
            ImportToolStripMenuItem.Size = new Size(162, 22);
            ImportToolStripMenuItem.Text = "Импорт данных";
            ImportToolStripMenuItem.Click += ImportToolStripMenuItem_Click;
            // 
            // ExitStripMenuItem2
            // 
            ExitStripMenuItem2.Name = "ExitStripMenuItem2";
            ExitStripMenuItem2.Size = new Size(162, 22);
            ExitStripMenuItem2.Text = "Выход";
            ExitStripMenuItem2.Click += ExitStripMenuItem2_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(btn_search);
            panel1.Controls.Add(txb_search);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 24);
            panel1.Name = "panel1";
            panel1.Size = new Size(784, 50);
            panel1.TabIndex = 1;
            // 
            // btn_search
            // 
            btn_search.Location = new Point(327, 10);
            btn_search.Name = "btn_search";
            btn_search.Size = new Size(70, 30);
            btn_search.TabIndex = 1;
            btn_search.Text = "Найти";
            btn_search.UseVisualStyleBackColor = true;
            btn_search.Click += btn_search_ClickAsync;
            // 
            // txb_search
            // 
            txb_search.Location = new Point(12, 15);
            txb_search.Name = "txb_search";
            txb_search.Size = new Size(300, 23);
            txb_search.TabIndex = 0;
            txb_search.KeyDown += txb_search_KeyDown;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.Location = new Point(0, 74);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(784, 487);
            dataGridView1.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 561);
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "OpenBook v1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private Panel panel1;
        private TextBox txb_search;
        private Button btn_search;
        private DataGridView dataGridView1;
        private ToolStripMenuItem ImportToolStripMenuItem;
        private ToolStripMenuItem ExitStripMenuItem2;
    }
}
