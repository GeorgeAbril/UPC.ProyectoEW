using DBEntity;
using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace DBEntity;

public class Category : EntityBase
{
    public int Idcategory { get; set; }
    public string Nombre { get; set; }
    public   List<Imagen> Imagenes { get; set; }
  //  public virtual ICollection<Maspedido> Maspedidos { get; set; } = new List<Maspedido>();
  //  public virtual ICollection<Recomendado> Recomendados { get; set; } = new List<Recomendado>();
}
