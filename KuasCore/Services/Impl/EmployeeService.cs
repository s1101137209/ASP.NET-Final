using KuasCore.Dao;
using KuasCore.Dao.Impl;
using KuasCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuasCore.Services.Impl
{
    public class EmployeeService :IEmployeeService
    {
        public IEmployeeDao EmployeeDao { get; set; }

        public Employee AddEmployee(Employee employee)
        {
            EmployeeDao.AddEmployee(employee);
            return GetEmployeeByName(employee.Name);
        }

        public void UpdateEmployee(Employee employee)
        {
            EmployeeDao.UpdateEmployee(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            employee = EmployeeDao.GetEmployeeByName(employee.Name);

            if (employee != null)
            {
                EmployeeDao.DeleteEmployee(employee);
            }
        }

        public IList<Employee> GetAllEmployee()
        {
            return EmployeeDao.GetAllEmployee();
        }

        public Employee GetEmployeeByName(string name)
        {
            return EmployeeDao.GetEmployeeByName(name);
        }

        public Employee GetEmployeeById(string id)
        {
            return EmployeeDao.GetEmployeeById(id);
        }
    }
}
