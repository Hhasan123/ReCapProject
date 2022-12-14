using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess;
using Core.Entites.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System.Linq;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ReCapProjectDbContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using(var context=new ReCapProjectDbContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();
            }
        }
    }
}
