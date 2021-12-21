using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DataAccessLayer.Model;
using DataAccessLayer;
using BusinessLayer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Orphanage_Api.Controllers
{
    public class UserController : ApiController
    {
        private UserBL db = new UserBL();

        [ResponseType(typeof(User))]
        [HttpPost]
        [Route("api/user/register")]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                RespMessage response = new RespMessage();
                response.Message = db.AddUser(user);
                return Ok(response);
            }
        }

        [HttpGet]
        [Route("api/user/login/{email}/{password}")]
        public IHttpActionResult login(string email, string password)
        {
            RespLogin response = new RespLogin();

            User u = db.login(email, password);
            if (u != null)
            {
                response.UserID = u.UserID.ToString();
                response.EmailID = u.EmailID;
                response.Message = "Login successful";
                response.Token = generateToken();
            }
            else
            {
                response.UserID = "0";
                response.EmailID = "";
                response.Message = "Invalid email id or password";
            }
            return Ok(response);
        }


        [HttpGet]
        [Route("api/user/orphanLogin/{email}/{password}")]
        public IHttpActionResult orphanLogin(string email, string password)
        {
            RespLogin response = new RespLogin();

            User u = db.orphanLogin(email, password);
            if (u != null)
            {
                if (u.Flag == 1)
                {
                    response.UserID = u.UserID.ToString();
                    response.EmailID = u.EmailID;
                    response.Message = "Login successful";
                }
                else if (u.Flag == 0)
                {
                    response.UserID = u.UserID.ToString();
                    response.EmailID = u.EmailID;
                    response.Message = "Account not approved";
                }
                else if (u.Flag == 2) 
                {
                    response.UserID = u.UserID.ToString();
                    response.EmailID = u.EmailID;
                    response.Message = "Account request rejected";
                }
            }
            else
            {
                response.UserID = "0";
                response.EmailID = "";
                response.Message = "Invalid email id or password";
            }
            return Ok(response);
        }


        [Authorize]
        [HttpGet]
        [Route("api/user/getCategory/{type}")]
        public List<Category> getCategory(string type)
        {
            return db.getCategory(type);
        }

        [Authorize]
        [HttpPost]
        [Route("api/user/donate")]
        public IHttpActionResult donate(Donation d)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                RespMessage response = new RespMessage();
                response.Message = db.donate(d);
                return Ok(response);
            }
        }

        [Authorize]
        [HttpGet]
        [Route("api/user/manageDonation")]
        public List<ManageDonation> manageDonation()
        {
            return db.manageDonation();
        }

        // GET api/User
        //public IQueryable<User> GetUsers()
        //{
        //    return db.Users;
        //}

        //// GET api/User/5
        //[ResponseType(typeof(User))]
        //public IHttpActionResult GetUser(int id)
        //{
        //    User user = db.Users.Find(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(user);
        //}

        // PUT api/User/5
        //public IHttpActionResult PutUser(int id, User user)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != user.UserID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(user).State = System.Data.EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UserExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST api/User
        //[ResponseType(typeof(User))]
        //public IHttpActionResult PostUser(User user)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Users.Add(user);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = user.UserID }, user);
        //}

        //// DELETE api/User/5
        //[ResponseType(typeof(User))]
        //public IHttpActionResult DeleteUser(int id)
        //{
        //    User user = db.Users.Find(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Users.Remove(user);
        //    db.SaveChanges();

        //    return Ok(user);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool UserExists(int id)
        //{
        //    return db.Users.Count(e => e.UserID == id) > 0;
        //}

        public string generateToken()
        {
            string securityKey = "qwerty0982412412412";

            var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
            var signInCred = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                    issuer: "example@domain.in",
                    audience: "Users",
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: signInCred
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}