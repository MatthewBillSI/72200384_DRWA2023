using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UTS_DRWA.Models;

    public class TodoContextmapel : DbContext
    {
        public TodoContextmapel (DbContextOptions<TodoContextmapel> options)
            : base(options)
        {
        }

        public DbSet<UTS_DRWA.Models.Todomapel> Todomapel { get; set; } = default!;
    }
