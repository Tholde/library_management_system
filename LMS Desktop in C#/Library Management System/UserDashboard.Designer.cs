namespace Library_Management_System
{
    partial class UserDashboard
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
            this.button2 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.labelBookNumber = new System.Windows.Forms.Label();
            this.labelBorrow = new System.Windows.Forms.Label();
            this.labelBook = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBoxCancel = new System.Windows.Forms.PictureBox();
            this.pictureBoxBorrow = new System.Windows.Forms.PictureBox();
            this.pictureBoxBook = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBorrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBook)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DeepPink;
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("AngryBirds", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(760, 70);
            this.button2.TabIndex = 87;
            this.button2.Text = "User Panel";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label8.ForeColor = System.Drawing.Color.DeepPink;
            this.label8.Location = new System.Drawing.Point(172, 339);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 20);
            this.label8.TabIndex = 95;
            this.label8.Text = "book saved";
            // 
            // labelBookNumber
            // 
            this.labelBookNumber.AutoSize = true;
            this.labelBookNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.labelBookNumber.ForeColor = System.Drawing.Color.DeepPink;
            this.labelBookNumber.Location = new System.Drawing.Point(142, 339);
            this.labelBookNumber.Name = "labelBookNumber";
            this.labelBookNumber.Size = new System.Drawing.Size(19, 20);
            this.labelBookNumber.TabIndex = 94;
            this.labelBookNumber.Text = "0";
            // 
            // labelBorrow
            // 
            this.labelBorrow.AutoSize = true;
            this.labelBorrow.Font = new System.Drawing.Font("AngryBirds", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBorrow.Location = new System.Drawing.Point(472, 304);
            this.labelBorrow.Name = "labelBorrow";
            this.labelBorrow.Size = new System.Drawing.Size(127, 24);
            this.labelBorrow.TabIndex = 93;
            this.labelBorrow.Text = "Borrow Book";
            this.labelBorrow.Click += new System.EventHandler(this.labelBorrow_Click);
            // 
            // labelBook
            // 
            this.labelBook.AutoSize = true;
            this.labelBook.Font = new System.Drawing.Font("AngryBirds", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBook.Location = new System.Drawing.Point(162, 304);
            this.labelBook.Name = "labelBook";
            this.labelBook.Size = new System.Drawing.Size(90, 24);
            this.labelBook.TabIndex = 92;
            this.labelBook.Text = "Book List";
            this.labelBook.Click += new System.EventHandler(this.labelBook_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("AngryBirds", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(669, 467);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 24);
            this.label2.TabIndex = 91;
            this.label2.Text = "Logout";
            // 
            // pictureBoxCancel
            // 
            this.pictureBoxCancel.Image = global::Library_Management_System.Properties.Resources.logout;
            this.pictureBoxCancel.Location = new System.Drawing.Point(663, 404);
            this.pictureBoxCancel.Name = "pictureBoxCancel";
            this.pictureBoxCancel.Size = new System.Drawing.Size(82, 60);
            this.pictureBoxCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxCancel.TabIndex = 90;
            this.pictureBoxCancel.TabStop = false;
            // 
            // pictureBoxBorrow
            // 
            this.pictureBoxBorrow.Image = global::Library_Management_System.Properties.Resources.book_100px_copie;
            this.pictureBoxBorrow.Location = new System.Drawing.Point(432, 122);
            this.pictureBoxBorrow.Name = "pictureBoxBorrow";
            this.pictureBoxBorrow.Size = new System.Drawing.Size(210, 168);
            this.pictureBoxBorrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxBorrow.TabIndex = 89;
            this.pictureBoxBorrow.TabStop = false;
            this.pictureBoxBorrow.Click += new System.EventHandler(this.pictureBoxBorrow_Click);
            // 
            // pictureBoxBook
            // 
            this.pictureBoxBook.Image = global::Library_Management_System.Properties.Resources.book;
            this.pictureBoxBook.Location = new System.Drawing.Point(104, 122);
            this.pictureBoxBook.Name = "pictureBoxBook";
            this.pictureBoxBook.Size = new System.Drawing.Size(212, 168);
            this.pictureBoxBook.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxBook.TabIndex = 88;
            this.pictureBoxBook.TabStop = false;
            this.pictureBoxBook.Click += new System.EventHandler(this.pictureBoxBook_Click);
            // 
            // UserDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 496);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.labelBookNumber);
            this.Controls.Add(this.labelBorrow);
            this.Controls.Add(this.labelBook);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBoxCancel);
            this.Controls.Add(this.pictureBoxBorrow);
            this.Controls.Add(this.pictureBoxBook);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserDashboard";
            this.Text = "UserDashboard";
            this.Load += new System.EventHandler(this.UserDashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBorrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBook)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelBookNumber;
        private System.Windows.Forms.Label labelBorrow;
        private System.Windows.Forms.Label labelBook;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBoxCancel;
        private System.Windows.Forms.PictureBox pictureBoxBorrow;
        private System.Windows.Forms.PictureBox pictureBoxBook;
    }
}