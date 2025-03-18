using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SampleCRUD.Model;
using SampleCRUD.Service;
using SampleCRUD.Service.Impl;

namespace SampleCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {

        private readonly InvoiceService _invoiceService;
        public InvoiceController(InvoiceService serviceImpl)
        {
            _invoiceService = serviceImpl;
        }

        [HttpGet("get-all")]
        [Authorize]
        public IActionResult Get() 
        {
            Responce responce = _invoiceService.getAll();

            if (responce.StatusCode == 00)
            {
                return Ok(responce);
            }
            return BadRequest(responce);
        }

        [HttpPost("add")]
        [Authorize]
        public IActionResult addInvoice(Invoice invoice)
        {
            if (invoice == null) { 
                return BadRequest(new Responce(01,"Invoice is null",null));
            }
            Responce responce = _invoiceService.addInvoice(invoice);
            if (responce.StatusCode == 00)
            {
                return Ok(responce);
            }
            return BadRequest(responce);
        }

        [HttpGet("get-invoice-byId/{Id}")]
        [Authorize]
        public IActionResult getAllInvoiceById(int Id) 
        {

            Responce responce = _invoiceService.getInvoiceById(Id);
            if(responce.StatusCode ==01 ||  responce.StatusCode == 02)
            {
                return BadRequest(responce);
            }

            return Ok(responce);
        }

        [HttpDelete("delete-byId/{Id}")]
        [Authorize]
        public IActionResult deleteById(int Id)
        {

            Responce responce = _invoiceService.deleteById(Id);
            if (responce.StatusCode == 01 || responce.StatusCode == 02)
            {
                return BadRequest(responce);
            }

            return Ok(responce);
        }

        [HttpPut("update/{Id}")]
        [Authorize]
        public IActionResult updateInvoice(int Id, Invoice invoice)
        {
            Responce responce = _invoiceService.updateInvoice(Id,invoice);
            if (responce.StatusCode == 01 || responce.StatusCode == 02)
            {
                return BadRequest(responce);
            }

            return Ok(responce);

        }

    }
}
