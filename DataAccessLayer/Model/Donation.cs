using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class Donation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DonationID { get; set; }

        public int CategoryID { get; set; }

        public string Description { get; set; }

        public DateTime DonationDate { get; set; }

        public int UserID { get; set; }
    }
}
