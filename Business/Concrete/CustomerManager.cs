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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(MessagesAboutCustomer.CustomerAdded);
        }

        public IResult Delete(Customer customer)
        {
            if (customer.CustomerId == _customerDal.Get(c => c.CustomerId == customer.CustomerId).CustomerId)
            {
                _customerDal.Delete(customer);
                return new SuccessResult(MessagesAboutCustomer.CustomerDeleted);
            }
            return new ErrorResult(MessagesAboutCustomer.CustomerNotFound);

        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), MessagesAboutCustomer.CustomersListed);
        }

        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.CustomerId == id), MessagesAboutCustomer.CustomerGetted);
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(MessagesAboutCustomer.CustomerUpdated);
        }
    }
}
