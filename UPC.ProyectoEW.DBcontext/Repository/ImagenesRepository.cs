using Dapper;
using DBEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DBContext
{
    public class ImagenesRepository: BaseRepository , IImageRepository
    {
        public EntityBaseResponse GetImagenes(int id, string tipo)
        {
            var response = new EntityBaseResponse();
            try
            {
                using (var db = GetSqlConnection())
                {
                    var imagenes = new List<Imagen>();
                    string sql = (tipo == "C") ? "usp_Listar_Images_X_Categoria" : (tipo == "M") ? "usp_Listar_Images_X_Maspedido" : "usp_Listar_Images_X_Recomendados";

                    var p = new DynamicParameters();

                    if (tipo == "C")
                    {
                        p.Add(name: "@IDCATEGORY", value: id, dbType: System.Data.DbType.Int64, direction: System.Data.ParameterDirection.Input);
                    }
                    else if (tipo == "M")
                    {
                        p.Add(name: "@IDMASPEDIDO", value: id, dbType: System.Data.DbType.Int64, direction: System.Data.ParameterDirection.Input);
                    }
                    else
                    {
                        p.Add(name: "@IDRECOMENDADOS", value: id, dbType: System.Data.DbType.Int64, direction: System.Data.ParameterDirection.Input);
                    }

                    imagenes = db.Query<Imagen>(
                            sql: sql,
                            param: p,
                            commandType: System.Data.CommandType.StoredProcedure
                        ).ToList();

                    if (imagenes.Count > 0)
                    {
                        response.isSuccess = true;
                        response.errorCode = "0000";
                        response.errorMessage = string.Empty;
                        response.data = imagenes;
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
            catch(Exception ex){

            }
            return response;
        }
    }
}
