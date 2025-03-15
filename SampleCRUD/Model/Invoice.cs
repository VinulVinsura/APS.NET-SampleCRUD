using Microsoft.EntityFrameworkCore;

namespace SampleCRUD.Model
{
    public class Invoice
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public  string Status { get; set; }
        public double Price { get; set; }
    }
}
