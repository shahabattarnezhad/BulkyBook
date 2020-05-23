
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BulkyBook.Models.Models
{
    [Table("Tbl_Category")]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }


        [Display(Name = "Category Name")]
        [Required(ErrorMessage = "Please enter the {0}")]
        [Column(TypeName = "nvarchar(50)")]
        public string CategoryName { get; set; }
    }
}
