﻿using UoN.ExpressiveAnnotations.NetCore.Attributes;

namespace Bookify.Web.Core.ViewModels
{
    public class UserFormViewModel

    {

        public string? Id { get; set; }

        [MaxLength(100, ErrorMessage = Errors.MaxLength), Display(Name = "Full Nane")
            , RegularExpression(RegexPatterns.CharactersOnly_Eng, ErrorMessage = Errors.OnlyEnglishLetters)]
        public string FullName { get; set; } = null!;
        [MaxLength(20, ErrorMessage = Errors.MaxLength)]

        [Remote("AllowUserName", null!, AdditionalFields = "Id", ErrorMessage = Errors.Duplicated),
 RegularExpression(RegexPatterns.Username, ErrorMessage = Errors.InvalidUsername)]


        public string UserName { get; set; } = null!;

        [MaxLength(200, ErrorMessage = Errors.MaxLength), EmailAddress]
        [Remote("AllowEmail", null!, AdditionalFields = "Id", ErrorMessage = Errors.Duplicated)]

        public string Email { get; set; } = null!;


        [DataType(DataType.Password),
            StringLength(100, ErrorMessage = Errors.MaxMinLength, MinimumLength = 8),
            RegularExpression(RegexPatterns.Password, ErrorMessage = Errors.WeakPassword)]
        [RequiredIf("Id == null", ErrorMessage = Errors.RequiredField)]

        public string? Password { get; set; }

        [DataType(DataType.Password), Display(Name = "Confirm password"),
        Compare("Password", ErrorMessage = Errors.ConfirmPasswordNotMatch)]
        [RequiredIf("Id == null", ErrorMessage = Errors.RequiredField)]
        public string? ConfirmPassword { get; set; }
        [Display(Name = "Roles")]
        public IList<string> SelectedRoles { get; set; } = new List<string>();
        public IEnumerable<SelectListItem>? Roles { get; set; }


    }
}
