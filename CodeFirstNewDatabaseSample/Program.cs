using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstNewDatabaseSample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {


                // Create and save new Blog
                Console.WriteLine("Enter a name for a new Blog: ");
                var newBlogName = Console.ReadLine();

                var newBlog = new Blog { Name = newBlogName };
                db.Blogs.Add(newBlog);
                db.SaveChanges();

                // Display all Blogs from the database
                var query = from b in db.Blogs
                            orderby b.Name
                            select b;

                Console.WriteLine("All Blogs in the database: ");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }

                // Create and save new User
                Console.WriteLine("Enter a name for a new User: ");
                var newUsername = Console.ReadLine();

                var newUser = new User { Username = newUsername };
                db.Users.Add(newUser);
                db.SaveChanges();

                // Display all Users from the database
                var users = from b in db.Users
                            orderby b.Username
                            select b;

                Console.WriteLine("All Users in the database: ");
                foreach (var user in users)
                {
                    Console.WriteLine(user.Username);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
