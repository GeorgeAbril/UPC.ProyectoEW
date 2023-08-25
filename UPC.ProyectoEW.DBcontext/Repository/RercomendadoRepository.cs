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
    public class RecomendadoRepository : BaseRepository, IRecomendadoRepository
    {
        public EntityBaseResponse GetRecomendados()
        {
            var response = new EntityBaseResponse();
            try
            {
                using (var db = GetSqlConnection())
                {
                    var recomendados = new List<Recomendado>();

                    const string sql = "usp_ListarRecomendados";
                    recomendados = db.Query<Recomendado>(
                            sql: sql,
                            commandType: CommandType.StoredProcedure
                        ).ToList();

                    if (recomendados.Count > 0)
                    {
                        var images = new ImagenesRepository();
                        foreach (var pro in recomendados)
                        {
                            pro.Imagenes = images.GetImagenes(pro.Idrecomendados, "R").data as List<Imagen>;
                        }

                        response.isSuccess = true;
                        response.errorCode = "0000";
                        response.errorMessage = string.Empty;
                        response.data = recomendados;
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