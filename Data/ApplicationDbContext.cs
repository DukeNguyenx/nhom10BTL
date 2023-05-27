using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QLNS.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<QLNS.Models.Nhansu> Nhansu { get; set; } = default!;

        public DbSet<QLNS.Models.Phongban> Phongban { get; set; } = default!;

        public DbSet<QLNS.Models.Hopdong> Hopdong { get; set; } = default!;

        public DbSet<QLNS.Models.ChucVu> ChucVu { get; set; } = default!;
    }
