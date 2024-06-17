using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIMS.Core.Common.Domain
{
    public abstract class AggregateRoot
    {
        public string Id { get; private set; }
        public DateTime CreatedTime { get; private set; }
        public int CreatedBy { get; private set; }
        public DateTime? ModifiedTime { get; set; }
        public int? ModifiedBy { get; set; }

        public AggregateRoot() 
        {
            this.Id = Guid.NewGuid().ToString();
            CreatedTime = DateTime.Now;
            CreatedBy = 1;
        }
    }
}
