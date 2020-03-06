using Application.Services.Customer.Interfaces;
using Data_Access.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Customer.Classes
{
    public class CustomerAppServices : GeneralReposity<Domain.Models.Customers>, ICustomerAppServices
    {
    }
}
