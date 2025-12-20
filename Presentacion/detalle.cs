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
using System.IO;

namespace Presentacion
{
    public partial class detalle : Form
    {
        private Articulo articulo;
        public detalle()
        {
            InitializeComponent();
        }
        public detalle(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
        }

        private void detalle_Load(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            MarcaNegocio negocio2 = new MarcaNegocio();

            try
            {
                txtCodigo.Text = articulo.Codigo;
                txtNombre.Text = articulo.Nombre;
                txtDescripcion.Text = articulo.Descripcion;
                txtPrecio.Text = articulo.Precio.ToString();
                txtMarca.Text = articulo.Marca.Descripcion;
                txtCategoria.Text = articulo.Categoria.Descripcion;
                txtImagen.Text = articulo.ImagenUrl;
                CargarImagen(articulo.ImagenUrl);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
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
    }
}
