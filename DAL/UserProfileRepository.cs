using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace DAL
{
    public class UserProfileRepository
    {
        SqlConnection _sqlCon;
        public UserProfileRepository(SqlConnection sqlCon)
        {
            _sqlCon = sqlCon;
            _sqlCon.Open();
            
            //string con = ConfigurationManager.ConnectionStrings["ConnectionShop"].ToString();

        }


        public int AddUser(User user)
        {
            string query = $"INSERT INTO [dbo].[UserProfiles] ([Name], [Image], [Telephone]) VALUES ('{user.Name}', '{user.Image}', '{user.Phone}')";
            SqlCommand command = new SqlCommand(query, _sqlCon);
            command.ExecuteNonQuery();
            command.CommandText = $"SELECT SCOPE_IDENTITY() as Id";
            var id = command.ExecuteScalar();
            return int.Parse(id.ToString());
        }

        public List<User> FindUser(FindUser findUser)
        {
            List<User> users = new List<User>();
            string query = $"SELECT [Id], [Name],[Image], [Telephone] FROM UserProfiles as up WHERE up.Telephone LIKE '%{findUser.Phone}%' AND up.Name LIKE '%{findUser.Name}%'";
            SqlCommand command = new SqlCommand(query, _sqlCon);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                users.Add(new User { Name = reader["Name"].ToString(), Phone = reader["Telephone"].ToString(), Image = reader["Image"].ToString(), Id = int.Parse(reader["Id"].ToString())});
            }
            return users;
        }

        public bool DeleteUser (int id)
        {
            string query = $"DELETE FROM UserProfiles WHERE Id = '{id}';";
            SqlCommand command = new SqlCommand(query, _sqlCon);
            int res = command.ExecuteNonQuery();
            if (res == 0)
                return false;
            else
                return true;


        }
        //public int GetLength()
        //{
        //    "SELECT COUNT(column_name) FROM table_name WHERE condition;"
        //}


    }
}
