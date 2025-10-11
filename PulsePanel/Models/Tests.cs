

using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
namespace PetAdoptionSystem.Models
{
    class PetAdoption
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string PetName { get; set; }
        [Required]
        public string PetAdopter { get; set; }
        [Required]
        public DateTime AdoptionDate { get; set; }
        public string PetType { get; set; }




        public PetAdoption() { }

        public PetAdoption(int aId, string aPetName, string aPetAdopter, string aPetType)
        {
            Id = aId;
            PetName = aPetName;
            PetAdopter = aPetAdopter;
            PetType = aPetType;
            AdoptionDate = DateTime.UtcNow;

        }

        public override string ToString()
        {
            return $"[PetAdoption] Id:{Id}, PetName:{PetName},PetAdopter:{PetAdopter}, PetType:{PetType}, AdoptionDate: {AdoptionDate} ";
        }



        // methods

        public bool TimeOfAdoption(int Seconds)
        {

          return( DateTime.UtcNow-AdoptionDate).TotalSeconds <= Seconds;
        }

    }
}