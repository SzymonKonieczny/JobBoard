using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobBoard.Models
{
    public class Tag
    {
        [Key]

        public int Id { get; set; }
        public string Name { get; set; }
        public Tag(string name)
        {
            Name = name;
        }
    }
    public class SearchOptions
    {

    }
    public class UserApplication 
    {
        public UserApplication(string _ApplicantID) { ApplicantID = _ApplicantID; }
        public UserApplication() { }

        [Key]
        public int Id { get; set; }
        public  string ApplicantID { get; set; }

        public int JobOfferId{ get; set; }


    }
    public class JobOffer
    {
        
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public JobOffer(string s) {
            Title = s; 
            Tags = new List<Tag>();
            ApplicantsIDs = new HashSet<UserApplication>();

        }
        public JobOffer()
        {
            Title = "";
            Tags = new List<Tag>();
            ApplicantsIDs = new HashSet<UserApplication>();

        }

        public string CompanyID { get; set; }
        public JobBoardAccount OwnedBy { get; set; }

       public HashSet<UserApplication> ApplicantsIDs { get; set; }

        public List<Tag> Tags { get; set; }
    }
    public class AccountWithApplications
    {
        public AccountWithApplications(UserApplication _App, JobBoardAccount _acc) { App = _App; Acc = _acc; }
        public  UserApplication App;
        public  JobBoardAccount Acc;
    }

}