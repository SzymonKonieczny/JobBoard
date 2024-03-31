using JobBoard.Models;

namespace JobBoard.Services
{
    public class DbService : IDbService
    {
        private DbContextJobBoard DbContext;
        public DbService(DbContextJobBoard cntxt)
        {
            DbContext = cntxt;
        }
        public DbServiceActionStatus DeleteOffer(int id)
        {
            JobOffer offer = DbContext.Offers.Find(id);
            if(offer == null)
            {
                return DbServiceActionStatus.Failure;
            }
            DbContext.Remove(offer);
            if (DbContext.SaveChanges() > 0)
            {
                return DbServiceActionStatus.Success;
            }
                return DbServiceActionStatus.Failure;

        }
        public int AddOffer(JobOffer offer)
        {
            DbContext.Add(offer);
            if (DbContext.SaveChanges() > 0)
            { 
            //succesful
            }

            return offer.Id;
        }

        public List<JobOffer> GetOffers(SearchOptions options)
        {
           return DbContext.Offers.ToList();
        }

    }
}
