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
    public partial class Extras : UserControl
    {
        public string nombreExtra
        {
            get => lbExtra.Text;
            set => lbExtra.Text = value;
        }

        public decimal PrecioDecimal
        {
            get;
            set;
        }

        public int Cantidad
        {
            get => int.Parse(lblCantidad.Text);
            set => lblCantidad.Text = value.ToString();
        }

        public Extras()
        {
            InitializeComponent();
        }

        private void btnMas_Click(object sender, EventArgs e)
        {
            Cantidad++;
        }

        private void btnMenos_Click(object sender, EventArgs e)
        {
            if (Cantidad > 0)
                Cantidad--;
        }
    }
}
