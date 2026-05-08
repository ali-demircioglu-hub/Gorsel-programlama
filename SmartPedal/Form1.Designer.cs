namespace SmartPedal
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnload = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnfeedback = new System.Windows.Forms.Button();
            this.btnkayit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Location = new System.Drawing.Point(887, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(883, 749);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(315, 84);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Location = new System.Drawing.Point(312, 117);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(473, 644);
            this.panel3.TabIndex = 4;
            // 
            // btnload
            // 
            this.btnload.BackColor = System.Drawing.Color.Transparent;
            this.btnload.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnload.BackgroundImage")));
            this.btnload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnload.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnload.ForeColor = System.Drawing.Color.Black;
            this.btnload.Location = new System.Drawing.Point(28, 113);
            this.btnload.Name = "btnload";
            this.btnload.Size = new System.Drawing.Size(125, 125);
            this.btnload.TabIndex = 0;
            this.btnload.Text = "Plugin yükle";
            this.btnload.UseVisualStyleBackColor = false;
            this.btnload.Click += new System.EventHandler(this.btnload_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.btnfeedback);
            this.panel2.Controls.Add(this.btnkayit);
            this.panel2.Controls.Add(this.btnload);
            this.panel2.Location = new System.Drawing.Point(13, 117);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(201, 644);
            this.panel2.TabIndex = 3;
            // 
            // btnfeedback
            // 
            this.btnfeedback.BackColor = System.Drawing.Color.Transparent;
            this.btnfeedback.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnfeedback.BackgroundImage")));
            this.btnfeedback.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnfeedback.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnfeedback.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnfeedback.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnfeedback.Location = new System.Drawing.Point(28, 480);
            this.btnfeedback.Name = "btnfeedback";
            this.btnfeedback.Size = new System.Drawing.Size(125, 125);
            this.btnfeedback.TabIndex = 2;
            this.btnfeedback.Text = "Geri yükle";
            this.btnfeedback.UseVisualStyleBackColor = false;
            this.btnfeedback.Click += new System.EventHandler(this.btnfeedback_Click);
            // 
            // btnkayit
            // 
            this.btnkayit.BackColor = System.Drawing.Color.Transparent;
            this.btnkayit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnkayit.BackgroundImage")));
            this.btnkayit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnkayit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnkayit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnkayit.Location = new System.Drawing.Point(29, 258);
            this.btnkayit.Name = "btnkayit";
            this.btnkayit.Size = new System.Drawing.Size(125, 125);
            this.btnkayit.TabIndex = 1;
            this.btnkayit.Text = "Kaydet";
            this.btnkayit.UseVisualStyleBackColor = false;
            this.btnkayit.Click += new System.EventHandler(this.btnkayit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(44)))), ((int)(((byte)(52)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1782, 773);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnload;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnfeedback;
        private System.Windows.Forms.Button btnkayit;
    }
}

