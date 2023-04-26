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
    public class FormManager : IFormService
    {

        IFormDal _formDal;
        IFieldService _fieldService;

        public FormManager(IFormDal formDal, IFieldService fieldService)
        {
            _formDal = formDal;

            _fieldService = fieldService;
        }

        public List<Form> getFormsbyUser(int id)
        {
            try
            {
                List<Form> forms = new List<Form>();

                _formDal.GetAll(form => form.CreatedBy == id).ToList().ForEach(uform =>
                {
                    Form tmpForm = new Form()
                    {
                        Id = uform.Id,
                        Name = uform.Name,
                        CreatedAt = uform.CreatedAt,
                        CreatedBy = uform.CreatedBy,
                        Description = uform.Description,
                        Fields = _fieldService.GetAllFieldsByFormId(uform.Id).ToList()
                    };
                    forms.Add(tmpForm);
                });
                return forms;
            }
            catch
            {
                return null;
            }
        }

        public BaseForm getFormById(int id)
        {
            try
            {
                return _formDal.Get(f => f.Id == id);
            }
            catch
            {
                return null;
            }
        }

        public Form saveFormtoDb(Form form)
        {

            try
            {
                BaseForm savedForm = new BaseForm()
                {
                    CreatedBy = form.CreatedBy,
                    CreatedAt = DateTime.Now,
                    Description = form.Description,
                    Name = form.Name
                };

                _formDal.Add(savedForm);

                form.Fields.ForEach(t =>
                {
                    t.FormId = savedForm.Id;
                });
   
                _fieldService.SaveFieldsToDb(form.Fields);

                return form;
            }
            catch
            {
                return null;
            }
        }
    }
}
