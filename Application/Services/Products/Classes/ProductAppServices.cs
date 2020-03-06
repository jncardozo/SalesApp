using Application.Services.Products.Interfaces;
using Data_Access.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Products.Classes
{
    public class ProductAppServices : GeneralReposity<Domain.Models.Products>, IProductAppServices
    {
    }
}
