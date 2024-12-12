namespace Eespresso_Patronum
{
    partial class Venta
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
            this.btnCaliente = new System.Windows.Forms.Button();
            this.btnRocas = new System.Windows.Forms.Button();
            this.btnFrapp = new System.Windows.Forms.Button();
            this.btnTe = new System.Windows.Forms.Button();
            this.btnComida = new System.Windows.Forms.Button();
            this.btnBatidos = new System.Windows.Forms.Button();
            this.btnSmoth = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCaliente
            // 
            this.btnCaliente.Location = new System.Drawing.Point(48, 32);
            this.btnCaliente.Name = "btnCaliente";
            this.btnCaliente.Size = new System.Drawing.Size(142, 91);
            this.btnCaliente.TabIndex = 0;
            this.btnCaliente.Text = "Caliente";
            this.btnCaliente.UseVisualStyleBackColor = true;
            this.btnCaliente.Click += new System.EventHandler(this.btnCaliente_Click);
            // 
            // btnRocas
            // 
            this.btnRocas.Location = new System.Drawing.Point(48, 129);
            this.btnRocas.Name = "btnRocas";
            this.btnRocas.Size = new System.Drawing.Size(142, 91);
            this.btnRocas.TabIndex = 1;
            this.btnRocas.Text = "Rocas";
            this.btnRocas.UseVisualStyleBackColor = true;
            this.btnRocas.Click += new System.EventHandler(this.btnRocas_Click);
            // 
            // btnFrapp
            // 
            this.btnFrapp.Location = new System.Drawing.Point(48, 226);
            this.btnFrapp.Name = "btnFrapp";
            this.btnFrapp.Size = new System.Drawing.Size(142, 91);
            this.btnFrapp.TabIndex = 2;
            this.btnFrapp.Text = "Frappé";
            this.btnFrapp.UseVisualStyleBackColor = true;
            // 
            // btnTe
            // 
            this.btnTe.Location = new System.Drawing.Point(329, 226);
            this.btnTe.Name = "btnTe";
            this.btnTe.Size = new System.Drawing.Size(142, 91);
            this.btnTe.TabIndex = 3;
            this.btnTe.Text = "Tisanas y té";
            this.btnTe.UseVisualStyleBackColor = true;
            // 
            // btnComida
            // 
            this.btnComida.Location = new System.Drawing.Point(48, 323);
            this.btnComida.Name = "btnComida";
            this.btnComida.Size = new System.Drawing.Size(423, 91);
            this.btnComida.TabIndex = 7;
            this.btnComida.Text = "Comidas";
            this.btnComida.UseVisualStyleBackColor = true;
            // 
            // btnBatidos
            // 
            this.btnBatidos.Location = new System.Drawing.Point(329, 136);
            this.btnBatidos.Name = "btnBatidos";
            this.btnBatidos.Size = new System.Drawing.Size(142, 91);
            this.btnBatidos.TabIndex = 5;
            this.btnBatidos.Text = "Batidos y jugos";
            this.btnBatidos.UseVisualStyleBackColor = true;
            // 
            // btnSmoth
            // 
            this.btnSmoth.Location = new System.Drawing.Point(329, 39);
            this.btnSmoth.Name = "btnSmoth";
            this.btnSmoth.Size = new System.Drawing.Size(142, 91);
            this.btnSmoth.TabIndex = 4;
            this.btnSmoth.Text = "Smoothies";
            this.btnSmoth.UseVisualStyleBackColor = true;
            // 
            // Venta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnComida);
            this.Controls.Add(this.btnBatidos);
            this.Controls.Add(this.btnSmoth);
            this.Controls.Add(this.btnTe);
            this.Controls.Add(this.btnFrapp);
            this.Controls.Add(this.btnRocas);
            this.Controls.Add(this.btnCaliente);
            this.Name = "Venta";
            this.Text = "Venta";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCaliente;
        private System.Windows.Forms.Button btnRocas;
        private System.Windows.Forms.Button btnFrapp;
        private System.Windows.Forms.Button btnTe;
        private System.Windows.Forms.Button btnComida;
        private System.Windows.Forms.Button btnBatidos;
        private System.Windows.Forms.Button btnSmoth;
    }
}