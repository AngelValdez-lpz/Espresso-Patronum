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
        //holi h
        //lol
        private void CargarProductos()
          {
            int gola;
              //h
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

    }

}
