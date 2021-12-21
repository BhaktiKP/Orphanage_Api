using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class ManageDonation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ManageDonationID { get; set; }

        public string DonationName { get; set; }

        public string DonationImage { get; set; }

        public string RouterLink { get; set; }

        public int Flag { get; set; }
    }
}
