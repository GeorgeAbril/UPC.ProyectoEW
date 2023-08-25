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
    public class MaspedidoRepository : BaseRepository, IMaspedidosRepository
    {
        public EntityBaseResponse GetMaspedidos()
        {
            var response = new EntityBaseResponse();
            try
            {
                using (var db = GetSqlConnection())
                {
                    var maspedidos = new List<Maspedido>();

                    const string sql = "usp_ListarMaspedidos";
                    maspedidos = db.Query<Maspedido>(
                            sql: sql,
                            commandType: CommandType.StoredProcedure
                        ).ToList();

                    if (maspedidos.Count > 0)
                    {
                        var images = new ImagenesRepository();
                        foreach (var pro in maspedidos)
                        {
                            pro.Imagenes = images.GetImagenes(pro.Idmaspedidos, "M").data as List<Imagen>;
                        }

                        response.isSuccess = true;
                        response.errorCode = "0000";
                        response.errorMessage = string.Empty;
                        response.data = maspedidos;
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
