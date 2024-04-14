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
        public void SaveChanges();
        public  List<JobOffer> GetOffers();

        public IQueryable<JobOffer> GetOffersQueryable();
        public DbServiceActionStatus EditOffer( JobOffer offer);

        public int AddTag(Tag tag);
        int AddOffer(JobOffer offer);
        public List<Tag> GetTags();
        public IQueryable<Tag> GetTagsQueryable();

        DbServiceActionStatus DeleteOffer(int id);

    }
}