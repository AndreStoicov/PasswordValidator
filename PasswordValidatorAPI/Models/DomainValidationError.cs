using System.Collections.Generic;
using System.Net;

namespace PasswordValidatorAPI.Models
{
    public class DomainValidationError
    {
        public string Type { get; set; }
        public string Message { get; set; }
    }
}