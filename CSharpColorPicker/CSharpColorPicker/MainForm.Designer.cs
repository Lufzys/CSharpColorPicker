namespace CSharpColorPicker
{
    partial class MainForm
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
            this.plColorHolder = new System.Windows.Forms.Panel();
            this.pbColor = new System.Windows.Forms.PictureBox();
            this.colorPickerVertical1 = new CSharpColorPicker.ColorPickerVertical();
            this.colorPicker1 = new CSharpColorPicker.ColorPicker();
            this.plColorHolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbColor)).BeginInit();
            this.SuspendLayout();
            // 
            // plColorHolder
            // 
            this.plColorHolder.BackColor = System.Drawing.Color.Black;
            this.plColorHolder.Controls.Add(this.pbColor);
            this.plColorHolder.Location = new System.Drawing.Point(194, 12);
            this.plColorHolder.Name = "plColorHolder";
            this.plColorHolder.Padding = new System.Windows.Forms.Padding(1);
            this.plColorHolder.Size = new System.Drawing.Size(32, 32);
            this.plColorHolder.TabIndex = 4;
            // 
            // pbColor
            // 
            this.pbColor.BackColor = System.Drawing.Color.Gray;
            this.pbColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbColor.Location = new System.Drawing.Point(1, 1);
            this.pbColor.Name = "pbColor";
            this.pbColor.Padding = new System.Windows.Forms.Padding(5);
            this.pbColor.Size = new System.Drawing.Size(30, 30);
            this.pbColor.TabIndex = 2;
            this.pbColor.TabStop = false;
            // 
            // colorPickerVertical1
            // 
            this.colorPickerVertical1.Location = new System.Drawing.Point(168, 12);
            this.colorPickerVertical1.MainColor = System.Drawing.Color.Red;
            this.colorPickerVertical1.Name = "colorPickerVertical1";
            this.colorPickerVertical1.Size = new System.Drawing.Size(20, 150);
            this.colorPickerVertical1.TabIndex = 3;
            this.colorPickerVertical1.ColorChanged += new CSharpColorPicker.ColorPickerVertical.colorChanged(this.colorPickerVertical1_ColorChanged);
            // 
            // colorPicker1
            // 
            this.colorPicker1.Location = new System.Drawing.Point(12, 12);
            this.colorPicker1.MainColor = System.Drawing.Color.Red;
            this.colorPicker1.Name = "colorPicker1";
            this.colorPicker1.Size = new System.Drawing.Size(150, 150);
            this.colorPicker1.TabIndex = 2;
            this.colorPicker1.ColorChanged += new CSharpColorPicker.ColorPicker.colorChanged(this.colorPicker1_ColorChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(241, 177);
            this.Controls.Add(this.plColorHolder);
            this.Controls.Add(this.colorPickerVertical1);
            this.Controls.Add(this.colorPicker1);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Basic Color Picker";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.plColorHolder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbColor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private ColorPicker colorPicker1;
        private ColorPickerVertical colorPickerVertical1;
        private System.Windows.Forms.Panel plColorHolder;
        private System.Windows.Forms.PictureBox pbColor;
    }
}

