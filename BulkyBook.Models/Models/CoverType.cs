using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BulkyBook.Models.Models
{
    [Table("Tbl_CoverType")]
    public class CoverType
    {
        [Key]
        public int CoverTypeId { get; set; }

        [Display(Name = "Cover Type")]
        [Required(ErrorMessage = "Please enter the {0}")]
        [Column(TypeName = "nvarchar(50)")]
        public string CoverTypeName { get; set; }

        #region Relations

        public List<Product> Products { get; set; }

        #endregion
    }
}
