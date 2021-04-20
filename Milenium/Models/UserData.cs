using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Milenium.Models
{
    public class UserData
    {
        //[Required(ErrorMessageResourceName = "nicknameErrorMessage", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name ="nickname", ResourceType = typeof(Resource))]
        [RegularExpression(@"^[a-zA-Z]+$",ErrorMessageResourceName = "nicknameErrorMessage", ErrorMessageResourceType = typeof(Resource))]
        [MaxLength(30)]
        public string Nickname { get; set; }

        //[Required(ErrorMessageResourceName ="emailErrorMessage", ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = "email", ResourceType = typeof(Resource))]
        [EmailAddress(ErrorMessageResourceName ="emailErrorMessage", ErrorMessageResourceType = typeof(Resource))]
        public string EmailAdress { get; set; }
    }
}