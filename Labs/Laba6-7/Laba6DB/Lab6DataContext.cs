using Laba6DB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Laba6DB
{
    public class Lab6DataContext : DbContext
    {

        IConfiguration configuration;
        public Lab6DataContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public DbSet<Staff> Staff { get; set; }

        public DbSet<Appointments> Appointments { get; set; }

        public DbSet<Medication> Medications { get; set; }

        public DbSet<Patients> Patients { get; set; }

        public DbSet<PatientsMedication> PatientsMedications { get; set; }

        public DbSet<RefMedicationTypes> RefMedicationTypes { get; set; }

        //IConfiguration configuration;
        //public Lab6DataContext(IConfiguration configuration)
        //{
        //    this.configuration = configuration;
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=localhost;Database=Lab6;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }


    }
}