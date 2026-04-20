namespace ProyectoKahootXD
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_Historia = new System.Windows.Forms.Button();
            this.button_Deportes = new System.Windows.Forms.Button();
            this.button_Musica = new System.Windows.Forms.Button();
            this.button_Ciencia = new System.Windows.Forms.Button();
            this.button_Cine = new System.Windows.Forms.Button();
            this.button_Geografia = new System.Windows.Forms.Button();
            this.button_Computacion = new System.Windows.Forms.Button();
            this.picComputacion = new System.Windows.Forms.PictureBox();
            this.picGeografia = new System.Windows.Forms.PictureBox();
            this.picCine = new System.Windows.Forms.PictureBox();
            this.picCiencia = new System.Windows.Forms.PictureBox();
            this.picDeportes = new System.Windows.Forms.PictureBox();
            this.picHistoria = new System.Windows.Forms.PictureBox();
            this.picMusica = new System.Windows.Forms.PictureBox();
            this.picBanner = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picComputacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGeografia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCiencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDeportes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHistoria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMusica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBanner)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(170, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(463, 43);
            this.label1.TabIndex = 0;
            this.label1.Text = "¡Bienvenido a nuestro juego!";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(226, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(319, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Por favor, elige un tema de preguntas:";
            // 
            // button_Historia
            // 
            this.button_Historia.BackColor = System.Drawing.Color.Red;
            this.button_Historia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Historia.ForeColor = System.Drawing.Color.White;
            this.button_Historia.Location = new System.Drawing.Point(45, 196);
            this.button_Historia.Name = "button_Historia";
            this.button_Historia.Size = new System.Drawing.Size(128, 54);
            this.button_Historia.TabIndex = 2;
            this.button_Historia.Text = "Historia";
            this.button_Historia.UseVisualStyleBackColor = false;
            this.button_Historia.Visible = false;
            this.button_Historia.Click += new System.EventHandler(this.button_Historia_Click);
            // 
            // button_Deportes
            // 
            this.button_Deportes.BackColor = System.Drawing.Color.Gold;
            this.button_Deportes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Deportes.ForeColor = System.Drawing.Color.White;
            this.button_Deportes.Location = new System.Drawing.Point(417, 196);
            this.button_Deportes.Name = "button_Deportes";
            this.button_Deportes.Size = new System.Drawing.Size(128, 54);
            this.button_Deportes.TabIndex = 4;
            this.button_Deportes.Text = "Deportes";
            this.button_Deportes.UseVisualStyleBackColor = false;
            this.button_Deportes.Visible = false;
            this.button_Deportes.Click += new System.EventHandler(this.button_Deportes_Click);
            // 
            // button_Musica
            // 
            this.button_Musica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button_Musica.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Musica.ForeColor = System.Drawing.Color.White;
            this.button_Musica.Location = new System.Drawing.Point(230, 196);
            this.button_Musica.Name = "button_Musica";
            this.button_Musica.Size = new System.Drawing.Size(128, 54);
            this.button_Musica.TabIndex = 3;
            this.button_Musica.Text = "Musica";
            this.button_Musica.UseVisualStyleBackColor = false;
            this.button_Musica.Visible = false;
            this.button_Musica.Click += new System.EventHandler(this.button_Musica_Click);
            // 
            // button_Ciencia
            // 
            this.button_Ciencia.BackColor = System.Drawing.Color.LimeGreen;
            this.button_Ciencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Ciencia.ForeColor = System.Drawing.Color.White;
            this.button_Ciencia.Location = new System.Drawing.Point(609, 196);
            this.button_Ciencia.Name = "button_Ciencia";
            this.button_Ciencia.Size = new System.Drawing.Size(128, 54);
            this.button_Ciencia.TabIndex = 5;
            this.button_Ciencia.Text = "Ciencia";
            this.button_Ciencia.UseVisualStyleBackColor = false;
            this.button_Ciencia.Visible = false;
            this.button_Ciencia.Click += new System.EventHandler(this.button_Ciencia_Click);
            // 
            // button_Cine
            // 
            this.button_Cine.BackColor = System.Drawing.Color.DarkTurquoise;
            this.button_Cine.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Cine.ForeColor = System.Drawing.Color.White;
            this.button_Cine.Location = new System.Drawing.Point(133, 293);
            this.button_Cine.Name = "button_Cine";
            this.button_Cine.Size = new System.Drawing.Size(128, 54);
            this.button_Cine.TabIndex = 6;
            this.button_Cine.Text = "Cine";
            this.button_Cine.UseVisualStyleBackColor = false;
            this.button_Cine.Visible = false;
            this.button_Cine.Click += new System.EventHandler(this.button_Cine_Click);
            // 
            // button_Geografia
            // 
            this.button_Geografia.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button_Geografia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Geografia.ForeColor = System.Drawing.Color.White;
            this.button_Geografia.Location = new System.Drawing.Point(322, 293);
            this.button_Geografia.Name = "button_Geografia";
            this.button_Geografia.Size = new System.Drawing.Size(128, 54);
            this.button_Geografia.TabIndex = 7;
            this.button_Geografia.Text = "Geografia";
            this.button_Geografia.UseVisualStyleBackColor = false;
            this.button_Geografia.Visible = false;
            this.button_Geografia.Click += new System.EventHandler(this.button_Geografia_Click);
            // 
            // button_Computacion
            // 
            this.button_Computacion.BackColor = System.Drawing.Color.HotPink;
            this.button_Computacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Computacion.ForeColor = System.Drawing.Color.White;
            this.button_Computacion.Location = new System.Drawing.Point(505, 293);
            this.button_Computacion.Name = "button_Computacion";
            this.button_Computacion.Size = new System.Drawing.Size(128, 54);
            this.button_Computacion.TabIndex = 8;
            this.button_Computacion.Text = "Computacion";
            this.button_Computacion.UseVisualStyleBackColor = false;
            this.button_Computacion.Visible = false;
            this.button_Computacion.Click += new System.EventHandler(this.button_Computacion_Click);
            // 
            // picComputacion
            // 
            this.picComputacion.Image = ((System.Drawing.Image)(resources.GetObject("picComputacion.Image")));
            this.picComputacion.InitialImage = global::ProyectoKahootXD.Properties.Resources.computacion;
            this.picComputacion.Location = new System.Drawing.Point(488, 278);
            this.picComputacion.Name = "picComputacion";
            this.picComputacion.Size = new System.Drawing.Size(162, 103);
            this.picComputacion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picComputacion.TabIndex = 16;
            this.picComputacion.TabStop = false;
            this.picComputacion.Click += new System.EventHandler(this.picComputacion_Click);
            this.picComputacion.MouseEnter += new System.EventHandler(this.picComputacion_MouseEnter);
            this.picComputacion.MouseLeave += new System.EventHandler(this.picComputacion_MouseLeave);
            // 
            // picGeografia
            // 
            this.picGeografia.Image = ((System.Drawing.Image)(resources.GetObject("picGeografia.Image")));
            this.picGeografia.InitialImage = ((System.Drawing.Image)(resources.GetObject("picGeografia.InitialImage")));
            this.picGeografia.Location = new System.Drawing.Point(322, 278);
            this.picGeografia.Name = "picGeografia";
            this.picGeografia.Size = new System.Drawing.Size(140, 103);
            this.picGeografia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picGeografia.TabIndex = 15;
            this.picGeografia.TabStop = false;
            this.picGeografia.Click += new System.EventHandler(this.picGeografia_Click);
            this.picGeografia.MouseEnter += new System.EventHandler(this.picGeografia_MouseEnter);
            this.picGeografia.MouseLeave += new System.EventHandler(this.picGeografia_MouseLeave);
            // 
            // picCine
            // 
            this.picCine.Image = ((System.Drawing.Image)(resources.GetObject("picCine.Image")));
            this.picCine.InitialImage = ((System.Drawing.Image)(resources.GetObject("picCine.InitialImage")));
            this.picCine.Location = new System.Drawing.Point(133, 269);
            this.picCine.Name = "picCine";
            this.picCine.Size = new System.Drawing.Size(134, 118);
            this.picCine.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCine.TabIndex = 14;
            this.picCine.TabStop = false;
            this.picCine.Click += new System.EventHandler(this.picCine_Click);
            this.picCine.MouseEnter += new System.EventHandler(this.picCine_MouseEnter);
            this.picCine.MouseLeave += new System.EventHandler(this.picCine_MouseLeave);
            // 
            // picCiencia
            // 
            this.picCiencia.Image = ((System.Drawing.Image)(resources.GetObject("picCiencia.Image")));
            this.picCiencia.InitialImage = ((System.Drawing.Image)(resources.GetObject("picCiencia.InitialImage")));
            this.picCiencia.Location = new System.Drawing.Point(588, 163);
            this.picCiencia.Name = "picCiencia";
            this.picCiencia.Size = new System.Drawing.Size(149, 94);
            this.picCiencia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCiencia.TabIndex = 13;
            this.picCiencia.TabStop = false;
            this.picCiencia.Click += new System.EventHandler(this.picCiencia_Click);
            this.picCiencia.MouseEnter += new System.EventHandler(this.picCiencia_MouseEnter);
            this.picCiencia.MouseLeave += new System.EventHandler(this.picCiencia_MouseLeave);
            // 
            // picDeportes
            // 
            this.picDeportes.Image = ((System.Drawing.Image)(resources.GetObject("picDeportes.Image")));
            this.picDeportes.InitialImage = ((System.Drawing.Image)(resources.GetObject("picDeportes.InitialImage")));
            this.picDeportes.Location = new System.Drawing.Point(407, 168);
            this.picDeportes.Name = "picDeportes";
            this.picDeportes.Size = new System.Drawing.Size(150, 95);
            this.picDeportes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picDeportes.TabIndex = 12;
            this.picDeportes.TabStop = false;
            this.picDeportes.Click += new System.EventHandler(this.picDeportes_Click);
            this.picDeportes.MouseEnter += new System.EventHandler(this.picDeportes_MouseEnter);
            this.picDeportes.MouseLeave += new System.EventHandler(this.picDeportes_MouseLeave);
            // 
            // picHistoria
            // 
            this.picHistoria.Image = global::ProyectoKahootXD.Properties.Resources.historia1;
            this.picHistoria.InitialImage = global::ProyectoKahootXD.Properties.Resources.historia1;
            this.picHistoria.Location = new System.Drawing.Point(40, 182);
            this.picHistoria.Name = "picHistoria";
            this.picHistoria.Size = new System.Drawing.Size(133, 80);
            this.picHistoria.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picHistoria.TabIndex = 11;
            this.picHistoria.TabStop = false;
            this.picHistoria.Click += new System.EventHandler(this.picHistoria_Click);
            this.picHistoria.MouseEnter += new System.EventHandler(this.picHistoria_MouseEnter);
            this.picHistoria.MouseLeave += new System.EventHandler(this.picHistoria_MouseLeave);
            // 
            // picMusica
            // 
            this.picMusica.Image = ((System.Drawing.Image)(resources.GetObject("picMusica.Image")));
            this.picMusica.InitialImage = ((System.Drawing.Image)(resources.GetObject("picMusica.InitialImage")));
            this.picMusica.Location = new System.Drawing.Point(211, 163);
            this.picMusica.Name = "picMusica";
            this.picMusica.Size = new System.Drawing.Size(159, 100);
            this.picMusica.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMusica.TabIndex = 10;
            this.picMusica.TabStop = false;
            this.picMusica.Click += new System.EventHandler(this.picMusica_Click);
            this.picMusica.MouseEnter += new System.EventHandler(this.picMusica_MouseEnter);
            this.picMusica.MouseLeave += new System.EventHandler(this.picMusica_MouseLeave);
            // 
            // picBanner
            // 
            this.picBanner.Location = new System.Drawing.Point(178, 12);
            this.picBanner.Name = "picBanner";
            this.picBanner.Size = new System.Drawing.Size(472, 134);
            this.picBanner.TabIndex = 9;
            this.picBanner.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.picComputacion);
            this.Controls.Add(this.picGeografia);
            this.Controls.Add(this.picCine);
            this.Controls.Add(this.picCiencia);
            this.Controls.Add(this.picDeportes);
            this.Controls.Add(this.picHistoria);
            this.Controls.Add(this.picMusica);
            this.Controls.Add(this.picBanner);
            this.Controls.Add(this.button_Computacion);
            this.Controls.Add(this.button_Geografia);
            this.Controls.Add(this.button_Cine);
            this.Controls.Add(this.button_Ciencia);
            this.Controls.Add(this.button_Musica);
            this.Controls.Add(this.button_Deportes);
            this.Controls.Add(this.button_Historia);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Kah00t";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picComputacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGeografia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCiencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDeportes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHistoria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMusica)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBanner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_Historia;
        private System.Windows.Forms.Button button_Deportes;
        private System.Windows.Forms.Button button_Musica;
        private System.Windows.Forms.Button button_Ciencia;
        private System.Windows.Forms.Button button_Cine;
        private System.Windows.Forms.Button button_Geografia;
        private System.Windows.Forms.Button button_Computacion;
        private System.Windows.Forms.PictureBox picBanner;
        private System.Windows.Forms.PictureBox picMusica;
        private System.Windows.Forms.PictureBox picHistoria;
        private System.Windows.Forms.PictureBox picDeportes;
        private System.Windows.Forms.PictureBox picCiencia;
        private System.Windows.Forms.PictureBox picCine;
        private System.Windows.Forms.PictureBox picGeografia;
        private System.Windows.Forms.PictureBox picComputacion;
    }
}