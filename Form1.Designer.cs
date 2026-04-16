namespace FileCompare
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
            panel1 = new Panel();
            lvFilesLeft = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            btnCopyToRight = new Button();
            btnSelectRight = new Button();
            txtPathRight = new TextBox();
            lblTitle = new Label();
            btnSelectLeft = new Button();
            txtPathLeft = new TextBox();
            btnCopyToLeft = new Button();
            splitContainer1 = new SplitContainer();
            panel4 = new Panel();
            panel3 = new Panel();
            panel7 = new Panel();
            lvFilesRight = new ListView();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            panel6 = new Panel();
            panel2 = new Panel();
            panel5 = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(lvFilesLeft);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 126);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(5);
            panel1.Size = new Size(344, 289);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // lvFilesLeft
            // 
            lvFilesLeft.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            lvFilesLeft.Dock = DockStyle.Fill;
            lvFilesLeft.FullRowSelect = true;
            lvFilesLeft.GridLines = true;
            lvFilesLeft.Location = new Point(5, 5);
            lvFilesLeft.Margin = new Padding(2);
            lvFilesLeft.Name = "lvFilesLeft";
            lvFilesLeft.Size = new Size(334, 279);
            lvFilesLeft.TabIndex = 9;
            lvFilesLeft.UseCompatibleStateImageBehavior = false;
            lvFilesLeft.View = View.Details;
            lvFilesLeft.SelectedIndexChanged += lvFilesLeft_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "이름";
            columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "크기";
            columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "수정";
            columnHeader3.Width = 150;
            // 
            // btnCopyToRight
            // 
            btnCopyToRight.Anchor = AnchorStyles.Top;
            btnCopyToRight.Location = new Point(260, 50);
            btnCopyToRight.Margin = new Padding(2);
            btnCopyToRight.Name = "btnCopyToRight";
            btnCopyToRight.Size = new Size(82, 22);
            btnCopyToRight.TabIndex = 6;
            btnCopyToRight.Text = ">>>";
            btnCopyToRight.UseVisualStyleBackColor = true;
            btnCopyToRight.Click += button5_Click;
            // 
            // btnSelectRight
            // 
            btnSelectRight.Anchor = AnchorStyles.Right;
            btnSelectRight.Location = new Point(319, 10);
            btnSelectRight.Margin = new Padding(2);
            btnSelectRight.Name = "btnSelectRight";
            btnSelectRight.Size = new Size(81, 22);
            btnSelectRight.TabIndex = 2;
            btnSelectRight.Text = "폴더선택";
            btnSelectRight.UseVisualStyleBackColor = true;
            btnSelectRight.Click += button1_Click;
            // 
            // txtPathRight
            // 
            txtPathRight.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtPathRight.Location = new Point(10, 9);
            txtPathRight.Margin = new Padding(2);
            txtPathRight.Multiline = true;
            txtPathRight.Name = "txtPathRight";
            txtPathRight.Size = new Size(305, 23);
            txtPathRight.TabIndex = 1;
            txtPathRight.TextChanged += textBox1_TextChanged;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Georgia", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.Green;
            lblTitle.Location = new Point(2, 4);
            lblTitle.Margin = new Padding(2, 0, 2, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(251, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "FileCompare";
            lblTitle.Click += label1_Click;
            // 
            // btnSelectLeft
            // 
            btnSelectLeft.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSelectLeft.Location = new Point(263, 8);
            btnSelectLeft.Margin = new Padding(2);
            btnSelectLeft.Name = "btnSelectLeft";
            btnSelectLeft.Size = new Size(87, 22);
            btnSelectLeft.TabIndex = 5;
            btnSelectLeft.Text = "폴더선택";
            btnSelectLeft.UseVisualStyleBackColor = true;
            btnSelectLeft.Click += button2_Click;
            // 
            // txtPathLeft
            // 
            txtPathLeft.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPathLeft.Location = new Point(7, 7);
            txtPathLeft.Margin = new Padding(2);
            txtPathLeft.Name = "txtPathLeft";
            txtPathLeft.Size = new Size(262, 23);
            txtPathLeft.TabIndex = 2;
            // 
            // btnCopyToLeft
            // 
            btnCopyToLeft.Anchor = AnchorStyles.Top;
            btnCopyToLeft.Location = new Point(14, 50);
            btnCopyToLeft.Margin = new Padding(2);
            btnCopyToLeft.Name = "btnCopyToLeft";
            btnCopyToLeft.Size = new Size(70, 22);
            btnCopyToLeft.TabIndex = 4;
            btnCopyToLeft.Text = "<<<";
            btnCopyToLeft.UseVisualStyleBackColor = true;
            btnCopyToLeft.Click += button3_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.BorderStyle = BorderStyle.FixedSingle;
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Margin = new Padding(2);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panel4);
            splitContainer1.Panel1.Controls.Add(panel1);
            splitContainer1.Panel1.Controls.Add(panel3);
            splitContainer1.Panel1.Paint += splitContainer1_Panel1_Paint_2;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panel7);
            splitContainer1.Panel2.Controls.Add(panel6);
            splitContainer1.Panel2.Controls.Add(panel2);
            splitContainer1.Panel2.Paint += splitContainer1_Panel2_Paint_1;
            splitContainer1.Size = new Size(753, 417);
            splitContainer1.SplitterDistance = 346;
            splitContainer1.SplitterWidth = 10;
            splitContainer1.TabIndex = 8;
            // 
            // panel4
            // 
            panel4.Controls.Add(btnSelectLeft);
            panel4.Controls.Add(txtPathLeft);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 78);
            panel4.Margin = new Padding(2);
            panel4.Name = "panel4";
            panel4.Size = new Size(344, 44);
            panel4.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Controls.Add(lblTitle);
            panel3.Controls.Add(btnCopyToRight);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Margin = new Padding(2);
            panel3.Name = "panel3";
            panel3.Size = new Size(344, 78);
            panel3.TabIndex = 0;
            // 
            // panel7
            // 
            panel7.Controls.Add(lvFilesRight);
            panel7.Dock = DockStyle.Bottom;
            panel7.Location = new Point(0, 126);
            panel7.Margin = new Padding(2);
            panel7.Name = "panel7";
            panel7.Padding = new Padding(5);
            panel7.Size = new Size(395, 289);
            panel7.TabIndex = 11;
            // 
            // lvFilesRight
            // 
            lvFilesRight.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            lvFilesRight.Columns.AddRange(new ColumnHeader[] { columnHeader4, columnHeader5, columnHeader6 });
            lvFilesRight.FullRowSelect = true;
            lvFilesRight.GridLines = true;
            lvFilesRight.Location = new Point(255, -38);
            lvFilesRight.Margin = new Padding(2);
            lvFilesRight.Name = "lvFilesRight";
            lvFilesRight.Size = new Size(385, 279);
            lvFilesRight.TabIndex = 10;
            lvFilesRight.UseCompatibleStateImageBehavior = false;
            lvFilesRight.View = View.Details;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "이름";
            columnHeader4.Width = 150;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "크기";
            columnHeader5.Width = 80;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "수정";
            columnHeader6.Width = 150;
            // 
            // panel6
            // 
            panel6.Controls.Add(btnSelectRight);
            panel6.Controls.Add(txtPathRight);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 78);
            panel6.Margin = new Padding(2);
            panel6.Name = "panel6";
            panel6.Size = new Size(395, 44);
            panel6.TabIndex = 10;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(btnCopyToLeft);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Size = new Size(395, 78);
            panel2.TabIndex = 9;
            // 
            // panel5
            // 
            panel5.Location = new Point(2, 76);
            panel5.Margin = new Padding(2);
            panel5.Name = "panel5";
            panel5.Size = new Size(304, 78);
            panel5.TabIndex = 10;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(753, 417);
            Controls.Add(splitContainer1);
            Margin = new Padding(2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel7.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblTitle;
        private Button btnSelectRight;
        private TextBox txtPathRight;
        private TextBox txtPathLeft;
        private Button btnCopyToRight;
        private Button btnCopyToLeft;
        private Button btnSelectLeft;
        private SplitContainer splitContainer1;
        private Panel panel4;
        private Panel panel3;
        private Panel panel2;
        private Panel panel5;
        private Panel panel6;
        private ListView lvFilesLeft;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private Panel panel7;
        private ListView lvFilesRight;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
    }
}
