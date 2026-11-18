using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.Dtos
{
    public class DegreeDto
    {
      
        public int Id { get; set; }
     
        public string? NameEnglish { get; set; }
    
        public string? NameKhmer { get; set; }
    }
}
