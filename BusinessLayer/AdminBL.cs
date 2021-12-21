using DataAccessLayer;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class AdminBL
    {
        private OrphanageContext db = new OrphanageContext();
        public Admin adminLogin(string username, string password)
        {
            Admin admin = db.Admins.SingleOrDefault(a => a.Username == username && a.Password == password);
            return admin;
        }

        public List<ViewDonation> viewDonation()
        {
            return db.Database.SqlQuery<ViewDonation>("select concat(u.FirstName,' ',u.LastName) as [UserName],u.[ContactNumber],c.[CategoryName],d.[Description],d.[DonationDate] from Users u inner join Donations d on u.UserID = d.UserID inner join Categories c on c.CategoryID = d.CategoryID").ToList();
        }

        public List<User> getOrphanRequest()
        {
            return db.Database.SqlQuery<User>("select * from users where UserType = 'Orphan' and Flag = 0").ToList();
        }

        public string updateFlag(string UserID, string flag)    // accept or reject orphan
        {
            try
            {
                int user_id = Convert.ToInt32(UserID);
                int _flag = Convert.ToInt32(flag);

                User user = db.Users.SingleOrDefault(u => u.UserID == user_id);
                user.Flag = _flag;
                int rowsAffected = db.SaveChanges();

                if (rowsAffected == 0)
                    return "Something went wrong";
                else
                    return "Status updated";
            }
            catch(Exception ex)
            {
                return ex.ToString();
            }
        }

        public List<User> getUserList()
        {
            return db.Database.SqlQuery<User>("select * from users where Flag = 1").ToList();
        }

        public List<ManageDonation> manageDonationList()        // active donation list to show on user side
        {
            return db.ManageDonations.ToList();
        }

        public string manageDonation(List<ManageDonation> manageDonation)
        {
            try
            {
                int rowsAffected = 0;
                int result = db.Database.ExecuteSqlCommand("delete from ManageDonations");

                if (result > 0)
                {
                    foreach (ManageDonation d in manageDonation)
                    {
                        db.ManageDonations.Add(d);
                        rowsAffected += db.SaveChanges();
                    }
                }
                else
                    return "Something went wrong while deleting";

                if (rowsAffected == 0)
                    return "Something went wrong";
                else
                    return "List updated";
            }
            catch(Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
