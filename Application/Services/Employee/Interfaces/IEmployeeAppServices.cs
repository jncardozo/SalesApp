using Data_Access.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Employee.Interfaces
{
    public interface IEmployeeAppServices : IGenericRepository<Domain.Models.Employees>
    {
    }
}
