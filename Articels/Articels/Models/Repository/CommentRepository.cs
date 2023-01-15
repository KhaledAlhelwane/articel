using Articels.Data;

namespace Articels.Models.Repository
{
    public class CommentRepository : ICRUD<Comment>
    {
        private readonly ApplicationDbContext db;

        public CommentRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void Add(Comment entity)
        {
            db.Comments.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var comment = find(id);
            db.Comments.Remove(comment);
            db.SaveChanges();
        
        }

        public Comment find(int id)
        {
            return db.Comments.Find(id);
        }

        public List<Comment> List()
        {
            return db.Comments.ToList();
        }

        public void Update(Comment entity)
        {
            db.Comments.Update(entity);
            db.SaveChanges();
        }
    }
}
