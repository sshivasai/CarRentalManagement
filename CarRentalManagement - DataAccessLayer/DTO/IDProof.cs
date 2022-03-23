using System.ComponentModel.DataAnnotations;

namespace CarRentalManagement___DataAccessLayer.DTO
{
    public class IDProof
    {
        [Key]
        public string IDNumber { get; set; }
        public string Name { get; set; }
        
        public bool Verification { get; set; }
        //1 = verfied
        //0 = not verified

    }
}