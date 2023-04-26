using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FieldManager : IFieldService
    {

        IFieldDal _fieldDal;

        public FieldManager(IFieldDal fieldDal)
        {
            _fieldDal = fieldDal;
        }

        public List<Field> GetAllFieldsByFormId(int formId)
        {
            return _fieldDal.GetAll(field => field.FormId == formId).ToList();  
        }

        //todo: saveFields

        public void SaveFieldsToDb(List<Field> fields)
        {
            try
            {
                foreach (Field field in fields)
                {
                    _fieldDal.Add(field);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

    }
}
