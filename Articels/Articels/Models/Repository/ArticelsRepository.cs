using Articels.Data;
using Microsoft.EntityFrameworkCore;

namespace Articels.Models.Repository
{
    public class ArticelsRepository : ICRUD<Articelss>
    {
        private readonly ApplicationDbContext dB;

        public ArticelsRepository(ApplicationDbContext DB)
        {
            dB = DB;
        }
        public void Add(Articelss x)
        {
            dB.Articels.Add(x);
            dB.SaveChanges();
        }

        public void Delete(int id)
        {
            var x = find(id);
            dB.Remove(x);
            dB.SaveChanges();
        }

        public Articelss find(int id)
        {
            var x = dB.Articels.Find(id);
            return x;
        }

        public List<Articelss> List()
        {
            return dB.Articels.ToList();        
        }

        public void Update(Articelss entity)
        {
            dB.Articels.Update(entity);
            dB.SaveChanges();
        }
    }
}
