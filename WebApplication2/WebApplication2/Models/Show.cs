using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models
{
    public class Show
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public Cast Cast { get; set; }
        public Venue Venue { get; set; }

    }
}
