namespace Library_Management_System
{
    partial class BorrowBook
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelBorrowList = new System.Windows.Forms.Panel();
            this.listViewBorrowList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonShow = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxIdUserStory = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.buttonReturn = new System.Windows.Forms.Button();
            this.labelSelectedElement = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonBorrow = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxIsbnBook = new System.Windows.Forms.TextBox();
            this.textBoxIdUser = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimeEndOfSemester = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.listViewStory = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panelBorrowList.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panelBorrowList);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.buttonShow);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.textBoxIdUserStory);
            this.panel2.Controls.Add(this.statusStrip1);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(421, 83);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1027, 709);
            this.panel2.TabIndex = 5;
            // 
            // panelBorrowList
            // 
            this.panelBorrowList.Controls.Add(this.label4);
            this.panelBorrowList.Controls.Add(this.listViewStory);
            this.panelBorrowList.Controls.Add(this.listViewBorrowList);
            this.panelBorrowList.Location = new System.Drawing.Point(0, 168);
            this.panelBorrowList.Name = "panelBorrowList";
            this.panelBorrowList.Size = new System.Drawing.Size(1027, 471);
            this.panelBorrowList.TabIndex = 91;
            // 
            // listViewBorrowList
            // 
            this.listViewBorrowList.BackColor = System.Drawing.SystemColors.MenuBar;
            this.listViewBorrowList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewBorrowList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader7});
            this.listViewBorrowList.FullRowSelect = true;
            this.listViewBorrowList.HideSelection = false;
            this.listViewBorrowList.Location = new System.Drawing.Point(0, 3);
            this.listViewBorrowList.Name = "listViewBorrowList";
            this.listViewBorrowList.Size = new System.Drawing.Size(1021, 225);
            this.listViewBorrowList.TabIndex = 88;
            this.listViewBorrowList.UseCompatibleStateImageBehavior = false;
            this.listViewBorrowList.View = System.Windows.Forms.View.Details;
            this.listViewBorrowList.SelectedIndexChanged += new System.EventHandler(this.listViewBorrowList_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ISBN";
            this.columnHeader1.Width = 101;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "TITLE";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 291;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "AUTHOR";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 187;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "PERSON ID";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 115;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "BORROW DATE";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 166;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "NORMAL RETURN DATE";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 154;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("AngryBirds", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(138, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 26);
            this.label9.TabIndex = 90;
            this.label9.Text = "Remark :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label8.ForeColor = System.Drawing.Color.DeepPink;
            this.label8.Location = new System.Drawing.Point(232, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(575, 24);
            this.label8.TabIndex = 89;
            this.label8.Text = "If you to show a list of your borrow story, please enter your id";
            // 
            // buttonShow
            // 
            this.buttonShow.BackColor = System.Drawing.Color.DeepPink;
            this.buttonShow.FlatAppearance.BorderSize = 0;
            this.buttonShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShow.Font = new System.Drawing.Font("AngryBirds", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShow.Location = new System.Drawing.Point(542, 121);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(132, 32);
            this.buttonShow.TabIndex = 88;
            this.buttonShow.Text = "Show";
            this.buttonShow.UseVisualStyleBackColor = false;
            this.buttonShow.Click += new System.EventHandler(this.buttonShow_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("AngryBirds", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(213, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 24);
            this.label7.TabIndex = 85;
            this.label7.Text = "your id :";
            // 
            // textBoxIdUserStory
            // 
            this.textBoxIdUserStory.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxIdUserStory.Location = new System.Drawing.Point(300, 121);
            this.textBoxIdUserStory.Name = "textBoxIdUserStory";
            this.textBoxIdUserStory.Size = new System.Drawing.Size(236, 32);
            this.textBoxIdUserStory.TabIndex = 84;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 687);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1027, 22);
            this.statusStrip1.TabIndex = 79;
            this.statusStrip1.Text = "0 biblioman saved";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(103, 17);
            this.toolStripStatusLabel1.Text = "0 biblioman saved";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("AngryBirds", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(384, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 31);
            this.label5.TabIndex = 78;
            this.label5.Text = "Borrow List";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dateTimeEndOfSemester);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.buttonLogout);
            this.panel1.Controls.Add(this.buttonReturn);
            this.panel1.Controls.Add(this.labelSelectedElement);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonBorrow);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.textBoxIsbnBook);
            this.panel1.Controls.Add(this.textBoxIdUser);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(418, 709);
            this.panel1.TabIndex = 4;
            // 
            // buttonLogout
            // 
            this.buttonLogout.BackColor = System.Drawing.Color.DeepPink;
            this.buttonLogout.FlatAppearance.BorderSize = 0;
            this.buttonLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogout.Font = new System.Drawing.Font("AngryBirds", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogout.Location = new System.Drawing.Point(101, 659);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(132, 32);
            this.buttonLogout.TabIndex = 83;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = false;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // buttonReturn
            // 
            this.buttonReturn.BackColor = System.Drawing.Color.DeepPink;
            this.buttonReturn.FlatAppearance.BorderSize = 0;
            this.buttonReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReturn.Font = new System.Drawing.Font("AngryBirds", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReturn.Location = new System.Drawing.Point(110, 288);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.Size = new System.Drawing.Size(132, 32);
            this.buttonReturn.TabIndex = 82;
            this.buttonReturn.Text = "Return";
            this.buttonReturn.UseVisualStyleBackColor = false;
            this.buttonReturn.Click += new System.EventHandler(this.buttonReturn_Click);
            // 
            // labelSelectedElement
            // 
            this.labelSelectedElement.AutoSize = true;
            this.labelSelectedElement.Font = new System.Drawing.Font("AngryBirds", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectedElement.Location = new System.Drawing.Point(252, 431);
            this.labelSelectedElement.Name = "labelSelectedElement";
            this.labelSelectedElement.Size = new System.Drawing.Size(34, 24);
            this.labelSelectedElement.TabIndex = 81;
            this.labelSelectedElement.Text = "00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("AngryBirds", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(133, 431);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 24);
            this.label6.TabIndex = 80;
            this.label6.Text = "Id selected :";
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.DeepPink;
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("AngryBirds", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(250, 659);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(132, 32);
            this.buttonCancel.TabIndex = 78;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("AngryBirds", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(127, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 31);
            this.label1.TabIndex = 71;
            this.label1.Text = "Borrow Book";
            // 
            // buttonBorrow
            // 
            this.buttonBorrow.BackColor = System.Drawing.Color.DeepPink;
            this.buttonBorrow.FlatAppearance.BorderSize = 0;
            this.buttonBorrow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBorrow.Font = new System.Drawing.Font("AngryBirds", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBorrow.Location = new System.Drawing.Point(259, 288);
            this.buttonBorrow.Name = "buttonBorrow";
            this.buttonBorrow.Size = new System.Drawing.Size(132, 32);
            this.buttonBorrow.TabIndex = 70;
            this.buttonBorrow.Text = "Borrow";
            this.buttonBorrow.UseVisualStyleBackColor = false;
            this.buttonBorrow.Click += new System.EventHandler(this.buttonBorrow_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("AngryBirds", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(32, 152);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(109, 24);
            this.label11.TabIndex = 66;
            this.label11.Text = "ISBN Book  :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("AngryBirds", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(32, 107);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 24);
            this.label10.TabIndex = 65;
            this.label10.Text = "Your ID     :";
            // 
            // textBoxIsbnBook
            // 
            this.textBoxIsbnBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxIsbnBook.Location = new System.Drawing.Point(153, 150);
            this.textBoxIsbnBook.Name = "textBoxIsbnBook";
            this.textBoxIsbnBook.Size = new System.Drawing.Size(236, 26);
            this.textBoxIsbnBook.TabIndex = 63;
            // 
            // textBoxIdUser
            // 
            this.textBoxIdUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxIdUser.Location = new System.Drawing.Point(153, 107);
            this.textBoxIdUser.Name = "textBoxIdUser";
            this.textBoxIdUser.Size = new System.Drawing.Size(236, 26);
            this.textBoxIdUser.TabIndex = 62;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DeepPink;
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("AngryBirds", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(1448, 83);
            this.button1.TabIndex = 3;
            this.button1.Text = "User Panel";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("AngryBirds", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 24);
            this.label2.TabIndex = 84;
            this.label2.Text = "End of Semeter  :";
            // 
            // dateTimeEndOfSemester
            // 
            this.dateTimeEndOfSemester.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.dateTimeEndOfSemester.Location = new System.Drawing.Point(155, 194);
            this.dateTimeEndOfSemester.Name = "dateTimeEndOfSemester";
            this.dateTimeEndOfSemester.Size = new System.Drawing.Size(236, 23);
            this.dateTimeEndOfSemester.TabIndex = 85;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.dateTimePicker2.Location = new System.Drawing.Point(155, 242);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(236, 23);
            this.dateTimePicker2.TabIndex = 87;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("AngryBirds", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 239);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 24);
            this.label3.TabIndex = 86;
            this.label3.Text = "Return Date  :";
            // 
            // listViewStory
            // 
            this.listViewStory.BackColor = System.Drawing.SystemColors.MenuBar;
            this.listViewStory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewStory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14});
            this.listViewStory.FullRowSelect = true;
            this.listViewStory.HideSelection = false;
            this.listViewStory.Location = new System.Drawing.Point(33, 270);
            this.listViewStory.Name = "listViewStory";
            this.listViewStory.Size = new System.Drawing.Size(936, 215);
            this.listViewStory.TabIndex = 97;
            this.listViewStory.UseCompatibleStateImageBehavior = false;
            this.listViewStory.View = System.Windows.Forms.View.Details;
            this.listViewStory.SelectedIndexChanged += new System.EventHandler(this.listViewStory_SelectedIndexChanged);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "ISBN";
            this.columnHeader6.Width = 127;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "PERSON ID";
            this.columnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader10.Width = 115;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "BORROW DATE";
            this.columnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader11.Width = 166;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "RETURN DATE";
            this.columnHeader12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader12.Width = 154;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "STATUS";
            this.columnHeader13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader13.Width = 180;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Pay";
            this.columnHeader14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader14.Width = 183;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("AngryBirds", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(370, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(181, 26);
            this.label4.TabIndex = 92;
            this.label4.Text = "Borrow  Story List";
            // 
            // BorrowBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1448, 792);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BorrowBook";
            this.Text = "BorrowBook";
            this.Load += new System.EventHandler(this.BorrowBook_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelBorrowList.ResumeLayout(false);
            this.panelBorrowList.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Button buttonReturn;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonBorrow;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxIsbnBook;
        private System.Windows.Forms.TextBox textBoxIdUser;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonShow;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxIdUserStory;
        private System.Windows.Forms.Label labelSelectedElement;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panelBorrowList;
        private System.Windows.Forms.ListView listViewBorrowList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.DateTimePicker dateTimeEndOfSemester;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listViewStory;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.Label label4;
    }
}