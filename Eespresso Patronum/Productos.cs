using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace Eespresso_Patronum
{
    public partial class Productos : Form
    {
        public Productos()
        {
            InitializeComponent();
        }
        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            lbLetrero.Text = "";
            if (tbNombre.Text != string.Empty && tbPrecio.Text != string.Empty && cbCategoria.Text != string.Empty)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();

                openFileDialog.Filter = "Imagenes (*.jpg; *.jpeg; *.png; *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.Title = "Seleccionar una imagen";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string rutaImagen = openFileDialog.FileName;
                    txtRutaImagen.Text = rutaImagen;
                    pictureBox.Image = Image.FromFile(rutaImagen);
                    byte[] imagenBytes = File.ReadAllBytes(rutaImagen);
                    button2.Enabled = true;
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lbLetrero.Text = "";
            if(tbGrande.Visible == false)
            {
               GuardarImagenEnBD(tbNombre.Text, cbCategoria.Text, "Unico", Convert.ToInt32(tbPrecio.Text), true, txtRutaImagen.Text);
                limpiar();
            }
            else
            {
                if(tbGrande.Text != string.Empty)
                {
                    GuardarImagenEnBD(tbNombre.Text, cbCategoria.Text, "Mediano", Convert.ToInt32(tbPrecio.Text), true, txtRutaImagen.Text);
                    GuardarImagenEnBD(tbNombre.Text, cbCategoria.Text, "Grande", Convert.ToInt32(tbGrande.Text), true, txtRutaImagen.Text);
                    limpiar();
                    
                }
                else
                {
                    lbLetrero.Text = "Rellene los campos";
                }
            }
        }

        private string conection()
        {
            return $"Server=localhost;Database=EspressoPatronum;User Id=sa;Password=1234;";
        }

        public void GuardarImagenEnBD(string nombre, string categoria, string tamano, decimal precio, bool activo, string rutaImagen)
        {
            // Convertir la imagen a un arreglo de bytes
            byte[] imagenBytes = ConvertirImagenABytes(rutaImagen);

            // Consulta SQL para insertar los datos
            string consulta = "INSERT INTO Producto (Nombre, Categoria, Tamaño, Precio, Activo, Imagen) " +
                             "VALUES (@nombre, @categoria, @tamano, @precio, @activo, @imagen)";

            // Usar la conexión con parámetros
            using (SqlConnection conexion = new SqlConnection(conection()))
            {
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    // Agregar los parámetros a la consulta SQL
                    comando.Parameters.AddWithValue("@nombre", nombre);
                    comando.Parameters.AddWithValue("@categoria", categoria);
                    comando.Parameters.AddWithValue("@tamano", tamano);
                    comando.Parameters.AddWithValue("@precio", precio);
                    comando.Parameters.AddWithValue("@activo", activo);
                    comando.Parameters.AddWithValue("@imagen", imagenBytes);

                    // Abrir la conexión y ejecutar el comando
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
            }
        }
        public byte[] ConvertirImagenABytes(string rutaImagen)
        {
            return File.ReadAllBytes(rutaImagen);
        }

        private void cbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tbNombre.Text != string.Empty)
            {
                
            }
            if(cbCategoria.Text == "Tisanas y té" || cbCategoria.Text == "Comidas" || cbCategoria.Text == "Extras")
            {
                tbGrande.Visible = false;
                lbGrande.Visible = false;
            }
            else
            {
                tbGrande.Visible = true;
                lbGrande.Visible = true;
                label4.Text = "Precio mediano";
            }
        }

        private void cbCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void tbPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar == '.')
            {
                if (tbPrecio.Text.Contains(".") && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }

            if (e.KeyChar != '.' && tbPrecio.Text.Contains(".") && !char.IsControl(e.KeyChar))
            {
                int index = tbPrecio.Text.IndexOf('.');
                if (tbPrecio.Text.Length - index > 2)
                {
                    e.Handled = true;
                }
            }
        }

        private void tbGrande_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar == '.')
            {
                if (tbGrande.Text.Contains(".") && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }

            if (e.KeyChar != '.' && tbGrande.Text.Contains(".") && !char.IsControl(e.KeyChar))
            {
                int index = tbGrande.Text.IndexOf('.');
                if (tbGrande.Text.Length - index > 2)
                {
                    e.Handled = true;
                }
            }
        }

        private void tbNombre_TextChanged(object sender, EventArgs e)
        {
            lbLetrero.Text = "";
            button1.Enabled = true;
            if(cbCategoria.Text != string .Empty)
            {
                if (ProductoExiste(tbNombre.Text, cbCategoria.Text))
                {
                    lbLetrero.Text = "Ese nombre ya existe";
                    button1.Enabled = false;
                }
            }
        }

        private bool ProductoExiste(string nombreProducto, string categoria)
        {
            bool existe = false;

            using (SqlConnection connection = new SqlConnection(conection()))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(1) FROM producto WHERE Nombre = @nombre and Categoria = @categoria";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nombre", nombreProducto);
                        command.Parameters.AddWithValue("@categoria", categoria);
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        existe = count > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al conectar con la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return existe;
        }
        private void limpiar()
        {
            tbNombre.Text = string.Empty;
            cbCategoria.Text = string.Empty;
            tbPrecio.Text = string.Empty;
            label4.Text = "Precio";
            lbGrande.Visible = false;
            tbGrande.Visible = false;
            tbGrande.Text = string.Empty;
            button2.Enabled = false;
            pictureBox.Dispose();
            pictureBox.Image = null;
        }
    }
}

    

