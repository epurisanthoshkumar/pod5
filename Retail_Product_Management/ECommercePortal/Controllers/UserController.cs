using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ECommercePortal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace ECommercePortal.Controllers
{
   /* [Route("api/[controller]")]*/

   /*[ApiController]*/
    public class UserController : Controller
    {
        private readonly IConfiguration _configuration;
        EcommerceDbContext context;
        Uri baseaddress = new Uri("http://localhost:50900/api");
        
        HttpClient client;
        public UserController(IConfiguration configuration)
        {
            client = new HttpClient();
            client.BaseAddress = baseaddress;
            _configuration = configuration;
            _configuration = configuration;
        }

       


        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Auth(User user)
        {
            string data = JsonConvert.SerializeObject(user);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response;
            try
            {
                response = client.PostAsync(client.BaseAddress + "/Users/Authenticate", content).Result;
            }
            catch
            {
                return RedirectToAction("Error");
            }
            if (response.IsSuccessStatusCode)
            {
                string token = response.Content.ReadAsStringAsync().Result;

                if (token != null)
                {
                    TokenInfo.StringToken = token;
                    TokenInfo.Username = user.Username;
                    //TokenInfo.UserID = user.UserID;
                    User user1 = new User();
                    HttpResponseMessage response1 = client.GetAsync(client.BaseAddress + "/users/GetUserDetails?username=" + user.Username).Result;
                    string result = response1.Content.ReadAsStringAsync().Result;
                    user1 = JsonConvert.DeserializeObject<User>(result);
                    TokenInfo.Username = user1.Username;                   
                    TokenInfo.UserID = user1.UserID;
                    return RedirectToAction("Index", "Customer");
                    //TokenInfo.username = user.username;
                   // return RedirectToAction("Detail", "User",user.UserID);
                    //return RedirectToAction("Index", "Customer");
                }
                else
                {
                    return Unauthorized();
                }
            }
            /*TokenInfo.StringToken = "";
            TokenInfo.UserID = 0;
            TokenInfo.username = "";*/

            return RedirectToAction("Login");

        }
        public IActionResult Logout()
        {
            TokenInfo.StringToken = null;
            TokenInfo.UserID = 0;
            TokenInfo.Username = null;

            return RedirectToAction("Login");
        }
        public ActionResult Error()
        {
            return View();
        }
        [HttpPost]
      
        public IActionResult Reg([FromBody] Register reg)
        {
            /*Register data = JsonConvert.DeserializeObject<Register>(reg);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");*/
            string query = @"Insert into Register values('"+reg.userid+"','"+reg.Username+"','"+reg.Email+"','"+reg.password+"','"+reg.address+@"')";
            DataTable table = new DataTable();
            string sqlsata = _configuration.GetConnectionString("DBConnection");
            SqlDataReader myReader;
            using(SqlConnection mycon=new SqlConnection(sqlsata))
            {
                mycon.Open();
                using(SqlCommand myCommand = new SqlCommand(query,mycon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    mycon.Close();
                }
            }
            return Redirect("http://localhost:58905/");
        }

        [HttpPost]
        
      /*public async Task<ActionResult<Register>> Register(Register reg)
        {
            
            context.Register.Add(reg);
            await context.SaveChangesAsync();
            return RedirectToAction("Login");
        }*/

  /*      }*/
        [HttpPost]
       
        public async Task<IActionResult> RegisterD(Register register)
        {

            using (var httpclient = new HttpClient())
            {
                httpclient.BaseAddress = new Uri("http://localhost:50900/");
                string data = JsonConvert.SerializeObject(register);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpclient.PutAsync(httpclient.BaseAddress + "api/Users/RegisterR/" + register.userid + "/" + register.Username+"/"+register.Email+"/"+register.password+"/"+register.address, content);
                if (response.IsSuccessStatusCode)
                {
                    Register reg = new Register();
                    reg.userid = register.userid;
                    reg.Username = register.Username;
                    reg.Email = register.Email;
                    reg.password = register.password;
                    reg.address = register.address;
                   
                    //context.Register.Add(reg);
                    context.SaveChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    return View("Invalid");
                }
            }
        }
        [HttpPost]
        public ActionResult GetUserDetails(string username)
        {
            User user = new User();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Users/GetUserDetails?username=" +username).Result;
            string result = response.Content.ReadAsStringAsync().Result;
            user = JsonConvert.DeserializeObject<User>(result);
            TokenInfo.Username = user.Username;
            TokenInfo.UserID = user.UserID;
            return RedirectToAction("Index", "Customer");
        }
    }
}
