namespace ProyectoKahootXD
{
    partial class Form4
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
            this.components = new System.ComponentModel.Container();
            this.labelRes = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pbEncabezado = new System.Windows.Forms.PictureBox();
            this.pbResultados = new System.Windows.Forms.PictureBox();
            this.pbRestart = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbEncabezado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbResultados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRestart)).BeginInit();
            this.SuspendLayout();
            // 
            // labelRes
            // 
            this.labelRes.AutoSize = true;
            this.labelRes.Font = new System.Drawing.Font("MV Boli", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRes.Location = new System.Drawing.Point(205, 136);
            this.labelRes.Name = "labelRes";
            this.labelRes.Size = new System.Drawing.Size(0, 25);
            this.labelRes.TabIndex = 5;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // pbEncabezado
            // 
            this.pbEncabezado.Location = new System.Drawing.Point(12, 12);
            this.pbEncabezado.Name = "pbEncabezado";
            this.pbEncabezado.Size = new System.Drawing.Size(776, 150);
            this.pbEncabezado.TabIndex = 6;
            this.pbEncabezado.TabStop = false;
            // 
            // pbResultados
            // 
            this.pbResultados.Location = new System.Drawing.Point(197, 189);
            this.pbResultados.Name = "pbResultados";
            this.pbResultados.Size = new System.Drawing.Size(400, 200);
            this.pbResultados.TabIndex = 7;
            this.pbResultados.TabStop = false;
            // 
            // pbRestart
            // 
            this.pbRestart.Location = new System.Drawing.Point(688, 388);
            this.pbRestart.Name = "pbRestart";
            this.pbRestart.Size = new System.Drawing.Size(100, 50);
            this.pbRestart.TabIndex = 8;
            this.pbRestart.TabStop = false;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pbRestart);
            this.Controls.Add(this.pbResultados);
            this.Controls.Add(this.pbEncabezado);
            this.Controls.Add(this.labelRes);
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbEncabezado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbResultados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRestart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelRes;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.PictureBox pbEncabezado;
        private System.Windows.Forms.PictureBox pbResultados;
        private System.Windows.Forms.PictureBox pbRestart;
    }
}