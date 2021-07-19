using Microsoft.AspNetCore.Identity;
using Sharif_Asim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sharif_Asim.Classes
{
    public class CustomPasswordValidator : IPasswordValidator<User>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user, string password)
        {
            List<IdentityError> errors = new ();
            if (!password.Contains(user.UserName))
                return Task.FromResult(IdentityResult.Success);
            errors.Add(new IdentityError() {
                Code = "ContainsUserName",
                Description = Res.Validation.ContainsUserName
            });
            return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
        }
    }
    public class CustomUserValidator : IUserValidator<User>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user, string password)
        {
            List<IdentityError> errors = new();
            if (!password.Contains(user.UserName))
                return Task.FromResult(IdentityResult.Success);
            errors.Add(new IdentityError() {
                Code = "ContainsUserName",
                Description = Res.Validation.ContainsUserName
            });
            return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
        }

        public Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user)
        {
            List<IdentityError> errors = new();
            if (!user.Email.Contains("@gmail.com"))
                return Task.FromResult(IdentityResult.Success);
            errors.Add(new IdentityError() {
                Code = "ContainsCompanyName",
                Description = Res.Validation.ContainsCompanyName
            });
            return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
        }
    }
}
