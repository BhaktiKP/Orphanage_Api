using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class OrphanageContext : DbContext
    {
        public OrphanageContext()
            : base("name=OrphanageContext")
        {

        }
        public DbSet<User> Users { get; set; }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Books> Books { get; set; }

        public DbSet<Donation> Donations { get; set; }

        public DbSet<ManageDonation> ManageDonations { get; set; }
    }
}
