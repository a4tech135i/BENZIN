namespace BENZIN_1._0
{
    partial class main_menu
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DarkOrange;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.button3.Location = new System.Drawing.Point(25, 130);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(232, 44);
            this.button3.TabIndex = 15;
            this.button3.Text = "Вихід";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkOrange;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.button1.Location = new System.Drawing.Point(25, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(232, 44);
            this.button1.TabIndex = 16;
            this.button1.Text = "Нова гра";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DarkOrange;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.button2.Location = new System.Drawing.Point(25, 81);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(232, 44);
            this.button2.TabIndex = 17;
            this.button2.Text = "Загрузити сейв";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // main_menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(18)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(284, 191);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.MaximumSize = new System.Drawing.Size(300, 229);
            this.MinimumSize = new System.Drawing.Size(300, 229);
            this.Name = "main_menu";
            this.Text = "BENZIN";
            this.Load += new System.EventHandler(this.main_menu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}