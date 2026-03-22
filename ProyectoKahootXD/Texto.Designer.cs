namespace ProyectoKahootXD
{
    partial class Texto
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
            this.lblNumero = new System.Windows.Forms.Label();
            this.lblEnunciado = new System.Windows.Forms.Label();
            this.btnOpcionA = new System.Windows.Forms.Button();
            this.btnOpcionB = new System.Windows.Forms.Button();
            this.btnOpcionC = new System.Windows.Forms.Button();
            this.btnOpcionD = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Location = new System.Drawing.Point(38, 33);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(89, 16);
            this.lblNumero.TabIndex = 0;
            this.lblNumero.Text = "Pregunta 1/12";
            // 
            // lblEnunciado
            // 
            this.lblEnunciado.Location = new System.Drawing.Point(38, 77);
            this.lblEnunciado.Name = "lblEnunciado";
            this.lblEnunciado.Size = new System.Drawing.Size(728, 125);
            this.lblEnunciado.TabIndex = 1;
            // 
            // btnOpcionA
            // 
            this.btnOpcionA.Location = new System.Drawing.Point(12, 281);
            this.btnOpcionA.Name = "btnOpcionA";
            this.btnOpcionA.Size = new System.Drawing.Size(166, 73);
            this.btnOpcionA.TabIndex = 2;
            this.btnOpcionA.Text = "button1";
            this.btnOpcionA.UseVisualStyleBackColor = true;
            // 
            // btnOpcionB
            // 
            this.btnOpcionB.Location = new System.Drawing.Point(184, 281);
            this.btnOpcionB.Name = "btnOpcionb";
            this.btnOpcionB.Size = new System.Drawing.Size(157, 73);
            this.btnOpcionB.TabIndex = 3;
            this.btnOpcionB.Text = "button1";
            this.btnOpcionB.UseVisualStyleBackColor = true;
            // 
            // btnOpcionC
            // 
            this.btnOpcionC.Location = new System.Drawing.Point(347, 281);
            this.btnOpcionC.Name = "btnOpcionC";
            this.btnOpcionC.Size = new System.Drawing.Size(175, 73);
            this.btnOpcionC.TabIndex = 4;
            this.btnOpcionC.Text = "button1";
            this.btnOpcionC.UseVisualStyleBackColor = true;
            // 
            // btnOpcionD
            // 
            this.btnOpcionD.Location = new System.Drawing.Point(528, 281);
            this.btnOpcionD.Name = "btnOpcionD";
            this.btnOpcionD.Size = new System.Drawing.Size(175, 73);
            this.btnOpcionD.TabIndex = 5;
            this.btnOpcionD.Text = "button1";
            this.btnOpcionD.UseVisualStyleBackColor = true;
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Location = new System.Drawing.Point(613, 374);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(175, 73);
            this.btnSiguiente.TabIndex = 6;
            this.btnSiguiente.Text = "button1";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            // 
            // Texto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSiguiente);
            this.Controls.Add(this.btnOpcionD);
            this.Controls.Add(this.btnOpcionC);
            this.Controls.Add(this.btnOpcionB);
            this.Controls.Add(this.btnOpcionA);
            this.Controls.Add(this.lblEnunciado);
            this.Controls.Add(this.lblNumero);
            this.Name = "Texto";
            this.Text = "Kah00t";
            this.Load += new System.EventHandler(this.Texto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.Label lblEnunciado;
        private System.Windows.Forms.Button btnOpcionA;
        private System.Windows.Forms.Button btnOpcionB;
        private System.Windows.Forms.Button btnOpcionC;
        private System.Windows.Forms.Button btnOpcionD;
        private System.Windows.Forms.Button btnSiguiente;
    }
}