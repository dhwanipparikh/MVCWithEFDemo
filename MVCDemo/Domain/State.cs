using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCDemo.Domain
{
    public class State : BaseDomain
    {
        [Key]
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(2)]        
        public string StateID { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(25)]        
        public string StateName { get; set; }

    }
}