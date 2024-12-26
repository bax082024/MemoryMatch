namespace MemoryMatchV1
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
            tableLayoutPanel1 = new TableLayoutPanel();
            lblTitle = new Label();
            btnStart = new Button();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            lblMoves = new Label();
            menuStrip1 = new MenuStrip();
            themeToolStripMenuItem = new ToolStripMenuItem();
            defaultToolStripMenuItem = new ToolStripMenuItem();
            coolBluesToolStripMenuItem = new ToolStripMenuItem();
            natureGreensToolStripMenuItem = new ToolStripMenuItem();
            elegantPurplesToolStripMenuItem = new ToolStripMenuItem();
            brightFunToolStripMenuItem = new ToolStripMenuItem();
            matrixToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.None;
            tableLayoutPanel1.BackColor = SystemColors.Control;
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Location = new Point(63, 123);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Size = new Size(785, 491);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Ravie", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.OrangeRed;
            lblTitle.Location = new Point(253, 45);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(416, 50);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "Memory Match";
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.OliveDrab;
            btnStart.FlatStyle = FlatStyle.Popup;
            btnStart.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnStart.Location = new Point(394, 615);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(120, 37);
            btnStart.TabIndex = 3;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 677);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(917, 22);
            statusStrip1.TabIndex = 4;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.BackColor = Color.Transparent;
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(74, 17);
            toolStripStatusLabel1.Text = "Bax Creation";
            // 
            // lblMoves
            // 
            lblMoves.AutoSize = true;
            lblMoves.BackColor = Color.Transparent;
            lblMoves.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMoves.ForeColor = Color.Firebrick;
            lblMoves.Location = new Point(419, 102);
            lblMoves.Name = "lblMoves";
            lblMoves.Size = new Size(67, 17);
            lblMoves.TabIndex = 5;
            lblMoves.Text = "Moves : 0";
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.Gray;
            menuStrip1.Items.AddRange(new ToolStripItem[] { themeToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(917, 24);
            menuStrip1.TabIndex = 6;
            menuStrip1.Text = "menuStrip1";
            // 
            // themeToolStripMenuItem
            // 
            themeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { defaultToolStripMenuItem, coolBluesToolStripMenuItem, natureGreensToolStripMenuItem, elegantPurplesToolStripMenuItem, brightFunToolStripMenuItem, matrixToolStripMenuItem });
            themeToolStripMenuItem.Name = "themeToolStripMenuItem";
            themeToolStripMenuItem.Size = new Size(60, 20);
            themeToolStripMenuItem.Text = "Themes";
            // 
            // defaultToolStripMenuItem
            // 
            defaultToolStripMenuItem.Name = "defaultToolStripMenuItem";
            defaultToolStripMenuItem.Size = new Size(155, 22);
            defaultToolStripMenuItem.Text = "Default";
            defaultToolStripMenuItem.Click += Default_Click;
            // 
            // coolBluesToolStripMenuItem
            // 
            coolBluesToolStripMenuItem.Name = "coolBluesToolStripMenuItem";
            coolBluesToolStripMenuItem.Size = new Size(155, 22);
            coolBluesToolStripMenuItem.Text = "Cool Blues";
            coolBluesToolStripMenuItem.Click += CoolBlues_Click;
            // 
            // natureGreensToolStripMenuItem
            // 
            natureGreensToolStripMenuItem.Name = "natureGreensToolStripMenuItem";
            natureGreensToolStripMenuItem.Size = new Size(155, 22);
            natureGreensToolStripMenuItem.Text = "Nature Greens";
            natureGreensToolStripMenuItem.Click += NatureGreens_Click;
            // 
            // elegantPurplesToolStripMenuItem
            // 
            elegantPurplesToolStripMenuItem.Name = "elegantPurplesToolStripMenuItem";
            elegantPurplesToolStripMenuItem.Size = new Size(155, 22);
            elegantPurplesToolStripMenuItem.Text = "Elegant Purples";
            elegantPurplesToolStripMenuItem.Click += ElegantPurples_Click;
            // 
            // brightFunToolStripMenuItem
            // 
            brightFunToolStripMenuItem.Name = "brightFunToolStripMenuItem";
            brightFunToolStripMenuItem.Size = new Size(155, 22);
            brightFunToolStripMenuItem.Text = "Bright Fun";
            brightFunToolStripMenuItem.Click += BrightFun_Click;
            // 
            // matrixToolStripMenuItem
            // 
            matrixToolStripMenuItem.Name = "matrixToolStripMenuItem";
            matrixToolStripMenuItem.Size = new Size(155, 22);
            matrixToolStripMenuItem.Text = "Matrix";
            matrixToolStripMenuItem.Click += Matrix_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(917, 699);
            Controls.Add(lblMoves);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Controls.Add(btnStart);
            Controls.Add(lblTitle);
            Controls.Add(tableLayoutPanel1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Memory Match";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label lblTitle;
        private Button btnStart;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private Label lblMoves;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem themeToolStripMenuItem;
        private ToolStripMenuItem defaultToolStripMenuItem;
        private ToolStripMenuItem coolBluesToolStripMenuItem;
        private ToolStripMenuItem natureGreensToolStripMenuItem;
        private ToolStripMenuItem elegantPurplesToolStripMenuItem;
        private ToolStripMenuItem brightFunToolStripMenuItem;
        private ToolStripMenuItem matrixToolStripMenuItem;
    }
}
