using Core;
using KuasCore.Models;
using KuasCore.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spring.Context;
using Spring.Testing.Microsoft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuasCoreTests.Services.Impl
{
    [TestClass]
    public class EmployeeServiceUnitTest : AbstractDependencyInjectionSpringContextTests
    {

        #region Spring 單元測試必寫的內容

        override protected string[] ConfigLocations
        {
            get
            {
                return new String[] { 
                    //assembly://MyAssembly/MyNamespace/ApplicationContext.xml
                    "~/Config/KuasCoreDatabase.xml",
                    "~/Config/KuasCorePointcut.xml",
                    "~/Config/KuasCoreTests.xml" 
                };
            }
        }

        #endregion

        public IEmployeeService EmployeeService { get; set; }

        [TestMethod]
        public void TestEmployeeService_AddEmployee()
        {

            Employee employee = new Employee();
            employee.Id = "UnitTests";
            employee.Name = "單元測試";
            employee.Age = "請做出單元測試";
            EmployeeService.AddEmployee(employee);

            Employee dbEmployee = EmployeeService.GetEmployeeByName(employee.Name);
            Assert.IsNotNull(dbEmployee);
            Assert.AreEqual(employee.Name, dbEmployee.Name);

            Console.WriteLine("員工編號為 = " + dbEmployee.Id);
            Console.WriteLine("員工姓名為 = " + dbEmployee.Name);
            Console.WriteLine("員工年紀為 = " + dbEmployee.Age);

            EmployeeService.DeleteEmployee(dbEmployee);
            dbEmployee = EmployeeService.GetEmployeeByName(employee.Name);
            Assert.IsNull(dbEmployee);
        }

    }
}
