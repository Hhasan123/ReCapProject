using Business.Abstract;
using Business.Constants.Messages;
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

        public IResult Add(Customer customer)
        {
            if (customer.CompanyName.Length < 3)
            {
                return new ErrorResult(MessagesAboutCustomer.CompanyNameInvalid);
            }
            else if (customer.UserId <= 0)
            {
                return new ErrorResult(MessagesAboutCustomer.CustomerUserIdInvalid);
            }
            _customerDal.Add(customer);
            return new SuccessResult(MessagesAboutCustomer.CustomerAdded);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(MessagesAboutCustomer.CustomerDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), MessagesAboutCustomer.CustomersListed);
        }

        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.CustomerId == id), MessagesAboutCustomer.CustomerGetted);
        }

        public IResult Update(Customer customer)
        {
            if (customer.CompanyName.Length < 3)
            {
                return new ErrorResult(MessagesAboutCustomer.CompanyNameInvalid);
            }
            else if (customer.UserId <= 0)
            {
                return new ErrorResult(MessagesAboutCustomer.CustomerUserIdInvalid);
            }
            _customerDal.Update(customer);
            return new SuccessResult(MessagesAboutCustomer.CustomerUpdated);
        }
    }
}
