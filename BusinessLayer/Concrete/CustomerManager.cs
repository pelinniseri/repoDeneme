using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CustomerManager
    {
        Repository<Customer> repocustomer = new Repository<Customer>();

        public List<Customer> GetAll()
        {

            return repocustomer.List();
        }

        public int CustomerAddOrRegister(Customer p)
        {
            return repocustomer.Insert(p);
        }
        public Customer FindCustomer(int id)
        {
            return repocustomer.Find(x => x.CustomerID == id);
        }

        public int EditCustomer(Customer a)
        {
            Customer customer = repocustomer.Find(x => x.CustomerID == a.CustomerID);
            customer.CustomerName = a.CustomerName;
            customer.Mail = a.Mail;
            customer.Password = a.Password;
            customer.PhoneNumber = a.PhoneNumber;

            return repocustomer.Update(customer);
        }
    }
}
