using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using DAL;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionShop"].ToString()))
            {
                UserProfileRepository rep = new UserProfileRepository(sqlCon);
                //int id = rep.AddUser(new User() { Name = "Yura", Phone = "123123123", Image = "1.jpg" });
               // string _name , _phone;
               // Console.Write("Name: ");

               //_name = Console.ReadLine();
               // Console.Write("Phone: ");

               // _phone = Console.ReadLine();
               // List<User> uu = rep.FindUser(new FindUser(){ Name = _name, Phone= _phone });
               // foreach (User item in uu)
               // {
               // Console.WriteLine(" " + item.Id +" "+ item.Name + " " + item.Phone + " " + item.Image );
               // }
                rep.DeleteUser(2);

            }
        }
    }
}
