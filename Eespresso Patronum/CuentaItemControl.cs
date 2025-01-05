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
    public partial class CuentaItemControl : UserControl
    {
        public string NombreProducto
        {
            get => lblProducto.Text;
            set => lblProducto.Text = value;
        }
        public string Extras
        {
            get => lblExtras.Text;
            set => lblExtras.Text = value;
        }
        public decimal PrecioTotal
        {
            get => decimal.Parse(lblPrecio.Text.Replace("$", ""));
            set => lblPrecio.Text = $"${value:F2}";
        }
        public CuentaItemControl()
        {
            InitializeComponent();
            btnEliminar.Click += (s, e) => this.Dispose();
        }
    }
}
