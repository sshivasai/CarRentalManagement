using System.ComponentModel.DataAnnotations;

namespace CarRentalManagement___DataAccessLayer.DTO
{
	public class CarTypeDto
	{
		
		public int CarId { get; set; }
	
		public int Gears { get; set; }

		public Transmition transmition { get; set; }
	}
}