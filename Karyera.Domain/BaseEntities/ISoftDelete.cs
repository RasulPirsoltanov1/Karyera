using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karyera.Domain.BaseEntities
{
    public interface ISoftDelete
    {
        public bool IsActive { get; set; }
    }
}
