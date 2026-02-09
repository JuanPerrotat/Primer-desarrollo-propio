using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
            cboCampo.Items.Add("Descripción");
            cboCampo.Items.Add("Categoría");
            cboCampo.Items.Add("Marca");
            cboCampo.Items.Add("Precio");
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
                if (string.IsNullOrEmpty(imagen) || !chequearUrlImagen(imagen))
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
            dgvListaArticulos.Columns["Precio"].DefaultCellStyle.Format = "N2";
        }

        private void dgvListaArticulos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvListaArticulos.CurrentRow != null)
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
            cargar();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            Articulo seleccionado;


            if (dgvListaArticulos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un artículo para modificar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            seleccionado = (Articulo)dgvListaArticulos.CurrentRow.DataBoundItem;

            alta_modificacion modificar = new alta_modificacion(seleccionado);
            modificar.ShowDialog();
            cargar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            articuloNegocio negocio = new articuloNegocio();
            Articulo seleccionado;

            if (dgvListaArticulos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un artículo para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            try
            {
                DialogResult respuesta = MessageBox.Show("¿Está seguro de que desea eliminar permanentemente el artículo?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {

                    seleccionado = (Articulo)dgvListaArticulos.CurrentRow.DataBoundItem;
                    eliminar(seleccionado.Id);
                    MessageBox.Show("El artículo seleccionado ha sido eliminado correctamente.", "Advertencia");
                    cargar();

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.SetearConsulta("delete from ARTICULOS where Id = @Id");
                datos.SetearParametro("@Id", id);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> listaFiltrada;
            string filtro = txtFiltro.Text;
            if (filtro.Length >= 2)
                listaFiltrada = listaArticulos.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()) || x.Codigo.ToUpper().Contains(filtro.ToUpper()));

            else
                listaFiltrada = listaArticulos;

            dgvListaArticulos.DataSource = null;
            dgvListaArticulos.DataSource = listaFiltrada;
            OcultarColumnas();
        }

        public bool solotexto(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if (!char.IsLetter(caracter) && !char.IsWhiteSpace(caracter))
                    return false;
            }

            return true;
        }

        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cboCampo.SelectedItem.ToString();
            if (opcion == "Precio")
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Mayor a");
                cboCriterio.Items.Add("Menor a");
                cboCriterio.Items.Add("Igual a");
            }
            else
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Comienza con");
                cboCriterio.Items.Add("Termina con");
                cboCriterio.Items.Add("Contiene");
            }
        }

        private void btnBuscarFiltroAvanzado_Click(object sender, EventArgs e)
        {
            articuloNegocio negocio = new articuloNegocio();

            try
            {
                if (validarFiltro())
                    return;

                string campo = cboCampo.SelectedItem.ToString();
                string criterio = cboCriterio.SelectedItem.ToString();
                string filtro = txtFiltroAvanzado.Text;
                dgvListaArticulos.DataSource = negocio.filtrar(campo, criterio, filtro);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            Articulo seleccionado;

            if (dgvListaArticulos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un artículo para ver su detalle.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            seleccionado = (Articulo)dgvListaArticulos.CurrentRow.DataBoundItem;
            detalle verDetalle = new detalle(seleccionado);
            verDetalle.ShowDialog();
            cargar();
        }

        private bool validarFiltro()
        {
            if (cboCampo.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un campo para filtrar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }

            if (cboCriterio.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un criterio para filtrar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }

            if (string.IsNullOrEmpty(txtFiltroAvanzado.Text))
            {
                MessageBox.Show("Complete los datos de búsqueda para filtrar el artículo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }

            if (cboCampo.SelectedItem.ToString() == "Precio")
            {
                if (!soloNumeros(txtFiltroAvanzado.Text))
                {
                    MessageBox.Show("Ingrese solo números para filtrar por precio.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
                }
            }

            return false;
        }
        private bool soloNumeros(string cadena)
        {

            int comas = 0;

            foreach (char caracter in cadena)
            {
                if (!char.IsNumber(caracter))
                    return false;
            }
            return true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cargar();
        }
    }
}
