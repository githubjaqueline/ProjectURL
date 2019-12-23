using Microsoft.EntityFrameworkCore;
using ProjectURL.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectURL.Data.Context
{
    public class ProjectURLContext:DbContext
    {

        public ProjectURLContext(DbContextOptions options):base(options)
        {

        }



        public DbSet<Url> dbSetUrl ;
        
    }
}
