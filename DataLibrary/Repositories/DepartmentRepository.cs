using DataLibrary.Contracts;
using DataLibrary.Entities;
using System.Data.SqlClient;

namespace DataLibrary.Repositories
{
    public class DepartmentRepository : IDepartmentContract
    {

        SqlConnection _connection = new SqlConnection("Data Source=HYD-7BLLNW3\\SQLEXPRESS;Initial Catalog=GEPDB;Integrated Security=True");
        SqlCommand _command = null;

        public void AddDepartment(Department department)
        {
            try
            {
                _command = new SqlCommand($"Insert into Department values ('{department.DeptNo}', '{department.DeptName}', '{department.DeptLocation}')", _connection);
                _connection.Open();
                _command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally { _connection.Close(); }
        }

        public void DeleteDepartment(string deptNo)
        {
            try
            {
                _command = new SqlCommand($"Delete from Department where DeptNo='{deptNo}'", _connection);
                _connection.Open();
                _command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally { _connection.Close(); }
        }

        public void EditDepartment(Department department)
        {
            try
            {
                _command = new SqlCommand($"Update Department set DeptName = '{department.DeptName}', DeptLocation = '{department.DeptLocation}' where  DeptNo = '{department.DeptNo}'", _connection);
                _connection.Open();
                _command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally { _connection.Close(); }
        }

        public List<Department> GetAllDepartments()
        {
            try
            {
                _command = new SqlCommand("Select * from Department", _connection);
                _connection.Open();
                SqlDataReader reader = _command.ExecuteReader();
                List<Department> departments = new List<Department>();
                while(reader.Read())
                {
                    departments.Add(new Department()
                    {
                        DeptNo = reader[0].ToString(),
                        DeptName = reader[1].ToString(),
                        DeptLocation = reader[2].ToString()
                    });
                }
                return departments;
            }
            catch (Exception)
            {
                throw;
            }
            finally { _connection.Close(); }
        }

        public Department GetDepartment(string deptNo)
        {
            try
            {
                _command = new SqlCommand($"Select * from Department where DeptNo='{deptNo}'", _connection);
                _connection.Open();
                SqlDataReader reader = _command.ExecuteReader();
                Department? department = new Department();
                if(reader.HasRows)
                {
                    reader.Read();
                    department = new Department()
                    {
                        DeptNo = reader[0].ToString(),
                        DeptName = reader[1].ToString(),
                        DeptLocation = reader[2].ToString(),
                     };
                }
                return department;
            }
            catch (Exception)
            {
                throw;
            }
            finally { _connection.Close(); }
        }
    }
}
