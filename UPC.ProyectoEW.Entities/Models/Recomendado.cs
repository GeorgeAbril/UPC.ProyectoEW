using DBEntity;
using System;
using System.Collections.Generic;

namespace DBEntity;

public class Recomendado: EntityBase
{
    public int Idrecomendados { get; set; }
    public int Idcategory { get; set; }
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public  List<Imagen> Imagenes { get; set; }
   // public virtual ICollection<Imagen> Imagens { get; set; } = new List<Imagen>();
}
