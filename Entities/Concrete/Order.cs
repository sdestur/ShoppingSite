using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Order : BaseEntity, IEntity
    {
        public string OrderNumber { get; set; }
        public int TotalPrice { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string OrderDetail { get; set; }
        
    }
}
