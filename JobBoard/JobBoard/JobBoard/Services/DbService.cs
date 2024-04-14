using JobBoard.Models;
using System.Linq;
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
        public int AddTag(Tag tag)
        {
            DbContext.Add(tag);
            if (DbContext.SaveChanges() > 0)
            {
                //succesful
            }
            

            return tag.Id;
        }
        public List<JobOffer> GetOffers()
        {
           return DbContext.Offers.ToList();
        }
        public List<Tag> GetTags()
        {
            return DbContext.Tags.ToList();

        }

        public IQueryable<JobOffer> GetOffersQueryable()
        {
            var t = DbContext.Offers.AsQueryable();
            return t;
        }

        public IQueryable<Tag> GetTagsQueryable()
        {
            return DbContext.Tags.AsQueryable();

        }

        public DbServiceActionStatus EditOffer( JobOffer offer)
        {

            DbContext.Offers.Update(offer);
            if (DbContext.SaveChanges() > 0)
            {
                return DbServiceActionStatus.Success;

            }
            return DbServiceActionStatus.Failure;

        }

        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }
    }
}
