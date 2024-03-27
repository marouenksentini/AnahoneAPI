using System.ComponentModel.DataAnnotations;

namespace AnahoneAPI.Models;

	public class LookingForDonor
    {
    [Key]
    public int DonorID { get; set; }
    public string BloodType { get; set; }
    public string HospitalName { get; set; }
    public string UrgencyLevel { get; set; }
    public string AdditionalRequirements { get; set; }
    }

   

