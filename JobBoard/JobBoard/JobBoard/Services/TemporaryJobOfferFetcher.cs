using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobBoard.Models;

namespace JobBoard.Services
{
    public class TemporaryJobOfferFetcher : IJobOfferFetcher
    {
        public List<JobOffer> GetOffers(SearchOptions options)
        {
            List<JobOffer> list = new List<JobOffer>();
            list.Add(new JobOffer("Oferta 1"));
            list.Add(new JobOffer("Oferta 2"));
            list.Add(new JobOffer("Oferta 3"));
            list.Add(new JobOffer("Oferta 4"));
            list.Add(new JobOffer("Oferta 5"));
            list.Add(new JobOffer("Oferta 6"));
            list.Add(new JobOffer("Oferta 7"));
            list.Add(new JobOffer("Oferta 8"));
            list.Add(new JobOffer("Oferta 9"));
            list.Add(new JobOffer("Oferta 10"));
            list.Add(new JobOffer("Oferta 11"));
            list.Add(new JobOffer("Oferta 12"));
            list.Add(new JobOffer("Oferta 13"));

            return list;
        }
    }
}