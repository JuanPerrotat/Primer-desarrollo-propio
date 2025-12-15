using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;

namespace Presentacion
{
    public partial class alta_modificacion : Form
    {
        private Articulo articulo = null;
        
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
            Articulo nuevoArticulo = new Articulo();
            articuloNegocio negocio = new articuloNegocio();
            try
            {
                if (articulo == null)
                    articulo = new Articulo();
                
                nuevoArticulo.Codigo =  txtbCodigo.Text;
                nuevoArticulo.Nombre = txtNombre.Text;
                nuevoArticulo.Descripcion = txtDescripcion.Text;
                nuevoArticulo.Precio = decimal.Parse(txtPrecio.Text);
                nuevoArticulo.Categoria = (Categoria)cboCategoria.SelectedItem;
                nuevoArticulo.Marca = (Marca)cboMarca.SelectedItem;
                nuevoArticulo.ImagenUrl = txtImagen.Text;

                if (articulo.Id != 0)
                {
                negocio.agregar(nuevoArticulo);
                MessageBox.Show("El nuevo artículo ha sido agregado.", "Advertencia");

                }
                

                    Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void alta_modificacion_Load(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            MarcaNegocio negocio2 = new MarcaNegocio();

            try
            {
                cboCategoria.DataSource = negocio.listar();
                cboCategoria.ValueMember = "Id";
                cboCategoria.DisplayMember = "Descripcion";
                cboCategoria.SelectedIndex = 0;
                cboMarca.DataSource = negocio2.listar();
                cboMarca.ValueMember = "Id";
                cboMarca.DisplayMember = "Descripcion";
                cboMarca.SelectedIndex = 0;

                if(articulo != null)
                {
                    txtbCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    txtDescripcion.Text = articulo.Descripcion;
                    txtPrecio.Text = articulo.Precio.ToString();
                    txtImagen.Text = articulo.ImagenUrl;
                    CargarImagen(articulo.ImagenUrl);
                  

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        public bool chequearUrlImagen(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult)
                 && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
        private void CargarImagen(string imagen)
        {
            string imagenError = "https://cdn-icons-png.flaticon.com/512/13434/13434972.png";
            try
            {
                if (string.IsNullOrEmpty(imagen) || !chequearUrlImagen(imagen))
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
    }
}
