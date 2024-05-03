using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace NovelNest.Models.Models
{
    public class Category
    {
        [Key]//tells that this field will be the primary key//these are data annotations
        public int Id { get; set; }
        [Required]//tells that this field will be not null
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Not in Range")]
        public int DisplayOrder { get; set; }
    }
}
