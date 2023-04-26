using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFieldService
    {
        void SaveFieldsToDb(List<Field> fields);

        List<Field> GetAllFieldsByFormId(int formId);
    }
}
