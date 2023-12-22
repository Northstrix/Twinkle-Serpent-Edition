namespace Twinkle_Serpent_Edition
{
    partial class Form1
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
            richTextBox1 = new RichTextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openDocumentToolStripMenuItem = new ToolStripMenuItem();
            openEncryptedDocumentToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            saveEncryptedDocumentAsToolStripMenuItem = new ToolStripMenuItem();
            generateKeyToolStripMenuItem = new ToolStripMenuItem();
            selectKeyToolStripMenuItem = new ToolStripMenuItem();
            quitToolStripMenuItem = new ToolStripMenuItem();
            fontToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            clearToolStripMenuItem = new ToolStripMenuItem();
            tableLayoutPanel1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.FromArgb(32, 32, 32);
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.Dock = DockStyle.Fill;
            richTextBox1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            richTextBox1.ForeColor = Color.FromArgb(238, 238, 238);
            richTextBox1.Location = new Point(203, 3);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(394, 420);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.FromArgb(16, 16, 16);
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(richTextBox1, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.ForeColor = Color.FromArgb(238, 238, 238);
            tableLayoutPanel1.Location = new Point(0, 24);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(800, 426);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(48, 48, 48);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, fontToolStripMenuItem, clearToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openDocumentToolStripMenuItem, openEncryptedDocumentToolStripMenuItem, saveAsToolStripMenuItem, saveEncryptedDocumentAsToolStripMenuItem, generateKeyToolStripMenuItem, selectKeyToolStripMenuItem, quitToolStripMenuItem });
            fileToolStripMenuItem.ForeColor = Color.FromArgb(238, 238, 238);
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // openDocumentToolStripMenuItem
            // 
            openDocumentToolStripMenuItem.Name = "openDocumentToolStripMenuItem";
            openDocumentToolStripMenuItem.Size = new Size(238, 22);
            openDocumentToolStripMenuItem.Text = "Open Text Document";
            openDocumentToolStripMenuItem.Click += openDocumentToolStripMenuItem_Click_1;
            // 
            // openEncryptedDocumentToolStripMenuItem
            // 
            openEncryptedDocumentToolStripMenuItem.Name = "openEncryptedDocumentToolStripMenuItem";
            openEncryptedDocumentToolStripMenuItem.Size = new Size(238, 22);
            openEncryptedDocumentToolStripMenuItem.Text = "Open Encrypted Document";
            openEncryptedDocumentToolStripMenuItem.Click += openEncryptedDocumentToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(238, 22);
            saveAsToolStripMenuItem.Text = "Save Text Document As...";
            saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
            // 
            // saveEncryptedDocumentAsToolStripMenuItem
            // 
            saveEncryptedDocumentAsToolStripMenuItem.Name = "saveEncryptedDocumentAsToolStripMenuItem";
            saveEncryptedDocumentAsToolStripMenuItem.Size = new Size(238, 22);
            saveEncryptedDocumentAsToolStripMenuItem.Text = "Save Encrypted Document As...";
            saveEncryptedDocumentAsToolStripMenuItem.Click += saveEncryptedDocumentAsToolStripMenuItem_Click;
            // 
            // generateKeyToolStripMenuItem
            // 
            generateKeyToolStripMenuItem.Name = "generateKeyToolStripMenuItem";
            generateKeyToolStripMenuItem.Size = new Size(238, 22);
            generateKeyToolStripMenuItem.Text = "Generate Key";
            generateKeyToolStripMenuItem.Click += generateKeyToolStripMenuItem_Click;
            // 
            // selectKeyToolStripMenuItem
            // 
            selectKeyToolStripMenuItem.Name = "selectKeyToolStripMenuItem";
            selectKeyToolStripMenuItem.Size = new Size(238, 22);
            selectKeyToolStripMenuItem.Text = "Select Key";
            selectKeyToolStripMenuItem.Click += selectKeyToolStripMenuItem_Click;
            // 
            // quitToolStripMenuItem
            // 
            quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            quitToolStripMenuItem.Size = new Size(238, 22);
            quitToolStripMenuItem.Text = "Quit";
            quitToolStripMenuItem.Click += quitToolStripMenuItem_Click;
            // 
            // fontToolStripMenuItem
            // 
            fontToolStripMenuItem.ForeColor = Color.FromArgb(238, 238, 238);
            fontToolStripMenuItem.Name = "fontToolStripMenuItem";
            fontToolStripMenuItem.Size = new Size(43, 20);
            fontToolStripMenuItem.Text = "Font";
            fontToolStripMenuItem.Click += fontToolStripMenuItem_Click;
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 24);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 426);
            panel1.TabIndex = 1;
            // 
            // clearToolStripMenuItem
            // 
            clearToolStripMenuItem.ForeColor = Color.FromArgb(238, 238, 238);
            clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            clearToolStripMenuItem.Size = new Size(46, 20);
            clearToolStripMenuItem.Text = "Clear";
            clearToolStripMenuItem.Click += clearToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(18, 18, 18);
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Twinkle Serpent Edition";
            Load += Form1_Load;
            tableLayoutPanel1.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox richTextBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private Panel panel1;
        private ToolStripMenuItem openDocumentToolStripMenuItem;
        private ToolStripMenuItem openEncryptedDocumentToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripMenuItem saveEncryptedDocumentAsToolStripMenuItem;
        private ToolStripMenuItem generateKeyToolStripMenuItem;
        private ToolStripMenuItem selectKeyToolStripMenuItem;
        private ToolStripMenuItem quitToolStripMenuItem;
        private ToolStripMenuItem fontToolStripMenuItem;
        private ToolStripMenuItem clearToolStripMenuItem;
    }
}