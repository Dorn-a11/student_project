using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.Models
{
    [Table("tbl_Degree")]
    public class Degree
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string? NameEnglish { get; set; }
        [StringLength(50)]
        public string? NameKhmer { get; set; }
    }
}
