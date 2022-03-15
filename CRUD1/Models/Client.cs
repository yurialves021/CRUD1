using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD1.Models
{
    public class Client
    {
        [Column("Id")]
        [Display(Name="Código")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("Name")]
        [Display(Name = "Name")]
        [Required(ErrorMessage = "name is required")]
        public string Name { get; set; }

        [Column("Email")]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "email is required")]
        [EmailAddress(ErrorMessage = "email invalid!")]
        public string Email { get; set; }

        [Column("BirthDate")]
        [Display(Name = "Birth Date")]
        [Required(ErrorMessage = "birth date is required")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }

        [Column("PhoneNumber")]
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "phone number is required")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}
