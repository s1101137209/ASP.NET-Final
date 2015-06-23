using KuasCore.Dao;
using KuasCore.Models;
using KuasCore.Services.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spring.Testing.Microsoft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuasCoreTests.Dao
{
    [TestClass]
    public class EmployeeDaoUnitTest : AbstractDependencyInjectionSpringContextTests
    {

        #region Spring 單元測試必寫的內容

        override protected string[] ConfigLocations
        {
            get
            {
                return new String[] { 
                    "~/Config/KuasCoreDatabase.xml",
                    "~/Config/KuasCorePointcut.xml",
                    "~/Config/KuasCoreTests.xml" 
                };
            }
        }

        #endregion

        public IEmployeeDao EmployeeDao { get; set; }


        [TestMethod]
        public void TestEmployeeDao_AddEmployee()
        {
            Employee employee = new Employee();
            employee.Id = "1101137251";
            employee.Name = "蔣定文";
            employee.Age = "12";
            EmployeeDao.AddEmployee(employee);

            Employee dbEmployee = EmployeeDao.GetEmployeeByName(employee.Name);
            Assert.IsNotNull(dbEmployee);
            Assert.AreEqual(employee.Name, dbEmployee.Name);

            Console.WriteLine("員工編號為 = " + dbEmployee.Id);
            Console.WriteLine("員工姓名為 = " + dbEmployee.Name);
            Console.WriteLine("員工年紀為 = " + dbEmployee.Age);

            EmployeeDao.DeleteEmployee(dbEmployee);
            dbEmployee = EmployeeDao.GetEmployeeByName(employee.Name);
            Assert.IsNull(dbEmployee);
        }

    }
}
