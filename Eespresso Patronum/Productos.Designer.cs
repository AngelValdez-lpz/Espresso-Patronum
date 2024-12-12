namespace Eespresso_Patronum
{
    partial class Productos
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
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbCategoria = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPrecio = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtRutaImagen = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.lbGrande = new System.Windows.Forms.Label();
            this.tbGrande = new System.Windows.Forms.TextBox();
            this.lbLetrero = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tbNombre
            // 
            this.tbNombre.Font = new System.Drawing.Font("MV Boli", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNombre.Location = new System.Drawing.Point(62, 46);
            this.tbNombre.Multiline = true;
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(183, 36);
            this.tbNombre.TabIndex = 0;
            this.tbNombre.TextChanged += new System.EventHandler(this.tbNombre_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MV Boli", 15.75F);
            this.label1.Location = new System.Drawing.Point(57, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre";
            // 
            // cbCategoria
            // 
            this.cbCategoria.Font = new System.Drawing.Font("MV Boli", 15.75F);
            this.cbCategoria.FormattingEnabled = true;
            this.cbCategoria.Items.AddRange(new object[] {
            "Caliente",
            "Rocas",
            "Frappé",
            "Tisanas y té",
            "Smoothies",
            "Batidos y Jugos",
            "Comidas",
            "Extras"});
            this.cbCategoria.Location = new System.Drawing.Point(62, 133);
            this.cbCategoria.Name = "cbCategoria";
            this.cbCategoria.Size = new System.Drawing.Size(183, 36);
            this.cbCategoria.TabIndex = 2;
            this.cbCategoria.SelectedIndexChanged += new System.EventHandler(this.cbCategoria_SelectedIndexChanged);
            this.cbCategoria.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbCategoria_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MV Boli", 15.75F);
            this.label2.Location = new System.Drawing.Point(57, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 28);
            this.label2.TabIndex = 3;
            this.label2.Text = "Categoria";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MV Boli", 15.75F);
            this.label4.Location = new System.Drawing.Point(57, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 28);
            this.label4.TabIndex = 7;
            this.label4.Text = "Precio";
            // 
            // tbPrecio
            // 
            this.tbPrecio.Font = new System.Drawing.Font("MV Boli", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPrecio.Location = new System.Drawing.Point(62, 232);
            this.tbPrecio.Multiline = true;
            this.tbPrecio.Name = "tbPrecio";
            this.tbPrecio.Size = new System.Drawing.Size(183, 36);
            this.tbPrecio.TabIndex = 6;
            this.tbPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPrecio_KeyPress);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(401, 197);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 56);
            this.button1.TabIndex = 8;
            this.button1.Text = "Cargar Imagen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnCargarImagen_Click);
            // 
            // txtRutaImagen
            // 
            this.txtRutaImagen.AutoSize = true;
            this.txtRutaImagen.Font = new System.Drawing.Font("MV Boli", 15.75F);
            this.txtRutaImagen.Location = new System.Drawing.Point(12, 590);
            this.txtRutaImagen.Name = "txtRutaImagen";
            this.txtRutaImagen.Size = new System.Drawing.Size(64, 28);
            this.txtRutaImagen.TabIndex = 9;
            this.txtRutaImagen.Text = "bytes";
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(401, 46);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(160, 123);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 10;
            this.pictureBox.TabStop = false;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(726, 559);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(160, 56);
            this.button2.TabIndex = 11;
            this.button2.Text = "Subir Producto";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lbGrande
            // 
            this.lbGrande.AutoSize = true;
            this.lbGrande.Font = new System.Drawing.Font("MV Boli", 15.75F);
            this.lbGrande.Location = new System.Drawing.Point(57, 293);
            this.lbGrande.Name = "lbGrande";
            this.lbGrande.Size = new System.Drawing.Size(146, 28);
            this.lbGrande.TabIndex = 13;
            this.lbGrande.Text = "Precio Grande";
            this.lbGrande.Visible = false;
            // 
            // tbGrande
            // 
            this.tbGrande.Font = new System.Drawing.Font("MV Boli", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGrande.Location = new System.Drawing.Point(62, 324);
            this.tbGrande.Multiline = true;
            this.tbGrande.Name = "tbGrande";
            this.tbGrande.Size = new System.Drawing.Size(183, 36);
            this.tbGrande.TabIndex = 12;
            this.tbGrande.Visible = false;
            this.tbGrande.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbGrande_KeyPress);
            // 
            // lbLetrero
            // 
            this.lbLetrero.AutoSize = true;
            this.lbLetrero.Font = new System.Drawing.Font("MV Boli", 15.75F);
            this.lbLetrero.Location = new System.Drawing.Point(247, 387);
            this.lbLetrero.Name = "lbLetrero";
            this.lbLetrero.Size = new System.Drawing.Size(0, 28);
            this.lbLetrero.TabIndex = 14;
            // 
            // Productos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(99)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(898, 627);
            this.Controls.Add(this.lbLetrero);
            this.Controls.Add(this.lbGrande);
            this.Controls.Add(this.tbGrande);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.txtRutaImagen);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbPrecio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbCategoria);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbNombre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Productos";
            this.Text = "Productos";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCategoria;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPrecio;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label txtRutaImagen;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lbGrande;
        private System.Windows.Forms.TextBox tbGrande;
        private System.Windows.Forms.Label lbLetrero;
    }
}