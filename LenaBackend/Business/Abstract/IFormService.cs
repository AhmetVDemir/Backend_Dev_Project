using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFormService
    {
        List<Form> getFormsbyUser(int id);
        BaseForm getFormById(int id);
        Form saveFormtoDb(Form form);
    }
}
