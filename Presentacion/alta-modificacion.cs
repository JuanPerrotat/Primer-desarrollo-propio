using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;
using System.Configuration;

namespace Presentacion
{
    public partial class alta_modificacion : Form
    {
        private Articulo articulo = null;
        private OpenFileDialog archivo = null;
        
        public alta_modificacion()
        {
            InitializeComponent();
        }
        public alta_modificacion(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = "Modificar artículo";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Está seguro de que desea cancelar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (resultado == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            articuloNegocio negocio = new articuloNegocio();
            try
            {
                if (articulo == null)
                    articulo = new Articulo();
    
                if (!decimal.TryParse(txtPrecio.Text, out decimal precio))
                {
                    MessageBox.Show("El precio debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                

                if(string.IsNullOrWhiteSpace(txtbCodigo.Text) 
                    || string.IsNullOrWhiteSpace(txtNombre.Text)
                    || string.IsNullOrWhiteSpace(txtDescripcion.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                articulo.Codigo = txtbCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.Precio = precio;
                articulo.ImagenUrl = txtImagen.Text;
                articulo.Categoria = (Categoria)cboCategoria.SelectedItem;
                articulo.Marca = (Marca)cboMarca.SelectedItem;



                if (articulo.Id != 0)
                {
                    try
                    {
                        negocio.modificar(articulo);
                        MessageBox.Show("El artículo ha sido modificado.", "Modificación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Datos incompletos o incorrectamente cargados. Por favor, completar los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
                else
                {
                    negocio.agregar(articulo);
                    MessageBox.Show("El nuevo artículo ha sido agregado", "Alta de artículo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (archivo != null && !(txtImagen.Text.ToUpper().Contains("HTTP")))
                {
                    string carpeta = carpetaImagenes();
                    string destino = Path.Combine(carpeta, archivo.SafeFileName);

                    File.Copy(archivo.FileName, destino, true);
                }
                   

                Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Por favor, revise que todos los datos estén completos y/o correctos.", "Error de carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void alta_modificacion_Load(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            MarcaNegocio negocio2 = new MarcaNegocio();

            try
            {
                cboCategoria.ValueMember = "Id";
                cboCategoria.DisplayMember = "Descripcion";
                cboCategoria.DataSource = negocio.listar();
                cboMarca.ValueMember = "Id";
                cboMarca.DisplayMember = "Descripcion";
                cboMarca.DataSource = negocio2.listar();


                if(articulo != null)
                {
                    txtbCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    txtDescripcion.Text = articulo.Descripcion;
                    txtPrecio.Text = articulo.Precio.ToString();
                    cboCategoria.SelectedValue = articulo.Categoria.Id;
                    cboMarca.SelectedValue = articulo.Marca.Id;
                    txtImagen.Text = articulo.ImagenUrl;
                    CargarImagen(articulo.ImagenUrl);
                  

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        public bool chequearImagen(string imagen)
        {
            if (string.IsNullOrWhiteSpace(imagen))
                return false;

            if (Uri.TryCreate(imagen, UriKind.Absolute, out Uri uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
                return true;
            

            if (File.Exists(imagen))
                return true;
            
            return false;
        }
        private void CargarImagen(string imagen)
        {
            string imagenError = "https://cdn-icons-png.flaticon.com/512/13434/13434972.png";
            try
            {
                if (!chequearImagen(imagen))
                {
                    pbImagenes.Load(imagenError);
                }

                pbImagenes.Load(imagen);
            }
            catch (Exception)
            {
                pbImagenes.Load(imagenError);
            }
        }

        private void txtImagen_Leave(object sender, EventArgs e)
        {
            CargarImagen(txtImagen.Text);
        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            archivo = new OpenFileDialog();
            archivo.Filter = "jpg|*.jpg;|png|*.png;|jpeg|*.jpeg";
            if(archivo.ShowDialog() == DialogResult.OK)
            {
                txtImagen.Text = archivo.FileName;
                CargarImagen(archivo.FileName);
            }
        }

        public string carpetaImagenes()
        {
            string ruta  = ConfigurationManager.AppSettings["imagenes-articulo"];
            if(!Directory.Exists(ruta))
                Directory.CreateDirectory(ruta);

            return ruta;
        }
        public bool validarCeldasTexto(string celda)
        {
            return !string.IsNullOrEmpty(celda);
        }
    }
}
