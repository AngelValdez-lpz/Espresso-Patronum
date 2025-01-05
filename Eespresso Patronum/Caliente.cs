using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Eespresso_Patronum
{
    public partial class Caliente : Form
    {
        public Caliente()
        {
            InitializeComponent();
            CargarProductos();
        }
        string nombreproducto = string.Empty;
        decimal precioproducto = decimal.Zero;
        private void CargarProductos()
          {
            
              List<Producto> productos = ObtenerProductos();

              // Limpiar el FlowLayoutPanel antes de agregar nuevos botones
              panelProductos.Controls.Clear();

              foreach (var producto in productos)
              {
                  // Crear un botón por cada producto
                  Button btnProducto = new Button
                  {
                      Width = 150, // Puedes ajustar el tamaño
                      Height = 200, // Ajusta según tu preferencia
                      Text = $"{producto.Nombre}\n{producto.Precio:C}",
                      Tag = producto, // Usamos el Tag para almacenar el objeto Producto
                      Image = producto.Imagen, // Establecer la imagen del producto
                      ImageAlign = ContentAlignment.MiddleCenter, // Alinear la imagen en el centro
                      TextAlign = ContentAlignment.BottomCenter, // Alinear el texto en la parte inferior
                      FlatStyle = FlatStyle.Flat,
                      BackgroundImageLayout = ImageLayout.Zoom
                  };

                  
                  btnProducto.Click += (sender, e) =>
                  {
                      MessageBox.Show($"Has seleccionao {producto.Nombre}!");
                      MostrarExtras(producto.ID_Producto);
                      nombreproducto = producto.Nombre.ToString();
                      precioproducto = Convert.ToDecimal(producto.Precio);
                  };


                  panelProductos.Controls.Add(btnProducto);
              }
          }

          private List<Producto> ObtenerProductos()
          {
              List<Producto> productos = new List<Producto>();

              string consulta = "SELECT ID_Producto, Nombre, Precio, Imagen FROM Producto WHERE Activo = 1 and Categoria = 'Caliente' and tamaño = 'Mediano' "; 
              using (SqlConnection conexion = new SqlConnection("Server=localhost;Database=EspressoPatronum;User Id=sa;Password=1234;"))
              {
                  conexion.Open();
                  using (SqlCommand comando = new SqlCommand(consulta, conexion))
                  {
                      using (SqlDataReader reader = comando.ExecuteReader())
                      {
                          while (reader.Read())
                          {
                              Producto producto = new Producto
                              {
                                  ID_Producto = (int)reader["ID_Producto"],
                                  Nombre = reader["Nombre"].ToString(),
                                  Precio = (decimal)reader["Precio"],
                                  Imagen = ByteArrayToImage((byte[])reader["Imagen"])
                              };
                              productos.Add(producto);
                          }
                      }
                  }
              }

              return productos;
          }

          private Image ByteArrayToImage(byte[] byteArray)
          {
              using (var ms = new System.IO.MemoryStream(byteArray))
              {
                  return Image.FromStream(ms);
              }
          }
          public class Producto
          {
              public int ID_Producto { get; set; }
              public string Nombre { get; set; }
              public decimal Precio { get; set; }
              public Image Imagen { get; set; } 
          }


        private void MostrarExtras(int productoID)
        {
            
            flpExtra.Controls.Clear();

            string consultaExtras = "SELECT id_Extra, nombre, precio FROM Extras where categoria = 'caliente'";

            using (SqlConnection conexion = new SqlConnection("Server=localhost;Database=EspressoPatronum;User Id=sa;Password=1234;"))
            {
                SqlDataAdapter da = new SqlDataAdapter(consultaExtras, conexion);
                DataTable dtExtras = new DataTable();
                da.Fill(dtExtras);

                foreach (DataRow row in dtExtras.Rows)
                {
                    Extras extraControl = new Extras
                    {
                        nombreExtra = row["Nombre"].ToString(),
                        PrecioDecimal = Convert.ToDecimal(row["Precio"]),
                        Cantidad = 0
                    };

                    flpExtra.Controls.Add(extraControl);
                }
            }
        }

        private void GuardarSeleccionExtras(string nombre, decimal precioProducto)
        {
            decimal total = 0;
            string nombreProducto = nombre;  // Ejemplo: nombre del producto seleccionado
            List<string> extrasSeleccionados = new List<string>();

            foreach (Control control in flpExtra.Controls)
            {
                if (control is Extras extraControl && extraControl.Cantidad > 0)
                {
                    extrasSeleccionados.Add($"{extraControl.nombreExtra} (x{extraControl.Cantidad})");
                    total += extraControl.Cantidad * extraControl.PrecioDecimal;
                }
            }

            total += precioProducto;  // Ejemplo: precio base del producto

            // Crear el ítem de cuenta
            var cuentaItem = new CuentaItemControl
            {
                NombreProducto = $"{nombreProducto}",
                Extras = $"{string.Join(", ",extrasSeleccionados)}",
                PrecioTotal = total
            };

            flpCuenta.Controls.Add(cuentaItem);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(nombreproducto != string.Empty)
            {
                GuardarSeleccionExtras(nombreproducto, precioproducto);
            }
        }
    }

}
