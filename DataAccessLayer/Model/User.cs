using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailID { get; set; }

        public string Gender { get;set;}

        public string ContactNumber { get; set; }

        public string Address { get; set; }

        public string Password { get; set; }

        public string UserType { get; set; }

        public int Flag { get; set; }
    }
}
