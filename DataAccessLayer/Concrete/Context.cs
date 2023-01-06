﻿using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("server= ; database= ;Encrypt=False; User ID=sa; Password=1234");
        }
        public DbSet<Etkinlik> etkinlikler { get; set; }
        public DbSet<Tur> turler { get; set; }
        public DbSet<Salon> salonlar { get; set; }
        public DbSet<Seyirci> seyirciler { get; set; }
        public DbSet<Seans> seansler  { get; set; }
        public DbSet<Bilet> biletler { get; set; }
        public DbSet<Admin> adminler { get; set; }
    }
}