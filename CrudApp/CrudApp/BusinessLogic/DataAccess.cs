using Dapper;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using CrudApp.Common;
using CrudApp.BusinessLogic;
using System.Data.SqlClient;

namespace CrudApp.BusinessLogic
{
    public class DataAccess
    {
        public bool CheckCredentials(string user, string password, ref Admin admin)
        {
            string query = $"SELECT admin_id, user_admin FROM admins WHERE user_admin = '{user}' AND password = HASHBYTES('SHA2_256','{password}')";
            using (IDbConnection connection = new SqlConnection(Helpers.GetConnectionString("CrudDB")))
            {
                var result = connection.Query(query).ToList();

                if (result.Count == 1)
                {
                    admin = new Admin(result[0].admin_id, result[0].user_admin);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void RefreshUsersGridView(DataGridView dataGridView)
        {
            string query = $"SELECT * FROM users";
            using (IDbConnection connection = new SqlConnection(Helpers.GetConnectionString("CrudDB")))
            {
                var result = connection.Query(query).ToList();
                foreach (var elem in result)
                    dataGridView.Rows.Add(elem.user_id, elem.username, elem.firstname, elem.lastname, "Edit/Delete");
            }
        }

        public User SelectUserWithUserId(int userID)
        {
            User searchedUser = new User();
            string query = $"SELECT user_id, username, firstname, lastname FROM users WHERE user_id = {userID}";
            using (IDbConnection connection = new SqlConnection(Helpers.GetConnectionString("CrudDB")))
            {
                var result = connection.Query(query).ToList();
                if (result.Count == 1)
                {
                    searchedUser = new User(result[0].user_id, result[0].username, result[0].firstname, result[0].lastname);
                }
                return searchedUser;
            }
        }

        public void InsertNewUser(User user)
        {
            string query = $"INSERT INTO users (username, firstname, lastname, password) VALUES (@username, @firstname, @lastname, HASHBYTES('SHA2_256', @password))";
            using (IDbConnection connection = new SqlConnection(Helpers.GetConnectionString("CrudDB")))
            {
                var result = connection.Execute(query, new { username = user.UserName, firstname = user.FirstName, lastname = user.LastName, password = user.Password });
            }
        }

        public void DeleteUserWithID(int id)
        {
            string query = $"DELETE FROM users WHERE user_id = {id}";
            using (IDbConnection connection = new SqlConnection(Helpers.GetConnectionString("CrudDB")))
            {
                var result = connection.Execute(query);
            }
        }

        public void UpdateExistingUser(User user)
        {
            using (IDbConnection connection = new SqlConnection(Helpers.GetConnectionString("CrudDB")))
            {
                string query = $"UPDATE users " +
                               $"SET username = @username, firstname = @firstname, lastname = @lastname, password = HASHBYTES('SHA2_256', @password) " +
                               $"WHERE user_id = @id";

                var param = new
                {
                    username = user.UserName,
                    firstname = user.FirstName,
                    lastname = user.LastName,
                    password = user.Password,
                    id = user.UserId
                };

                var result = connection.Execute(query, param);
            }

        }

    }
}
