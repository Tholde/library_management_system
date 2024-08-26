namespace Library_Management_System
{
    partial class BookList
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
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxAthem = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.textBoxAuthor = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.textBoxIsbn = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.listViewBookList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.button1.Size = new System.Drawing.Size(1075, 85);
            this.button1.TabIndex = 6;
            this.button1.Text = "User Panel";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.comboBoxCategory);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.buttonCancel);
            this.panel2.Controls.Add(this.textBoxAthem);
            this.panel2.Controls.Add(this.label26);
            this.panel2.Controls.Add(this.textBoxAuthor);
            this.panel2.Controls.Add(this.label32);
            this.panel2.Controls.Add(this.textBoxIsbn);
            this.panel2.Controls.Add(this.label35);
            this.panel2.Controls.Add(this.textBoxTitle);
            this.panel2.Controls.Add(this.label37);
            this.panel2.Controls.Add(this.statusStrip1);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.listViewBookList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(0, 85);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1075, 721);
            this.panel2.TabIndex = 7;
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Items.AddRange(new object[] {
            "Theology",
            "Busness",
            "Informatic",
            "Nursing",
            "Education",
            "Communication",
            "English Language",
            "Ellen White",
            "Bible",
            "Encyclopedy",
            "All"});
            this.comboBoxCategory.Location = new System.Drawing.Point(244, 99);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(162, 21);
            this.comboBoxCategory.TabIndex = 90;
            this.comboBoxCategory.SelectedIndexChanged += new System.EventHandler(this.comboBoxCategory_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label1.Location = new System.Drawing.Point(134, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 89;
            this.label1.Text = "Search by Category :";
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.DeepPink;
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("AngryBirds", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(931, 669);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(132, 32);
            this.buttonCancel.TabIndex = 88;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // textBoxAthem
            // 
            this.textBoxAthem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.textBoxAthem.Location = new System.Drawing.Point(677, 95);
            this.textBoxAthem.Name = "textBoxAthem";
            this.textBoxAthem.Size = new System.Drawing.Size(143, 20);
            this.textBoxAthem.TabIndex = 87;
            this.textBoxAthem.TextChanged += new System.EventHandler(this.textBoxAthem_TextChanged);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label26.Location = new System.Drawing.Point(566, 102);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(93, 13);
            this.label26.TabIndex = 86;
            this.label26.Text = "Search by athem :";
            // 
            // textBoxAuthor
            // 
            this.textBoxAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.textBoxAuthor.Location = new System.Drawing.Point(816, 62);
            this.textBoxAuthor.Name = "textBoxAuthor";
            this.textBoxAuthor.Size = new System.Drawing.Size(143, 20);
            this.textBoxAuthor.TabIndex = 85;
            this.textBoxAuthor.TextChanged += new System.EventHandler(this.textBoxAuthor_TextChanged);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label32.Location = new System.Drawing.Point(713, 65);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(94, 13);
            this.label32.TabIndex = 84;
            this.label32.Text = "Search by author :";
            // 
            // textBoxIsbn
            // 
            this.textBoxIsbn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.textBoxIsbn.Location = new System.Drawing.Point(169, 63);
            this.textBoxIsbn.Name = "textBoxIsbn";
            this.textBoxIsbn.Size = new System.Drawing.Size(143, 20);
            this.textBoxIsbn.TabIndex = 83;
            this.textBoxIsbn.TextChanged += new System.EventHandler(this.textBoxIsbn_TextChanged);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label35.Location = new System.Drawing.Point(79, 66);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(89, 13);
            this.label35.TabIndex = 82;
            this.label35.Text = "Search by ISBN :";
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.textBoxTitle.Location = new System.Drawing.Point(474, 62);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(143, 20);
            this.textBoxTitle.TabIndex = 81;
            this.textBoxTitle.TextChanged += new System.EventHandler(this.textBoxTitle_TextChanged);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label37.Location = new System.Drawing.Point(391, 66);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(80, 13);
            this.label37.TabIndex = 80;
            this.label37.Text = "Search by title :";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 699);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1075, 22);
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
            this.label5.Location = new System.Drawing.Point(468, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 31);
            this.label5.TabIndex = 78;
            this.label5.Text = "Book List";
            // 
            // listViewBookList
            // 
            this.listViewBookList.BackColor = System.Drawing.SystemColors.MenuBar;
            this.listViewBookList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewBookList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader7,
            this.columnHeader8});
            this.listViewBookList.FullRowSelect = true;
            this.listViewBookList.HideSelection = false;
            this.listViewBookList.Location = new System.Drawing.Point(12, 131);
            this.listViewBookList.Name = "listViewBookList";
            this.listViewBookList.Size = new System.Drawing.Size(1051, 527);
            this.listViewBookList.TabIndex = 0;
            this.listViewBookList.UseCompatibleStateImageBehavior = false;
            this.listViewBookList.View = System.Windows.Forms.View.Details;
            this.listViewBookList.SelectedIndexChanged += new System.EventHandler(this.listViewBookList_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ISBN";
            this.columnHeader1.Width = 97;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "TITLE";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 242;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "AUTHOR";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 211;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "CATEGORY";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 148;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "ATHEM";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 145;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "CREATED DATE";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 101;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "UPDATED DATE";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader8.Width = 103;
            // 
            // BookList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 806);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BookList";
            this.Text = "BookList";
            this.Load += new System.EventHandler(this.BookList_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBoxAthem;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox textBoxAuthor;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox textBoxIsbn;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView listViewBookList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCancel;
    }
}