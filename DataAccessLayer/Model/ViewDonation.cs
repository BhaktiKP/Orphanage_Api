using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class ViewDonation
    {
        public string UserName { get; set; }

        public string ContactNumber { get; set; }

        public string CategoryName { get;set; }

        public string Description { get; set; }

        public DateTime DonationDate { get; set; }
    }
}
