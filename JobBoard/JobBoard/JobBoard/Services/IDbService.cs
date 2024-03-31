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

        int AddOffer(JobOffer offer);

        DbServiceActionStatus DeleteOffer(int id);

    }
}