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
    public class JobOffer
    {
        
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public JobOffer(string s) {
            Title = s; 
            Tags = new List<Tag>();
        }
        public JobOffer()
        {
            Title = "";
            Tags = new List<Tag>();
        }

        public List<Tag> Tags { get; set; }
    }
}