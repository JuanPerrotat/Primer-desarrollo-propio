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
            articuloNegocio negocio = new articuloNegocio();
            try
            {
                if (articulo == null)
                    articulo = new Articulo();
                
                articulo.Codigo =  txtbCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.Precio = decimal.Parse(txtPrecio.Text);
                articulo.ImagenUrl = txtImagen.Text;
                articulo.Categoria = (Categoria)cboCategoria.SelectedItem;
                articulo.Marca = (Marca)cboMarca.SelectedItem;

                if (articulo.Id != 0)
                {
                    negocio.modificar(articulo);
                    MessageBox.Show("El artículo ha sido modificado.", "Modificación");
                }
                else
                {
                    negocio.agregar(articulo);
                    MessageBox.Show("El nuevo artículo ha sido agregado", "Creación");
                }


                    Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Por favor, revise que todos los datos estén completos.", "Error de carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                cboMarca.DataSource = negocio2.listar();
                cboMarca.ValueMember = "Id";
                cboMarca.DisplayMember = "Descripcion";


                if(articulo != null)
                {
                    txtbCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    txtDescripcion.Text = articulo.Descripcion;
                    txtPrecio.Text = articulo.Precio.ToString();
                    txtImagen.Text = articulo.ImagenUrl;
                    CargarImagen(articulo.ImagenUrl);
                    cboMarca.SelectedValue = articulo.Marca.Id;
                    cboCategoria.SelectedValue = articulo.Categoria.Id;
                  

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

        private void txtImagen_Leave(object sender, EventArgs e)
        {
            CargarImagen(txtImagen.Text);
        }
    }
}
