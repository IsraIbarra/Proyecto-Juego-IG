namespace ProyectoKahootXD
{
    partial class FormRuleta
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
            this.pbCargando = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbCargando)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCargando
            // 
            this.pbCargando.Location = new System.Drawing.Point(60, 21);
            this.pbCargando.Name = "pbCargando";
            this.pbCargando.Size = new System.Drawing.Size(686, 140);
            this.pbCargando.TabIndex = 0;
            this.pbCargando.TabStop = false;
            // 
            // FormRuleta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pbCargando);
            this.Name = "FormRuleta";
            this.Text = "FormRuleta";
            ((System.ComponentModel.ISupportInitialize)(this.pbCargando)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCargando;
    }
}