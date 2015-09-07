using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCDemo.Domain
{
    public class Member : BaseDomain
    {
        [Key]
        public int MemberID { get; set; }

        [Required(ErrorMessage="First Name is Required.")]        
        [Column(TypeName="varchar")]
        [StringLength(50)]
        [AdditionalMetadata("MaxSize","50")]
        [Display(Name="First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required.")]        
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        [AdditionalMetadata("MaxSize", "50")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public virtual IList<Contact> Contacts { get; set; }

        [NotMappedAttribute]
        [Display(Name = "Name")]
        public string FullName { get { return LastName + ", " + FirstName; } }

    }
}