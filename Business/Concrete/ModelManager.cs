using Business.Abstract;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ModelManager : IModelService
    {
        IModelDal _modelDal;

        public ModelManager(IModelDal modelDal)
        {
            _modelDal = modelDal;
        }

        [ValidationAspect(typeof(ModelValidator))]
        public IResult Add(Model model)
        {
            _modelDal.Add(model);
            return new SuccessResult(MessagesAboutModel.ModelAdded);
        }

        public IResult Delete(Model model)
        {
            if (model.ModelId == _modelDal.Get(m => m.ModelId == model.ModelId).ModelId)
            {
                _modelDal.Delete(model);
                return new SuccessResult(MessagesAboutModel.ModelDeleted);
            }
            return new ErrorResult(MessagesAboutModel.ModelNotFound);

        }

        public IDataResult<List<Model>> GetAll()
        {
            return new SuccessDataResult<List<Model>>(_modelDal.GetAll(), MessagesAboutModel.ModelsListed);
        }

        public IDataResult<Model> GetById(int id)
        {
            return new SuccessDataResult<Model>(_modelDal.Get(m => m.ModelId == id), MessagesAboutModel.ModelGetted);
        }

        [ValidationAspect(typeof(ModelValidator))]
        public IResult Update(Model model)
        {
            _modelDal.Update(model);
            return new SuccessResult(MessagesAboutModel.ModelUpdated);
        }
    }
}
