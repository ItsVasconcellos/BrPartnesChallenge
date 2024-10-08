﻿using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infra.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Address> Addresses { get; set; }

    }
}
