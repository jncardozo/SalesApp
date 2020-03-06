using Data_Access.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Invoice.Interfaces
{
    public interface IInvoiceHeaderAppServices : IGenericRepository<Domain.Models.InvoiceHeader>
    {
    }
}
