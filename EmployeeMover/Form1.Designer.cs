namespace EmployeeMover
{
    partial class EmployeeMover
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
            this.btnSendToBungalo = new System.Windows.Forms.Button();
            this.listBoxUsers = new System.Windows.Forms.ListBox();
            this.listBoxSaves = new System.Windows.Forms.ListBox();
            this.listBoxBusinesses = new System.Windows.Forms.ListBox();
            this.listBoxEmployees = new System.Windows.Forms.ListBox();
            this.btnSendToBarn = new System.Windows.Forms.Button();
            this.btnSendToSweatshop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSendToMotel = new System.Windows.Forms.Button();
            this.btnSendToWarehouse = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSendToBungalo
            // 
            this.btnSendToBungalo.Location = new System.Drawing.Point(654, 243);
            this.btnSendToBungalo.Name = "btnSendToBungalo";
            this.btnSendToBungalo.Size = new System.Drawing.Size(93, 23);
            this.btnSendToBungalo.TabIndex = 0;
            this.btnSendToBungalo.Text = "Bungalow";
            this.btnSendToBungalo.UseVisualStyleBackColor = true;
            this.btnSendToBungalo.Click += new System.EventHandler(this.btnSendToBungalo_Click);
            // 
            // listBoxUsers
            // 
            this.listBoxUsers.FormattingEnabled = true;
            this.listBoxUsers.Location = new System.Drawing.Point(6, 179);
            this.listBoxUsers.Name = "listBoxUsers";
            this.listBoxUsers.Size = new System.Drawing.Size(139, 212);
            this.listBoxUsers.TabIndex = 2;
            this.listBoxUsers.SelectedIndexChanged += new System.EventHandler(this.listBoxUsers_SelectedIndexChanged);
            // 
            // listBoxSaves
            // 
            this.listBoxSaves.FormattingEnabled = true;
            this.listBoxSaves.Location = new System.Drawing.Point(154, 179);
            this.listBoxSaves.Name = "listBoxSaves";
            this.listBoxSaves.Size = new System.Drawing.Size(120, 212);
            this.listBoxSaves.TabIndex = 3;
            this.listBoxSaves.SelectedIndexChanged += new System.EventHandler(this.listBoxSaves_SelectedIndexChanged);
            // 
            // listBoxBusinesses
            // 
            this.listBoxBusinesses.FormattingEnabled = true;
            this.listBoxBusinesses.Location = new System.Drawing.Point(280, 179);
            this.listBoxBusinesses.Name = "listBoxBusinesses";
            this.listBoxBusinesses.Size = new System.Drawing.Size(160, 212);
            this.listBoxBusinesses.TabIndex = 4;
            this.listBoxBusinesses.SelectedIndexChanged += new System.EventHandler(this.listBoxBusinesses_SelectedIndexChanged);
            // 
            // listBoxEmployees
            // 
            this.listBoxEmployees.FormattingEnabled = true;
            this.listBoxEmployees.Location = new System.Drawing.Point(465, 179);
            this.listBoxEmployees.Name = "listBoxEmployees";
            this.listBoxEmployees.Size = new System.Drawing.Size(120, 212);
            this.listBoxEmployees.TabIndex = 5;
            // 
            // btnSendToBarn
            // 
            this.btnSendToBarn.Location = new System.Drawing.Point(654, 272);
            this.btnSendToBarn.Name = "btnSendToBarn";
            this.btnSendToBarn.Size = new System.Drawing.Size(93, 23);
            this.btnSendToBarn.TabIndex = 6;
            this.btnSendToBarn.Text = "Barn";
            this.btnSendToBarn.UseVisualStyleBackColor = true;
            // 
            // btnSendToSweatshop
            // 
            this.btnSendToSweatshop.Location = new System.Drawing.Point(654, 214);
            this.btnSendToSweatshop.Name = "btnSendToSweatshop";
            this.btnSendToSweatshop.Size = new System.Drawing.Size(93, 23);
            this.btnSendToSweatshop.TabIndex = 7;
            this.btnSendToSweatshop.Text = "Sweatshop";
            this.btnSendToSweatshop.UseVisualStyleBackColor = true;
            this.btnSendToSweatshop.Click += new System.EventHandler(this.btnSendToSweatshop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Step 1:  Select account user";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(151, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Step 2: select save";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(268, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Step 3: Select location to send from";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(465, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Step 4: Select Employee to move";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(632, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(153, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Step 5: Set location to move to";
            // 
            // btnSendToMotel
            // 
            this.btnSendToMotel.Location = new System.Drawing.Point(654, 179);
            this.btnSendToMotel.Name = "btnSendToMotel";
            this.btnSendToMotel.Size = new System.Drawing.Size(93, 23);
            this.btnSendToMotel.TabIndex = 13;
            this.btnSendToMotel.Text = "Motel";
            this.btnSendToMotel.UseVisualStyleBackColor = true;
            this.btnSendToMotel.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSendToWarehouse
            // 
            this.btnSendToWarehouse.Location = new System.Drawing.Point(654, 301);
            this.btnSendToWarehouse.Name = "btnSendToWarehouse";
            this.btnSendToWarehouse.Size = new System.Drawing.Size(93, 23);
            this.btnSendToWarehouse.TabIndex = 14;
            this.btnSendToWarehouse.Text = "Warehouse";
            this.btnSendToWarehouse.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(213, -3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 150);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_2);
            // 
            // EmployeeMover
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(809, 458);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSendToWarehouse);
            this.Controls.Add(this.btnSendToMotel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSendToSweatshop);
            this.Controls.Add(this.btnSendToBarn);
            this.Controls.Add(this.listBoxEmployees);
            this.Controls.Add(this.listBoxBusinesses);
            this.Controls.Add(this.listBoxSaves);
            this.Controls.Add(this.listBoxUsers);
            this.Controls.Add(this.btnSendToBungalo);
            this.Name = "EmployeeMover";
            this.Text = "Schedule I: Employee Mover";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSendToBungalo;
        private System.Windows.Forms.ListBox listBoxUsers;
        private System.Windows.Forms.ListBox listBoxSaves;
        private System.Windows.Forms.ListBox listBoxBusinesses;
        private System.Windows.Forms.ListBox listBoxEmployees;
        private System.Windows.Forms.Button btnSendToBarn;
        private System.Windows.Forms.Button btnSendToSweatshop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSendToMotel;
        private System.Windows.Forms.Button btnSendToWarehouse;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

