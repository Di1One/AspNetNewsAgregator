﻿using AspNetNewsAgregator.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspNetNewsAgregator.DataBase
{
    public class GoodNewsAggregatorContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Source> Sources { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RefreshToken> RerfreshTokens { get; set; }

        public GoodNewsAggregatorContext(DbContextOptions<GoodNewsAggregatorContext> options) 
            : base(options)
        {
        }
    }
}
