using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SampleCRUD.Model;

namespace SampleCRUD.Service.Impl
{
    public class InvoiceServiceImpl : InvoiceService
    {
        private readonly ApplicationDbContext _context;
        public InvoiceServiceImpl(ApplicationDbContext context)
        {
            _context = context;
        }

        public Responce addInvoice(Invoice invoice)
        {
            Invoice? invoice1 = _context.Invoices.FirstOrDefault(x => x.Name == invoice.Name);
            if (invoice1 != null)
            {
                return new Responce(02, "This invoice already exits...",null);
            }
            _context.Invoices.Add(invoice);
            _context.SaveChanges();
            return new Responce(00,"Invoice save success...", invoice);            

        }

        public Responce deleteById(int id)
        {

            try
            {
                Invoice? invoice = _context.Invoices.FirstOrDefault(x => x.Id == id);
                if (invoice == null)
                {
                    return new Responce(01, "Not exists data", null);
                }

                _context.Invoices.Remove(invoice);
                _context.SaveChanges();
                return new Responce(00, "Success...", null);

            }catch(Exception ex)
            {
                return new Responce(02, "Error", ex.Message);
            }
        }

        public Responce getAll()
        {
            try
            {
                List<Invoice> list = _context.Invoices.ToList();
                if (list.IsNullOrEmpty())
                {
                    return new Responce(01, "Not include data in invoice tabale", null);
                }
                return new Responce(00, "Success..", list);
            }
            catch (Exception ex) { 
            
                return new Responce(02,"Error",ex.Message);

            }

        }

        public Responce getInvoiceById(int id)
        {
            try
            {
                Invoice? invoice = _context.Invoices.FirstOrDefault(x => x.Id == id);
                if (invoice == null)
                {
                    return new Responce(01, "Not exixts recode", null);
                }

                return new Responce(00, "Success", invoice);
            }
            catch (Exception ex) {

                return new Responce(02, "Error", ex.Message);
            }

        }

        public Responce updateInvoice(int id, Invoice invoice)
        {

            try
            {
                Invoice? invoice1 = _context.Invoices.FirstOrDefault(x => x.Id == id);
                if (invoice1 == null)
                {
                    return new Responce(01, "Not exixts recode", null);
                }
                invoice1.Name = invoice.Name;
                invoice1.Description = invoice.Description;
                invoice1.Price = invoice.Price;
                invoice1.Status = invoice.Status;
                invoice1.PhoneNumber = invoice.PhoneNumber;

                _context.SaveChanges();
                return new Responce(00, "Update success..", invoice1);


            }
            catch(Exception ex)
            {
                return new Responce(02, "Error", ex.Message);
            }
        }
    }
}
