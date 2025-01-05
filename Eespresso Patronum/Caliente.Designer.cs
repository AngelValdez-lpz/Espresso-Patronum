namespace Eespresso_Patronum
{
    partial class Caliente
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flpCuenta = new System.Windows.Forms.FlowLayoutPanel();
            this.flpExtra = new System.Windows.Forms.FlowLayoutPanel();
            this.panelProductos = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.31519F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.68481F));
            this.tableLayoutPanel1.Controls.Add(this.flpCuenta, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.flpExtra, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelProductos, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.17007F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.82993F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(882, 588);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flpCuenta
            // 
            this.flpCuenta.AutoScroll = true;
            this.flpCuenta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpCuenta.Location = new System.Drawing.Point(632, 3);
            this.flpCuenta.Name = "flpCuenta";
            this.flpCuenta.Size = new System.Drawing.Size(247, 436);
            this.flpCuenta.TabIndex = 7;
            // 
            // flpExtra
            // 
            this.flpExtra.AutoScroll = true;
            this.flpExtra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpExtra.Location = new System.Drawing.Point(3, 445);
            this.flpExtra.Name = "flpExtra";
            this.flpExtra.Size = new System.Drawing.Size(623, 140);
            this.flpExtra.TabIndex = 4;
            // 
            // panelProductos
            // 
            this.panelProductos.AutoScroll = true;
            this.panelProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelProductos.Location = new System.Drawing.Point(3, 3);
            this.panelProductos.Name = "panelProductos";
            this.panelProductos.Size = new System.Drawing.Size(623, 436);
            this.panelProductos.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(632, 445);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 34);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Caliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 588);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Caliente";
            this.Text = "Caliente";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flpCuenta;
        private System.Windows.Forms.FlowLayoutPanel flpExtra;
        private System.Windows.Forms.FlowLayoutPanel panelProductos;
        private System.Windows.Forms.Button button1;
    }
}