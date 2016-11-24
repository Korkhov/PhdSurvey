using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace PhdSurvey.Models
{
    public class PhdSurveyContext : DbContext
    {
        public PhdSurveyContext(DbContextOptions<PhdSurveyContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Survey> Surveys { get; set; }
    }
}
