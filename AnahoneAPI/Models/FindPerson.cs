using System.ComponentModel.DataAnnotations;

namespace AnahoneAPI.Models;
public class FindPerson
{
    [Key]
    public int FindID { get; set; }
    public int PersonID { get; set; }
    public string FinderName { get; set; }
    public string FinderLastName { get; set; }
    public string ContactPhone { get; set; }
    public int? Age { get; set; }
    public string Gender { get; set; }
    public DateTime FindDate { get; set; }
    public string Description { get; set; }
    public string CaseStatus { get; set; } = "Missing";
}