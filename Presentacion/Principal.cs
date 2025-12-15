using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace Presentacion
{
    public partial class Principal : Form
    {
        private List<Articulo> listaArticulos;
        private List<Marca> listaMarcas;
        private List<Categoria> listaCategorias;
        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            cargar();

        }
        private void cargar()
        {

            articuloNegocio negocio = new articuloNegocio();
            try
            {
                listaArticulos = negocio.listar();
                dgvListaArticulos.DataSource = listaArticulos;
                OcultarColumnas();
                CargarImagen(listaArticulos[0].ImagenUrl);

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
                if(string.IsNullOrEmpty(imagen) || !chequearUrlImagen(imagen))
                {
                    pbxImagenes.Load(imagenError);
                }

                pbxImagenes.Load(imagen);
            }
            catch (Exception)
            {
                pbxImagenes.Load(imagenError);
            }
        }



        private void OcultarColumnas()
        {
            dgvListaArticulos.Columns["ImagenUrl"].Visible = false;
            dgvListaArticulos.Columns["Id"].Visible = false;
        }

        private void dgvListaArticulos_SelectionChanged(object sender, EventArgs e)
        {

            try
            {
            
                if(dgvListaArticulos != null)
                {
                Articulo articuloSeleccionado = (Articulo)dgvListaArticulos.CurrentRow.DataBoundItem;
                CargarImagen(articuloSeleccionado.ImagenUrl);

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
           alta_modificacion alta = new alta_modificacion();
            alta.ShowDialog();
            
        }
    }
}
