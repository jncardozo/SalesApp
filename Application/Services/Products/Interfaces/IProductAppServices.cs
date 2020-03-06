using Data_Access.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Products.Interfaces
{
    public interface IProductAppServices : IGenericRepository<Domain.Models.Products>
    {
    }
}
