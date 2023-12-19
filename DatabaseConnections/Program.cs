using DatabaseConnections.Model;

namespace DatabaseConnections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context1 = new DatabaseContext())
            {

                //var conn =
                //    ((EntityConnection)
                //        ((IObjectContextAdapter)context1).ObjectContext.Connection)
                //            .StoreConnection;

                //using (var context2 = new DatabaseContext(conn, contextOwnsConnection: false))
                //{
                //    context2.Database.ExecuteSqlCommand(
                //        @"UPDATE Blogs SET Rating = 5" +
                //        " WHERE Name LIKE '%Entity Framework%'");

                //    var query = context1.Posts.Where(p => p.Blog.Rating > 5);
                //    foreach (var post in query)
                //    {
                //        post.Title += "[Cool Blog]";
                //    }
                //    context1.SaveChanges();
                //}
            }
        }
    }
}
