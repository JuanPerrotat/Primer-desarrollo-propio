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
        private void CargarImagen(string imagen)
        {
            try
            {
                pbxImagenes.Load(imagen);
            }
            catch (Exception)
            {
                pbxImagenes.Load("https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png");
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
                pbxImagenes.Load(articuloSeleccionado.ImagenUrl);

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            
        }
    }
}
