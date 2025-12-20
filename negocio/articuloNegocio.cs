using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;
using System.Security.Cryptography.X509Certificates;

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
                datos.SetearConsulta("select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.ImagenUrl, A.Precio, C.Id as IdCategoria, C.Descripcion as Categoria, M.Id as IdMarca, M.Descripcion as Marca from Articulos A, Categorias C, Marcas M where C.Id = A.IdCategoria and M.Id = A.IdMarca");
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
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
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
                escritura.SetearConsulta("insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, " +
                    "ImagenUrl, Precio) " +
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
        public void modificar(Articulo art)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("update ARTICULOS set Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, " +
                    "IdMarca = @IdMarca, IdCategoria = @IdCategoria,  ImagenUrl = @ImagenUrl, Precio = @Precio where Id = @Id");
                datos.SetearParametro("@Codigo", art.Codigo);
                datos.SetearParametro("@Nombre", art.Nombre);
                datos.SetearParametro("@Descripcion", art.Descripcion);
                datos.SetearParametro("@IdMarca", art.Marca.Id);
                datos.SetearParametro("@IdCategoria", art.Categoria.Id);
                datos.SetearParametro("@ImagenUrl", art.ImagenUrl);
                datos.SetearParametro("@Precio", art.Precio);
                datos.SetearParametro("@Id", art.Id);

                datos.EjecutarAccion();
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
        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();  
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.ImagenUrl, A.Precio, C.Id as IdCategoria, C.Descripcion as Categoria, M.Id as IdMarca, M.Descripcion as Marca from Articulos A, Categorias C, Marcas M where C.Id = A.IdCategoria and M.Id = A.IdMarca and ";
                if (campo == "Precio")
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "A.Precio > " + filtro;
                            break;
                        case "Menor a":
                            consulta += "A.Precio < " + filtro;
                            break;
                        default:
                            consulta += "A.Precio = " + filtro;
                            break;
                    }
                else if (campo == "Descripción")
                    switch (criterio)
                    {
                        case "Comienza con ":
                            consulta += "A.Descripcion like '" + filtro + "%'";
                            break;
                        case "Termina con ":
                            consulta += "A.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "A.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                else if (campo == "Categoría")
                    switch (criterio)
                    {
                        case "Comienza con ":
                            consulta += "C.Descripcion like '" + filtro + "%'";
                            break;
                        case "Termina con ":
                            consulta += "C.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "C.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                else
                {
                    switch (criterio)
                    {
                        case "Comienza con ":
                            consulta += "M.Descripcion like '" + filtro + "%'";
                            break;
                        case "Termina con ":
                            consulta += "M.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "M.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }
                datos.SetearConsulta(consulta);
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
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
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
    }
}
