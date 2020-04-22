using System.Collections.Generic;

namespace PasswordValidatorAPI.Models
{
    public class ResponsePassword
    {
        public ResponsePassword(bool isValidPassword)
        {
            IsValidPassword = isValidPassword;
            Errors = new List<DomainValidationError>();
        }

        public bool IsValidPassword { get;  }
        public List<DomainValidationError> Errors { get; set; }
    }
}