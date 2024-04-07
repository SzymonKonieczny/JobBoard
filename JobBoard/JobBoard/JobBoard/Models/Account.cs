using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace JobBoard.Models
{
   public enum AccountType
    {
        Employer,
        Employee
    }
    public class JobBoardAccount : IdentityUser
    {
       public AccountType Type { get; set; }
    }
}
