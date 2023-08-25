using System;
using System.Collections.Generic;

namespace DBEntity;
public class Imagen: EntityBase
{
    public int Idimagen { get; set; }
    public string Nombre { get; set; }
    public string Ruta { get; set; }
    public int Idcategory { get; set; }
    public int Idmaspedidos { get; set; }
    public int Idrecomendados { get; set; }
    public string Tipo { get; set; }
   // public virtual Category? IdcategoryNavigation { get; set; }
   // public virtual Maspedido? IdmaspedidosNavigation { get; set; }
   // public virtual Recomendado? IdrecomendadosNavigation { get; set; }
}
