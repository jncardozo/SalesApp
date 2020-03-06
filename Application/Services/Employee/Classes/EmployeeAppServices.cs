using Application.Services.Employee.Interfaces;
using Data_Access.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Employee.Classes
{
    public class EmployeeAppServices : GeneralReposity<Domain.Models.Employees>, IEmployeeAppServices
    {
    }
}
