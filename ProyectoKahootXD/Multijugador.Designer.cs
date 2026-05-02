namespace ProyectoKahootXD
{
    partial class Multijugador
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
            this.pbEncabezado = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pbJoin = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbEncabezado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbJoin)).BeginInit();
            this.SuspendLayout();
            // 
            // pbEncabezado
            // 
            this.pbEncabezado.Location = new System.Drawing.Point(70, 25);
            this.pbEncabezado.Name = "pbEncabezado";
            this.pbEncabezado.Size = new System.Drawing.Size(646, 100);
            this.pbEncabezado.TabIndex = 0;
            this.pbEncabezado.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(70, 181);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(646, 34);
            this.textBox1.TabIndex = 1;
            // 
            // pbJoin
            // 
            this.pbJoin.Location = new System.Drawing.Point(237, 283);
            this.pbJoin.Name = "pbJoin";
            this.pbJoin.Size = new System.Drawing.Size(278, 132);
            this.pbJoin.TabIndex = 3;
            this.pbJoin.TabStop = false;
            this.pbJoin.Click += new System.EventHandler(this.pbJoin_Click);
            this.pbJoin.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pbJoin_MouseDoubleClick);
            // 
            // Multijugador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pbJoin);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pbEncabezado);
            this.Name = "Multijugador";
            this.Text = "Kah00t";
            this.Load += new System.EventHandler(this.Multijugador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbEncabezado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbJoin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbEncabezado;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pbJoin;
    }
}