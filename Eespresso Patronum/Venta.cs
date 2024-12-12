using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eespresso_Patronum
{
    public partial class Venta : Form
    {
        public Venta()
        {
            InitializeComponent();
        }

        private Form formActual = null;
        private void btnCaliente_Click(object sender, EventArgs e)
        {
            Form1 principal = (Form1)this.ParentForm; 
            principal.abrirFormHijo(new Caliente());
        }

        private void btnRocas_Click(object sender, EventArgs e)
        {
            Form1 principal = (Form1)this.ParentForm;
            principal.abrirFormHijo(new Rocas());
        }

    }
}
