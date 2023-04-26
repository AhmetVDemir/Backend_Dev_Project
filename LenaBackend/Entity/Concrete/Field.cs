using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Field : IEntity
    {
        public int Id { get; set; }
        public int FormId { get; set; }
        public bool Required { get; set; }
        public string Name { get; set; }
        public string DataType { get; set; } //can be an Enum
    }
}
