using Articels.Data;

namespace Articels.Models.Repository
{
    public class OpinionRepository : ICRUD<Openines>
    {
        private readonly ApplicationDbContext db;

        public OpinionRepository(ApplicationDbContext Db)
        {
            db = Db;
        }
        public void Add(Openines entity)
        {
            db.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var opinion = find(id);
            db.Openines.Remove(opinion);
            db.SaveChanges();
        }

        public Openines find(int id)
        {
            return db.Openines.Find(id);
        }

        public List<Openines> List()
        {
            return db.Openines.ToList();
        }

        public void Update(Openines entity)
        {
            db.Openines.Update(entity);
            db.SaveChanges();
        }
    }
}
