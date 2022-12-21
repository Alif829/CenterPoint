using System.ComponentModel.DataAnnotations;

namespace CenterPoint.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime DateOfBirth { get; set; }
        //public bool IsDeleted { get; set; } = false;
    }
}
