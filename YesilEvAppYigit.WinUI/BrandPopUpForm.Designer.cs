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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listBrands = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(34, 410);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(144, 45);
            this.button3.TabIndex = 12;
            this.button3.Text = "Seçimi Onayla";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tbSelectedCategory
            // 
            this.tbSelectedCategory.Enabled = false;
            this.tbSelectedCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSelectedCategory.Location = new System.Drawing.Point(6, 373);
            this.tbSelectedCategory.Name = "tbSelectedCategory";
            this.tbSelectedCategory.ReadOnly = true;
            this.tbSelectedCategory.Size = new System.Drawing.Size(200, 29);
            this.tbSelectedCategory.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(34, 285);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 45);
            this.button1.TabIndex = 10;
            this.button1.Text = "Seç";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 24);
            this.label1.TabIndex = 9;
            this.label1.Text = "Markalar";
            // 
            // listBrands
            // 
            this.listBrands.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBrands.FormattingEnabled = true;
            this.listBrands.ItemHeight = 24;
            this.listBrands.Location = new System.Drawing.Point(6, 49);
            this.listBrands.Name = "listBrands";
            this.listBrands.Size = new System.Drawing.Size(200, 220);
            this.listBrands.TabIndex = 8;
            // 
            // BrandPopUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(215, 487);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.tbSelectedCategory);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBrands);
            this.Name = "BrandPopUpForm";
            this.Text = "BrandPopUpForm";
            this.Load += new System.EventHandler(this.BrandPopUpForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox tbSelectedCategory;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBrands;
    }
}