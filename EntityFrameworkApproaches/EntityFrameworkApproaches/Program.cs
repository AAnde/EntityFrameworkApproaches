using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DBFirstApproaches;

namespace EntityFrameworkApproaches
{
    class Program
    {
        static DBFirstOperations dbFirstOperations = new DBFirstOperations();
        #region Main
        static void Main(string[] args)
        {
            try
            {
                //Esp_GetEmp();
                //Esp_AddEmp();
                //Esp_UpdateEmp();
                //Esp_DeleteEmp();
                //Tsp_AddEmp();
                //Tsp_UpdateEmp();
                //Tsp_GetEmp();
                //Tsp_DeleteEmp();
                //CMP_GetEmp();
                //Slf_GetEmp();
                //TPH_GetContractEmp();
                //TPH_AddContractEmp();
                //TPH_DeleteContractEmp();
                //TPR_GetContractEmp();
                //TPR_GetPerEmp();
                TPR_AddContractEmp();
                Console.WriteLine("success..!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
        #endregion
        #region EntitySplit
        static void Esp_AddEmp()
        {
            EmployeeInfo emp = new EmployeeInfo()
            {
                Name = "ashok",
                Salary = 10000,
                MobileNo = "23456789",
                EmailId = "ashok.ande12@gmail.com"
            };
            dbFirstOperations.EntSplit_AddEmp(emp);
        }
        static void Esp_UpdateEmp()
        {
            EmployeeInfo emp = new EmployeeInfo()
            {
                EmpId = 2,
                Name = "ashokkumar",
                Salary = 20000,
                MobileNo = "23456789",
                EmailId = "ashok.ande122@gmail.com"
            };
            dbFirstOperations.EntSplit_UpdateEmp(emp);
        }
        static void Esp_GetEmp()
        {
            List<EmployeeInfo> emps = dbFirstOperations.EntSplit_GetEmp();
            if (emps.Count > 0)
            {
                foreach (var emp in emps)
                {
                    Console.WriteLine(emp.Name);
                }
            }
        }
        static void Esp_DeleteEmp()
        {
            dbFirstOperations.EntSplit_DeleteEmp(1);
        }
        #endregion
        #region TableSplit
        static void Tsp_AddEmp()
        {
            Employee emp = new Employee()
            {
                Name = "ashok",
                Salary = 10000
            };
            emp.EmployeeContactInfo = new EmployeeContactInfo()
            {
                MobileNo = "23456789",
                EmailId = "ashok.ande12@gmail.com"
            };
            dbFirstOperations.TblSplit_AddEmp(emp);
        }
        static void Tsp_UpdateEmp()
        {
            Employee emp = new Employee()
            {
                Id = 1,
                Name = "ashokkumar",
                Salary = 20000
            };
            emp.EmployeeContactInfo = new EmployeeContactInfo()
            {
                MobileNo = "23456789",
                EmailId = "ashok.ande122@gmail.com"
            };
            dbFirstOperations.TblSplit_UpdateEmp(emp);
        }
        static void Tsp_GetEmp()
        {
            List<Employee> emps = dbFirstOperations.TblSplit_GetEmp();
            if (emps.Count > 0)
            {
                foreach (var emp in emps)
                {
                    Console.WriteLine(emp.Name + ":" + emp.EmployeeContactInfo.MobileNo);
                }
            }
        }
        static void Tsp_DeleteEmp()
        {
            dbFirstOperations.TblSplit_DeleteEmp(1);
        }
        #endregion
        #region ConditionalMapping
        static void CMP_GetEmp()
        {
            List<ConditionalEmployee> emps = dbFirstOperations.CndMap_GetEmp();
            if (emps.Count > 0)
            {
                foreach (var emp in emps)
                {
                    Console.WriteLine(emp.Name);
                }
            }
        }
        #endregion
        #region SelfReferencing Association
        static void Slf_GetEmp()
        {
            List<EmployeeDetail> emps = dbFirstOperations.SlfRef_GetEmp();
            if (emps.Count > 0)
            {
                foreach (var emp in emps)
                {
                    string Name = string.Empty;
                    Name += emp.Name + ":";
                    Name += emp.Manager == null ? "Boss" : emp.Manager.Name;
                    Console.WriteLine(Name);
                }
            }
        }
        #endregion
        #region TPH
        static void TPH_GetContractEmp()
        {
            List<ContractEmployee> contractEmp = dbFirstOperations.TPH_GetContractEmployees();
            if (contractEmp.Count > 0)
            {
                foreach (var emp in contractEmp)
                {
                    Console.WriteLine(emp.Name);
                }
            }
        }
        static void TPH_GetPerEmp()
        {
            List<PermanentEmployee> permanentEmp = dbFirstOperations.TPH_GetPermanentEmployees();
            if (permanentEmp.Count > 0)
            {
                foreach (var emp in permanentEmp)
                {
                    Console.WriteLine(emp.Name);
                }
            }
        }
        static void TPH_AddContractEmp()
        {
            ContractEmployee emp = new ContractEmployee()
            {
                Name = "ash",
                HourSalary = 300,
                HoursWorked = 200
            };
            dbFirstOperations.TPH_AddContractEmployee(emp);
        }
        static void TPH_DeleteContractEmp()
        {
            dbFirstOperations.TPH_DeleteContractEmployee(8);
        }
        #endregion
        #region TPR
        static void TPR_GetContractEmp()
        {
            List<TPRContractEmployee> contractEmp = dbFirstOperations.TPR_GetContractEmployees();
            if (contractEmp.Count > 0)
            {
                foreach (var emp in contractEmp)
                {
                    Console.WriteLine(emp.Name);
                }
            }
        }
        static void TPR_GetPerEmp()
        {
            List<TPRPermanentEmployee> permanentEmp = dbFirstOperations.TPR_GetPermanentEmployees();
            if (permanentEmp.Count > 0)
            {
                foreach (var emp in permanentEmp)
                {
                    Console.WriteLine(emp.Name);
                }
            }
        }
        static void TPR_AddContractEmp()
        {
            //TPREmployee emp = new TPREmployee
            //{
            //    Name = "Hari"
               
            //};
           
            //dbFirstOperations.TPR_AddEmployee(emp);

            TPRContractEmployee emp = new TPRContractEmployee()
            {
               
               EmpId=7,
                HourPay = 300,
                HoursWorked = 200
            };
            dbFirstOperations.TPR_AddContractEmployee(emp);
        }
        #endregion
    }
}
