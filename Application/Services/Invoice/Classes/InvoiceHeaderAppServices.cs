using Application.Services.Invoice.Interfaces;
using Data_Access.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Invoice.Classes
{
    public class InvoiceHeaderAppServices : GeneralReposity<Domain.Models.InvoiceHeader>, IInvoiceHeaderAppServices
    {
    }
}
