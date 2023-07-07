using DataLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Contracts
{
    public interface IDepartmentContract
    {
        void AddDepartment(Department department);

        void DeleteDepartment(string DeptNo);

        void EditDepartment(Department department);

        List<Department> GetAllDepartments();

        Department GetDepartment(string DeptNo);
    }
}
