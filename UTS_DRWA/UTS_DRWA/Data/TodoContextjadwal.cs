using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UTS_DRWA.Models;

    public class TodoContextjadwal : DbContext
    {
        public TodoContextjadwal (DbContextOptions<TodoContextjadwal> options)
            : base(options)
        {
        }

        public DbSet<UTS_DRWA.Models.jadwalguru> jadwalguru { get; set; } = default!;
    }
