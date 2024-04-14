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
       public JobBoardAccount()
        {
            Offers = new HashSet<JobOffer>();
        }
       public AccountType Type { get; set; }
        public HashSet<JobOffer> Offers { get; set; }

        public string ResumePath { get; set; }
        public string ProfilePicturePath { get; set; }
        public string Description { get; set; }


    }
}
