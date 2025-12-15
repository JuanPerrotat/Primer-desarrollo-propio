using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;

namespace negocio
{
    public class articuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("select A. Id, A.Codigo, A.Nombre, A.Descripcion, C.Descripcion as Categoria, M.Descripcion as Marca, A.ImagenUrl, A.Precio  " +
                    "from ARTICULOS A, CATEGORIAS C, Marcas M where A.IdCategoria = C.Id and A.IdMarca = M.Id");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                   Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["Id"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["Id"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    lista.Add(aux);

                }
                return lista;
            }
            
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }

        }
        public void agregar(Articulo nuevo) 
        {
            AccesoDatos escritura = new AccesoDatos();
            try
            {
                escritura.SetearConsulta("insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) " +
                    "values (@Codigo, @Nombre, @Descripcion, @Marca, @Categoria, @ImagenUrl, @Precio)");
                escritura.SetearParametro("@Codigo", nuevo.Codigo);
                escritura.SetearParametro("@Nombre", nuevo.Nombre);
                escritura.SetearParametro("@Descripcion", nuevo.Descripcion);
                escritura.SetearParametro("@Marca", nuevo.Marca.Id);
                escritura.SetearParametro("@Categoria", nuevo.Categoria.Id);
                escritura.SetearParametro("@ImagenUrl", nuevo.ImagenUrl);
                escritura.SetearParametro("@Precio", nuevo.Precio);
                escritura.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                escritura.CerrarConexion();
            }
        }
    }
}
