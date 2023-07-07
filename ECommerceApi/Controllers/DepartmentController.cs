using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataLibrary;
using DataLibrary.Contracts;
using DataLibrary.Repositories;
using DataLibrary.Entities;

namespace ECommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentContract _departmentContract;
        public DepartmentController()
        {
            _departmentContract = new DepartmentRepository();
        }

        [HttpGet, Route("GetAllDepartments")]

        public IActionResult GetAll() 
        {
            try
            {
                List<Department> departments = _departmentContract.GetAllDepartments();
                return StatusCode(200, departments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet, Route("GetDepartment/{DeptNo}")]

        public IActionResult GetDepartment(string DeptNo) 
        {
            try
            {
                Department department = _departmentContract.GetDepartment(DeptNo);
                return StatusCode(200, department);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost, Route("AddDepartment")]

        public IActionResult AddDepartment(Department department)
        {
            try
            {
                _departmentContract.AddDepartment(department);
                return StatusCode(200, $"{department.DeptName} added!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut, Route("EditDepartment")]

        public IActionResult EditDepartment(Department department) 
        {
            try
            {
                _departmentContract.EditDepartment(department);
                return StatusCode(200, $"{department.DeptNo} updated!");

            }
            catch (Exception ex)
            {   
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete, Route("DeleteDepartment/{DeptNo}")]

        public IActionResult DeleteDepartment(string DeptNo) 
        {
            try
            {
                _departmentContract.DeleteDepartment(DeptNo);
                return StatusCode(200, $"{DeptNo} deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message );
            }
        }
    }
}
