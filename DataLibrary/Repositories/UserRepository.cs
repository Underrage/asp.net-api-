using DataLibrary.Contracts;
using DataLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Repositories
{
    public class UserRepository : IUserContract
    {
        SqlConnection _connection = new SqlConnection("Data Source=HYD-7BLLNW3\\SQLEXPRESS;Initial Catalog=GEPDB;Integrated Security=True");
        SqlCommand _command = null;

        public void Register(User user)
        {
            try
            {
                _command = new SqlCommand($"Insert into [User] values ('{user.Name}', '{user.Email}', '{user.Mobile}', '{user.Password}')", _connection);
                _connection.Open();
                _command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally { _connection.Close(); }
        }

        public User Validate(string email, string password) 
        {
            try
            {
                _command = new SqlCommand($"Select * from [User] where Email='{email}' and Password='{password}'", _connection);
                _connection.Open();
                SqlDataReader reader = _command.ExecuteReader();
                User? user = new User();
                if (reader.HasRows)
                {
                    reader.Read();
                    user = new User()
                    {
                        Name = reader[0].ToString(),
                        Email = reader[1].ToString(),
                        Mobile = reader[2].ToString(),
                        Password = reader[3].ToString()
                    };
                }

                return user;
            }
            catch (Exception)
            {

                throw;
            }
            finally { _connection.Close(); }

        }
    }
}
