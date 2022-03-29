using FD.ShortUrl.Domain;
using FD.ShortUrl.Repository;
using System.Collections.Generic;
 
namespace FD.ShortUrl.Test
{
    public static class Utilities
    {
        #region snippet1
        public static void InitializeDbForTests(TodoDb db)
        {
            db.Todos.AddRange(GetSeedingMessages());
            db.SaveChanges();
        }

        public static void ReinitializeDbForTests(TodoDb db)
        {
            db.Todos.RemoveRange(db.Todos);
            InitializeDbForTests(db);
        }

        public static List<Todo> GetSeedingMessages()
        {
            return new List<Todo>()
            {
                new Todo(){ Name="abc",   Desc = "TEST RECORD: You're standing on my scarf." },
                new Todo(){ Name="bc", Desc = "TEST RECORD: Would you like a jelly baby?" },
                new Todo(){ Name="c" ,Desc  = "TEST RECORD: To the rational mind, " +
                    "nothing is inexplicable; only unexplained." }
            };
        }
        #endregion
    }
}
