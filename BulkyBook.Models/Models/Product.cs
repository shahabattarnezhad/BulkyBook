using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BulkyBook.Models.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string ProductTitle { get; set; }

        [Required]
        public string ProductAuthor { get; set; }
        public string ProductDescription { get; set; }

        [Required]
        public string ProductISBN { get; set; }

        [Required]
        [Range(1,10000)]
        public double ProductListPrice { get; set; }

        [Required]
        [Range(1, 10000)]
        public double ProductPrice { get; set; }

        [Required]
        [Range(1, 10000)]
        public double ProductPrice50 { get; set; }

        [Required]
        [Range(1, 10000)]
        public double ProductPrice100 { get; set; }

        public string ProductImage { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int CoverTypeId { get; set; }

        #region Relations

        public Category Category { get; set; }
        public CoverType CoverType { get; set; }

        #endregion
    }
}
