using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web.Mvc;


namespace MVCDemo.Domain
{
    public class Contact : BaseDomain
    {
        [Key]
        [Column(Order=1)]
        public int ContactID { get; set; }

        [Column(Order = 2)]        
        public int MemberID { get; set; }

        [Required(ErrorMessage = "Address Line 1 is Required.")]        
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        [AdditionalMetadata("MaxSize", "50")]
        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; }
       
        
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        [AdditionalMetadata("MaxSize", "50")]
        [Display(Name = "Address Line 2")]
        [DisplayFormat (NullDisplayText="&nbsp;", HtmlEncode= false)]
        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "City is Required.")]       
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        [AdditionalMetadata("MaxSize", "30")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is Required.")]        
        [Column(Order = 3, TypeName = "varchar")]
        [StringLength(2)]   
        [Display(Name="State")]
        public string StateID { get; set; }

        [Required(ErrorMessage = "Zip Code is Required.")]       
        [Column(TypeName = "varchar")]
        [StringLength(10)]
        [AdditionalMetadata("MaxSize", "10")]
        [Display(Name = "Zip")]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid Zip")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Country is Required.")]        
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        [AdditionalMetadata("MaxSize", "30")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Email is Required.")]        
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        [AdditionalMetadata("MaxSize", "50")]
        [RegularExpression(@"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$",ErrorMessage="Invalid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Contact Type is Required.")]
        [Column(TypeName = "varchar")]
        [StringLength(10)]
        public string ContactType { get; set; }

        [ForeignKey("StateID")]
        public virtual State State { get; set; }

        [ForeignKey("MemberID")]
        public virtual Member Member { get; set; }

        [NotMappedAttribute]
        [Display(Name = "Address")]
        public string Address { get { return AddressLine1 + ((AddressLine2 == null || AddressLine2 == string.Empty) == true ? ", " : ", " + AddressLine2 + ", ") + City + ", " + State.StateName + " " + ZipCode; } }


    }
}