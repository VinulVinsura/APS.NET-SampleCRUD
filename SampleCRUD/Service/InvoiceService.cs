using Microsoft.AspNetCore.Mvc;
using SampleCRUD.Model;

namespace SampleCRUD.Service
{
    public interface InvoiceService
    {

        public Responce getAll();

        public Responce addInvoice(Invoice invoice);

        public Responce getInvoiceById(int id);

        public Responce deleteById(int id);

        public Responce updateInvoice(int id, Invoice invoice);
    }
}
