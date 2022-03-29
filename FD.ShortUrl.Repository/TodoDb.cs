using FD.ShortUrl.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.ShortUrl.Repository
{
    public class TodoDb : DbContext
    {
        public TodoDb(DbContextOptions<TodoDb> options)
            : base(options) { }

        public DbSet<Todo> Todos => Set<Todo>();

        public DbSet<Todo> TodoItems { get; set; } = null!;


        #region snippet1
        public async virtual Task<List<Todo>> GetAsync()
        {
            return await Todos
                .OrderBy(todo => todo.Name)
                .AsNoTracking()
                .ToListAsync();
        }
        #endregion

        #region snippet2
        public async virtual Task AddAsync(Todo message)
        {
            await Todos.AddAsync(message);
            await SaveChangesAsync();
        }
        #endregion

        #region snippet3
        public async virtual Task DeleteAllAsync()
        {
            foreach (Todo message in Todos)
            {
                Todos.Remove(message);
            }

            await SaveChangesAsync();
        }
        #endregion

        #region snippet4
        public async virtual Task DeleteAsync(int id)
        {
            var message = await Todos.FindAsync(id);

            if (message != null)
            {
                Todos.Remove(message);
                await SaveChangesAsync();
            }
        }
        #endregion

        public void Initialize()
        {
            Todos.AddRange(GetSeeding());
            SaveChanges();
        }

        public static List<Todo> GetSeeding()
        {
            return new List<Todo>()
            {
                new Todo(){ Name = "abc", Desc = "You're standing on my scarf." },
                new Todo(){ Name= "bc", Desc = "Would you like a jelly baby?" },
                new Todo(){ Name="c", Desc = "To the rational mind, nothing is inexplicable; only unexplained." }
            };
        }
    }
}
