using JobBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobBoard.Services
{
    public enum DbServiceActionStatus
    {
        Success,
        Failure
    }
    public interface IDbService
    {
        List<JobOffer> GetOffers(SearchOptions options);
        public int AddTag(Tag tag);
        int AddOffer(JobOffer offer);
        public List<Tag> GetTags(SearchOptions options);
        DbServiceActionStatus DeleteOffer(int id);

    }
}