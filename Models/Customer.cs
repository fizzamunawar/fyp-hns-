namespace fyp_hunger_nd_spice_.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class customer
    {
        public customer()
        { Order = new HashSet<Order>();
          Feedback = new HashSet<Feedback>();
        }

        [Key]
        [Column("Customer_id")]
       
        public int Customer_id { get; set; }

       
        [StringLength(100)]
        [Required(ErrorMessage = "Please enter your name.")]
        [RegularExpression(@"^[^\d]+$", ErrorMessage = "Name should not contain any digits.")]
        [Display(Name = "Name")]
        public string Customer_name { get; set; }
     
     
       [StringLength(100)]
        [Required(ErrorMessage = "Please enter your email.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        [Display(Name = "Email")]
        public string Customer_email { get; set; }

       
        [StringLength(100)]
        [Required(ErrorMessage = "Please enter a password.")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$", ErrorMessage = "Please enter a valid password. It must contain at least 8 characters, including at least one letter and one digit.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Customer_password { get; set; }

        [StringLength(11)]
        [Required(ErrorMessage = "Please enter your contact number.")]
        [RegularExpression(@"^03\d{9}$", ErrorMessage = "Please enter a valid contact number starting with '03' and containing 11 digits.")]
        [Display(Name = "Contact Number")]
        public string Customer_contact { get; set; }

     
        [StringLength(11)] 
        public string ResetCode { get; set; }

        
        [StringLength(100)]
        [Required(ErrorMessage = "Please enter your address.")]
        [Display(Name = "Address")]
        public string Customer_address { get; set; }
        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<Feedback> Feedback { get; set; }

      

    }

}
