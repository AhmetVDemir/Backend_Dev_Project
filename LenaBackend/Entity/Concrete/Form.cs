using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class BaseForm : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public int CreatedBy { get; set; }
    }
    public class Form : BaseForm
    {
        public List<Field> Fields { get; set; }
    }


}
