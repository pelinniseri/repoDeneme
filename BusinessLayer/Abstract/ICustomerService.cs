using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICustomerService
    {
        List<Comment> GetList();
        void CustomerAdd(Customer customer);
        Customer GetByID(int id);
      
        void CustomerUpdate(Customer customer);
    }
}
