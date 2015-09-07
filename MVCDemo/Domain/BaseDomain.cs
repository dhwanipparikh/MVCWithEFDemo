using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCDemo.Domain
{
    public abstract class BaseDomain
    {
        [Timestamp]
        public byte[] RowVersion { get; set; }

        [Required(ErrorMessage = "Created By is Required.")]
        [Column(TypeName = "varchar")]
        [StringLength(20)]
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Required(ErrorMessage = "Create Date Time is Required.")]
        [Column(TypeName = "datetime")]
        [Display(Name = "Create Date Time")]
        public DateTime CreateDateTime { get; set; }

        [Required(ErrorMessage = "Update By is Required.")]
        [Column(TypeName = "varchar")]
        [StringLength(20)]
        [Display(Name = "Update By")]
        public string UpdatedBy { get; set; }

        [Required(ErrorMessage = "Update Date Time is Required.")]
        [Column(TypeName = "datetime")]
        [Display(Name = "Update Date Time")]
        public DateTime UpdateDateTime { get; set; }

    }
}