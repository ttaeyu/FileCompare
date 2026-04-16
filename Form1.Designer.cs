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
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            button5 = new Button();
            button1 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            button2 = new Button();
            textBox2 = new TextBox();
            button3 = new Button();
            splitContainer1 = new SplitContainer();
            panel4 = new Panel();
            panel3 = new Panel();
            panel7 = new Panel();
            listView2 = new ListView();
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
            panel1.Controls.Add(listView1);
            panel1.Location = new Point(6, 215);
            panel1.Name = "panel1";
            panel1.Size = new Size(412, 329);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Location = new Point(9, 53);
            listView1.Name = "listView1";
            listView1.Size = new Size(376, 254);
            listView1.TabIndex = 9;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
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
            // button5
            // 
            button5.Location = new Point(299, 67);
            button5.Name = "button5";
            button5.Size = new Size(92, 29);
            button5.TabIndex = 6;
            button5.Text = ">>>";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button1
            // 
            button1.Location = new Point(296, 3);
            button1.Name = "button1";
            button1.Size = new Size(92, 29);
            button1.TabIndex = 2;
            button1.Text = "폴더선택";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(13, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(277, 27);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, 129);
            label1.Location = new Point(3, 6);
            label1.Name = "label1";
            label1.Size = new Size(236, 60);
            label1.TabIndex = 0;
            label1.Text = "FileCopare";
            label1.Click += label1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(299, 8);
            button2.Name = "button2";
            button2.Size = new Size(92, 29);
            button2.TabIndex = 5;
            button2.Text = "폴더선택";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(9, 9);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(261, 27);
            textBox2.TabIndex = 2;
            // 
            // button3
            // 
            button3.Location = new Point(9, 67);
            button3.Name = "button3";
            button3.Size = new Size(90, 29);
            button3.TabIndex = 4;
            button3.Text = "<<<";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.BorderStyle = BorderStyle.FixedSingle;
            splitContainer1.Location = new Point(0, 0);
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
            splitContainer1.Size = new Size(922, 556);
            splitContainer1.SplitterDistance = 425;
            splitContainer1.TabIndex = 8;
            // 
            // panel4
            // 
            panel4.Controls.Add(button2);
            panel4.Controls.Add(textBox2);
            panel4.Location = new Point(3, 105);
            panel4.Name = "panel4";
            panel4.Size = new Size(415, 104);
            panel4.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Controls.Add(label1);
            panel3.Controls.Add(button5);
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(415, 104);
            panel3.TabIndex = 0;
            // 
            // panel7
            // 
            panel7.Controls.Add(listView2);
            panel7.Location = new Point(3, 214);
            panel7.Name = "panel7";
            panel7.Size = new Size(394, 329);
            panel7.TabIndex = 11;
            // 
            // listView2
            // 
            listView2.Columns.AddRange(new ColumnHeader[] { columnHeader4, columnHeader5, columnHeader6 });
            listView2.FullRowSelect = true;
            listView2.GridLines = true;
            listView2.Location = new Point(9, 53);
            listView2.Name = "listView2";
            listView2.Size = new Size(385, 254);
            listView2.TabIndex = 9;
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.View = View.Details;
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
            panel6.Controls.Add(button1);
            panel6.Controls.Add(textBox1);
            panel6.Location = new Point(3, 108);
            panel6.Name = "panel6";
            panel6.Size = new Size(394, 101);
            panel6.TabIndex = 10;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(button3);
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(394, 104);
            panel2.TabIndex = 9;
            // 
            // panel5
            // 
            panel5.Location = new Point(3, 102);
            panel5.Name = "panel5";
            panel5.Size = new Size(391, 104);
            panel5.TabIndex = 10;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(943, 556);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Text = "Form1";
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
        private Label label1;
        private Button button1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button5;
        private Button button3;
        private Button button2;
        private SplitContainer splitContainer1;
        private Panel panel4;
        private Panel panel3;
        private Panel panel2;
        private Panel panel5;
        private Panel panel6;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private Panel panel7;
        private ListView listView2;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
    }
}
