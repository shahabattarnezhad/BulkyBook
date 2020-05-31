using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BulkyBook.Models.Models
{
    [Table("Tbl_Product")]
    public class Product
    {


        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }
        public string Description { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        [Range(1,10000)]
        public double ListPrice { get; set; }

        [Required]
        [Range(1, 10000)]
        public double Price { get; set; }

        [Required]
        [Range(1, 10000)]
        public double Price50 { get; set; }

        [Required]
        [Range(1, 10000)]
        public double Price100 { get; set; }

        public string Image { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int CoverTypeId { get; set; }

        #region Relations

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [ForeignKey("CoverTypeId")]
        public CoverType CoverType { get; set; }

        #endregion
    }
}
