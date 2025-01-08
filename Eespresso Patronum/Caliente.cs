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
        public string categorias = string.Empty;
        public string tamañob = string.Empty;
        public Caliente()
        {
            InitializeComponent();
            cargarmenu();
        }
        string nombreproducto = string.Empty, nombreLeche = string.Empty;
        decimal precioproducto = decimal.Zero,precioleche = decimal.Zero;
        int idproducto = 0, preciotam = 0;
        private void CargarProductos(string categoria)
          {
            
              List<Producto> productos = ObtenerProductos(categoria);

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
                      nombreproducto = producto.Nombre.ToString();
                      precioproducto = Convert.ToDecimal(producto.Precio);
                      idproducto = Convert.ToInt32(producto.ID_Producto);
                      if (categorias == "Comida" || categorias == "tisanas")
                      {
                          CargarLeche(categoria);
                      }
                      else
                      {
                          cargartamaños();
                      }
                      
                  };


                  panelProductos.Controls.Add(btnProducto);
              }
          }

        private void cargartamaños()
        {
            panelProductos.Controls.Clear();
            Button btnmed = new Button
            {
                Width = 200,
                Height = 200,
                Text = "Mediano",
                TextAlign = ContentAlignment.MiddleCenter,
                FlatStyle = FlatStyle.Flat
            };

            btnmed.Click += (sender, e) =>
            {
                preciotam = 0;
                tamañob = "Mediano";
                CargarLeche(categorias);
            };
            panelProductos.Controls.Add(btnmed);
            Button btngran = new Button
            {
                Width = 200,
                Height = 200,
                Text = "Grande +$5",
                TextAlign = ContentAlignment.MiddleCenter,
                FlatStyle = FlatStyle.Flat
            };
            btngran.Click += (sender, e) =>
            {
                preciotam = 5;
                tamañob = "Grande";
                CargarLeche(categorias);
            };
            panelProductos.Controls.Add(btngran);


        }

        private void CargarLeche(string categoria)
        {

            List<Leche> leches = ObtenerLeche();

            // Limpiar el FlowLayoutPanel antes de agregar nuevos botones
            panelProductos.Controls.Clear();

            foreach (var leche in leches)
            {
                // Crear un botón por cada producto
                Button btnProducto = new Button
                {
                    Width = 150, // Puedes ajustar el tamaño
                    Height = 200, // Ajusta según tu preferencia
                    Text = $"{leche.Nombre}\n{leche.precio:C}",
                    Tag = leche, // Usamos el Tag para almacenar el objeto Producto
                    //Image = producto.Imagen, // Establecer la imagen del producto
                   //ImageAlign = ContentAlignment.MiddleCenter, // Alinear la imagen en el centro
                    TextAlign = ContentAlignment.BottomCenter, // Alinear el texto en la parte inferior
                    FlatStyle = FlatStyle.Flat,
                    BackgroundImageLayout = ImageLayout.Zoom
                };


                btnProducto.Click += (sender, e) =>
                {
                    nombreLeche = leche.Nombre.ToString();
                    precioleche = Convert.ToDecimal(leche.precio);
                    MostrarExtras(categoria);
                };


                panelProductos.Controls.Add(btnProducto);
            }
        }

       
        private List<Producto> ObtenerProductos(string categoria)
          {
              List<Producto> productos = new List<Producto>();

              string consulta = $"SELECT ID_Producto, Nombre, Precio, Imagen FROM Producto WHERE Activo = 1 and Categoria = '{categoria}' and tamaño = 'Mediano' "; 
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
         private List<Leche> ObtenerLeche()
          {
              List<Leche> leches = new List<Leche>();

              string consulta = "select id_Extra, nombre, precio from Extras where categoria = 'leche' and activo = '1' "; 
              using (SqlConnection conexion = new SqlConnection("Server=localhost;Database=EspressoPatronum;User Id=sa;Password=1234;"))
              {
                  conexion.Open();
                  using (SqlCommand comando = new SqlCommand(consulta, conexion))
                  {
                      using (SqlDataReader reader = comando.ExecuteReader())
                      {
                          while (reader.Read())
                          {
                              Leche leche = new Leche
                              {
                                  id_extra = (int)reader["id_Extra"],
                                  Nombre = reader["nombre"].ToString(),
                                  precio = (decimal)reader["precio"],
                                 // Imagen = ByteArrayToImage((byte[])reader["Imagen"])
                              };
                              leches.Add(leche);
                          }
                      }
                  }
              }

              return leches;
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

        public class Leche
        {
            public int id_extra { get; set; }
            public string Nombre { get; set; }
            public decimal precio { get; set; }
            //public Image Imagen { get; set; }
        }
        public class tamaño
        {
            public string Nombre { get; set; }
            public string precio { get; set; }

        }


        private void MostrarExtras(string categoria)
        {
            
            flpExtra.Controls.Clear();

            string consultaExtras = $"SELECT id_Extra, nombre, precio FROM Extras where categoria = '{categoria}'";

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
            total += precioleche;
            total += preciotam;
            // Crear el ítem de cuenta
            var cuentaItem = new CuentaItemControl
            {
                NombreProducto = $"{nombreProducto} {tamañob} {categorias}",
                Extras = $"{string.Join(", ",extrasSeleccionados)} con leche {nombreLeche}.",
                PrecioTotal = total
            };
            
            flpCuenta.Controls.Add(cuentaItem);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            limpiar();
            cargarmenu();
            flpExtra.Controls.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(nombreproducto != string.Empty && nombreLeche != string.Empty)
            {
                GuardarSeleccionExtras(nombreproducto, precioproducto);
                limpiar();
                cargarmenu();
                flpExtra.Controls.Clear();

            }
        }
        private void limpiar()
        {
            nombreproducto = string.Empty;
            nombreLeche = string.Empty;
            precioproducto = decimal.Zero;
            precioleche = decimal.Zero;
            idproducto = 0;
            preciotam = 0;
            string categorias = string.Empty;
            string tamañob = string.Empty;
        }

        private void cargarmenu()
        {
            Color colorHoverBoton = Color.FromArgb(220, 200, 180);
            Color colorFondoBoton = Color.FromArgb(255, 248, 225); // Beige claro (#FFF8E1)
            Color colorTextoBoton = Color.FromArgb(78, 52, 46);    // Marrón oscuro (#4E342E)
            Color colorBordeBoton = Color.FromArgb(255, 193, 7);   // Mostaza (#FFC107)

            panelProductos.Controls.Clear();
            Button btnCaliente = new Button
            {
                Width = 290,
                Height = 90,
                Text = "Caliente",
                TextAlign = ContentAlignment.TopLeft,
                Font = new Font("Arial", 12, FontStyle.Bold), // Fuente Arial, tamaño 12, en negrita
                ForeColor = colorTextoBoton, // Cambia el color del texto
                BackColor = colorFondoBoton, // Cambia el color de fondo del botón
                Image = (Image)Properties.Resources.taza_caliente__2_,
                ImageAlign = ContentAlignment.BottomRight,
                TextImageRelation = TextImageRelation.ImageAboveText,
                FlatStyle = FlatStyle.Flat
            };

            btnCaliente.Click += (sender, e) =>
            {
                categorias = "Caliente";
                CargarProductos(categorias);
            };

            btnCaliente.MouseEnter += (s, e) =>
            {
                btnCaliente.BackColor = colorHoverBoton;
                btnCaliente.FlatAppearance.BorderSize = 3;
            };
            btnCaliente.MouseLeave += (s, e) =>
            {
                btnCaliente.BackColor = colorFondoBoton;
                btnCaliente.FlatAppearance.BorderSize = 2;
            };
            panelProductos.Controls.Add(btnCaliente);


            Button btnRocas = new Button
            {
                Width = 290,
                Height = 90,
                Text = "Rocas",
                TextAlign = ContentAlignment.TopLeft,
                Font = new Font("Arial", 12, FontStyle.Bold), // Fuente Arial, tamaño 12, en negrita
                ForeColor = colorTextoBoton, // Cambia el color del texto
                BackColor = colorFondoBoton, // Cambia el color de fondo del botón
                Image = (Image)Properties.Resources.Rocas,
                ImageAlign = ContentAlignment.BottomRight,
                TextImageRelation = TextImageRelation.ImageAboveText,
                FlatStyle = FlatStyle.Flat
            };
            btnRocas.Click += (sender, e) =>
            {
                categorias = "Rocas";
                CargarProductos(categorias);
            };
            panelProductos.Controls.Add(btnRocas);


            Button btnFrappe = new Button
            {
                Width = 290,
                Height = 90,
                Text = "Frappé",
                TextAlign = ContentAlignment.TopLeft,
                Font = new Font("Arial", 12, FontStyle.Bold), // Fuente Arial, tamaño 12, en negrita
                ForeColor = colorTextoBoton, // Cambia el color del texto
                BackColor = colorFondoBoton, // Cambia el color de fondo del botón
                Image = (Image)Properties.Resources.frappe,
                ImageAlign = ContentAlignment.BottomRight,
                TextImageRelation = TextImageRelation.ImageAboveText,
                FlatStyle = FlatStyle.Flat
            };
            btnFrappe.Click += (sender, e) =>
            {
                categorias = "Frappé";
                CargarProductos(categorias);
            };
            panelProductos.Controls.Add(btnFrappe);

            Button btnSmoothies = new Button
            {
                Width = 290,
                Height = 90,
                Text = "Smoothies",
                TextAlign = ContentAlignment.TopLeft,
                Font = new Font("Arial", 12, FontStyle.Bold), // Fuente Arial, tamaño 12, en negrita
                ForeColor = colorTextoBoton, // Cambia el color del texto
                BackColor = colorFondoBoton, // Cambia el color de fondo del botón
                Image = (Image)Properties.Resources.smoothie,
                ImageAlign = ContentAlignment.BottomRight,
                TextImageRelation = TextImageRelation.ImageAboveText,
                FlatStyle = FlatStyle.Flat
            };
            btnSmoothies.Click += (sender, e) =>
            {
                categorias = "Smoothies";
                CargarProductos(categorias);
            };
            panelProductos.Controls.Add(btnSmoothies);

            Button btnBatidos = new Button
            {
                Width = 290,
                Height = 90,
                Text = "Batidos y Jugos",
                TextAlign = ContentAlignment.TopLeft,
                Font = new Font("Arial", 12, FontStyle.Bold), // Fuente Arial, tamaño 12, en negrita
                ForeColor = colorTextoBoton, // Cambia el color del texto
                BackColor = colorFondoBoton, // Cambia el color de fondo del botón
                Image = (Image)Properties.Resources.jugo,
                ImageAlign = ContentAlignment.BottomRight,
                TextImageRelation = TextImageRelation.ImageAboveText,
                FlatStyle = FlatStyle.Flat
            };
            btnBatidos.Click += (sender, e) =>
            {
                categorias = "Batidos y Jugos";
                CargarProductos(categorias);
            };
            panelProductos.Controls.Add(btnBatidos);

            Button btntizanas = new Button
            {
                Width = 290,
                Height = 90,
                Text = "Tisanas y té",
                TextAlign = ContentAlignment.TopLeft,
                Font = new Font("Arial", 12, FontStyle.Bold), // Fuente Arial, tamaño 12, en negrita
                ForeColor = colorTextoBoton, // Cambia el color del texto
                BackColor = colorFondoBoton, // Cambia el color de fondo del botón
                Image = (Image)Properties.Resources.tisana,
                ImageAlign = ContentAlignment.BottomRight,
                TextImageRelation = TextImageRelation.ImageAboveText,
                FlatStyle = FlatStyle.Flat
            };
            btntizanas.Click += (sender, e) =>
            {
                categorias = "Tisanas y té";
                CargarProductos(categorias);
            };
            panelProductos.Controls.Add(btntizanas);

            Button btnComidas = new Button
            {
                Width = 590,
                Height = 90,
                Text = "Comidas",
                TextAlign = ContentAlignment.TopLeft,
                Font = new Font("Arial", 12, FontStyle.Bold), // Fuente Arial, tamaño 12, en negrita
                ForeColor = colorTextoBoton, // Cambia el color del texto
                BackColor = colorFondoBoton, // Cambia el color de fondo del botón
                Image = (Image)Properties.Resources.comida,
                ImageAlign = ContentAlignment.BottomRight,
                TextImageRelation = TextImageRelation.ImageAboveText,
                FlatStyle = FlatStyle.Flat
            };
            btnComidas.Click += (sender, e) =>
            {
                categorias = "Comidas";
                CargarProductos(categorias);
            };
            panelProductos.Controls.Add(btnComidas);
        }
        

    }

}
