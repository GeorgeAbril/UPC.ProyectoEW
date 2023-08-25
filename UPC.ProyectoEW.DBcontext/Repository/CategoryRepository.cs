using Dapper;
using DBEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBContext
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public EntityBaseResponse GetCategory()
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {
                    var categories = new List<Category>();

                    const string sql = "usp_ListarCategoria";
                    categories = db.Query<Category>(
                            sql: sql,
                            commandType: CommandType.StoredProcedure
                        ).ToList();

                    if (categories.Count > 0)
                    {
                        var images = new ImagenesRepository();
                        foreach (var pro in categories)
                        {
                            pro.Imagenes = images.GetImagenes(pro.Idcategory, "C").data as List<Imagen>;
                        }

                        response.isSuccess = true;
                        response.errorCode = "0000";
                        response.errorMessage = string.Empty;
                        response.data = categories;
                    }
                    else
                    {
                        response.isSuccess = false;
                        response.errorCode = "0000";
                        response.errorMessage = string.Empty;
                        response.data = null;
                    }
                }
            }
            catch (Exception ex)
            {
                response.isSuccess = false;
                response.errorCode = "0001";
                response.errorMessage = ex.Message;
                response.data = null;
            }

            return response;
        }

        public EntityBaseResponse GetCategoryxid(int id)
        {
            var response = new EntityBaseResponse();
            try
            {
                using (var db = GetSqlConnection())
                {
                    var categoria = new Category();
                    const string sql = "usp_ObtenerCategoria";
                    var p = new DynamicParameters();
                    p.Add(name: "@IDCATEGORY", value: id, dbType: System.Data.DbType.Int32,
                        direction:System.Data.ParameterDirection.Input);

                    categoria = db.Query<Category>(sql:sql, param: p ,commandType: System.Data.CommandType.StoredProcedure
                        ).FirstOrDefault();
                    if (categoria != null)
                    {
                        var images = new ImagenesRepository();
                        var recomendados = new RecomendadoRepository();
                        var maspedidos = new MaspedidoRepository();

                        categoria.Imagenes = images.GetImagenes(categoria.Idcategory, "C").data as List<Imagen>;

                        response.isSuccess = true;
                        response.errorCode = "0000";
                        response.errorMessage = string.Empty;
                        response.data = categoria;
                    }
                    else
                    {
                        response.isSuccess = false;
                        response.errorCode = "0000";
                        response.errorMessage = string.Empty;
                        response.data = null;
                    }
                }

            }
            catch (Exception ex)
            {
                response.isSuccess = false;
                response.errorCode = "0001";
                response.errorMessage = ex.Message;
                response.data = null;
            }
            return response;
        }
    }
}
