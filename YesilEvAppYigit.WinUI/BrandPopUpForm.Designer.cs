namespace YesilEvAppYigit.WinUI
{
    partial class BrandPopUpForm
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
            this.button3 = new System.Windows.Forms.Button();
            this.tbSelectedCategory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBrands = new System.Windows.Forms.ListBox();
            this.tbNewBrandName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbManufacturer = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(294, 304);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(144, 45);
            this.button3.TabIndex = 12;
            this.button3.Text = "Onayla";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tbSelectedCategory
            // 
            this.tbSelectedCategory.Enabled = false;
            this.tbSelectedCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSelectedCategory.Location = new System.Drawing.Point(334, 246);
            this.tbSelectedCategory.Name = "tbSelectedCategory";
            this.tbSelectedCategory.ReadOnly = true;
            this.tbSelectedCategory.Size = new System.Drawing.Size(186, 29);
            this.tbSelectedCategory.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(63, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 24);
            this.label1.TabIndex = 9;
            this.label1.Text = "Markalar";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // listBrands
            // 
            this.listBrands.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBrands.FormattingEnabled = true;
            this.listBrands.ItemHeight = 24;
            this.listBrands.Location = new System.Drawing.Point(6, 36);
            this.listBrands.Name = "listBrands";
            this.listBrands.Size = new System.Drawing.Size(200, 316);
            this.listBrands.TabIndex = 8;
            this.listBrands.SelectedIndexChanged += new System.EventHandler(this.listBrands_SelectedIndexChanged);
            // 
            // tbNewBrandName
            // 
            this.tbNewBrandName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNewBrandName.Location = new System.Drawing.Point(111, 20);
            this.tbNewBrandName.Name = "tbNewBrandName";
            this.tbNewBrandName.Size = new System.Drawing.Size(173, 29);
            this.tbNewBrandName.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(290, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 24);
            this.label2.TabIndex = 14;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(59, 138);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(183, 41);
            this.button2.TabIndex = 13;
            this.button2.Text = "Yeni Marka Ekle";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbManufacturer);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbNewBrandName);
            this.groupBox1.Location = new System.Drawing.Point(221, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(299, 190);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // cbManufacturer
            // 
            this.cbManufacturer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbManufacturer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbManufacturer.FormattingEnabled = true;
            this.cbManufacturer.Location = new System.Drawing.Point(111, 83);
            this.cbManufacturer.Name = "cbManufacturer";
            this.cbManufacturer.Size = new System.Drawing.Size(173, 32);
            this.cbManufacturer.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 24);
            this.label4.TabIndex = 16;
            this.label4.Text = "Üretici:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 24);
            this.label3.TabIndex = 15;
            this.label3.Text = "Marka Adı:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(217, 249);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 24);
            this.label5.TabIndex = 17;
            this.label5.Text = "Seçili Marka:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(280, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(187, 32);
            this.button1.TabIndex = 18;
            this.button1.Text = "Yeni Marka Ekleme";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // BrandPopUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 361);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.tbSelectedCategory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBrands);
            this.MaximumSize = new System.Drawing.Size(550, 400);
            this.MinimumSize = new System.Drawing.Size(550, 400);
            this.Name = "BrandPopUpForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Marka Ekleme";
            this.Load += new System.EventHandler(this.BrandPopUpForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox tbSelectedCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBrands;
        private System.Windows.Forms.TextBox tbNewBrandName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbManufacturer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
    }
}