using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.ApplicationCore.Entities
{
    public class OrderProduct
    {
        public Guid Oid { get; set; }

        public Guid Pid { get; set; }

        public Order Order { get; set; } = null!;

        public Product Product { get; set; } = null!;
    }
}
