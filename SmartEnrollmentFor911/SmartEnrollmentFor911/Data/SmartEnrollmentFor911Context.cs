using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartEnrollmentFor911.Models;

namespace SmartEnrollmentFor911.Models
{
    public class SmartEnrollmentFor911Context : DbContext
    {
        public SmartEnrollmentFor911Context (DbContextOptions<SmartEnrollmentFor911Context> options)
            : base(options)
        {
        }

        public DbSet<SmartEnrollmentFor911.Models.CrimeSurvey> CrimeSurvey { get; set; }

        public DbSet<SmartEnrollmentFor911.Models.SmartEnrollmentAPI> SmartEnrollmentAPI { get; set; }
    }
}
