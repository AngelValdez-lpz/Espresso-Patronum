using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eespresso_Patronum
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new Productos());
        }
        private Form formActual = null;

        public void abrirFormHijo(object formHijo)
        {
            if (formActual != null)
            {
                this.panel1.Controls.Remove(formActual);
            }

            Form fH = formHijo as Form;
            fH.TopLevel = false;
            fH.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(fH);
            this.panel1.Tag = fH;
            fH.Show();
            formActual = fH as Form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new Venta());
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
