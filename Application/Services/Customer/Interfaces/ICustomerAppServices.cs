using Data_Access.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Services.Customer.Interfaces
{
    public interface ICustomerAppServices : IGenericRepository<Domain.Models.Customers>
    {
    }
}
