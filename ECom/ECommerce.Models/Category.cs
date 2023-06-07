using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Category Name should be between 1 and 30")]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        [Range(1, 500, ErrorMessage = "Display order should be between 1 and 500")]
        [Display(Name = "Display Order")]
        public int DisplayOrder { get; set; }
    }
}
