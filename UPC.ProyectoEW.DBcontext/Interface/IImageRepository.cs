using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBEntity;

namespace DBContext
{
    public interface IImageRepository
    {
        EntityBaseResponse GetImagenes(int id, string tipo);
    }
}
