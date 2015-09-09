﻿using System;
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
                Esp_DeleteEmp();
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
                EmpId=2,
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
    }
}