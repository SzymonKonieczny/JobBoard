using JobBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobBoard.Services
{
    public interface IJobOfferFetcher
    {
        List<JobOffer> GetOffers(SearchOptions options);
    }
}