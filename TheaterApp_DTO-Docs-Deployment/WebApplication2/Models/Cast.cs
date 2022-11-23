using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
	public class Cast
	{
		public int Id { get; set; }

		[ForeignKey("Show")]
		public int ShowId { get; set; }
		public string ShowName { get; set; }

		public string JobTitle { get; set; }

		[ForeignKey("Person")]
		public int PersonId { get; set; }
		public string PersonName { get; set; }

		public Show	Show { get; set; }

		public Person Person { get; set; }
	}
}
