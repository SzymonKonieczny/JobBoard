using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JobBoard.Models
{
   public enum AccountType
    {
        [Display(Name="Company")]
        Employer,
        [Display(Name = "Employee")]

        Employee
    }
    public class JobBoardAccount : IdentityUser
    {
       public AccountType Type { get; set; }
    }
}
