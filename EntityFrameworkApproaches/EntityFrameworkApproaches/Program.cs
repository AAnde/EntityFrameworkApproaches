using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DBFirstApproaches;
using DAL.CodeFirsApproaches;
using System.Data.Entity;

namespace EntityFrameworkApproaches
{
    class Program
    {
        static DBFirstOperations dbFirstOperations = new DBFirstOperations();
        static CodeFirstOperations codeFirstOperations = new CodeFirstOperations();
        static Program()
        {
            Intialize();
        }

        private static void Intialize()
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context>());
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<TblSplitContext>());
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<TphContext>());
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<TptContext>());
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CndContext>());
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MMContext>());
            
        }
        #region Main
        static void Main(string[] args)
        {
            //#region DB First
            //try
            //{
            //    //Esp_GetEmp();
            //    //Esp_AddEmp();
            //    //Esp_UpdateEmp();
            //    //Esp_DeleteEmp();
            //    //Tsp_AddEmp();
            //    //Tsp_UpdateEmp();
            //    //Tsp_GetEmp();
            //    //Tsp_DeleteEmp();
            //    //CMP_GetEmp();
            //    //Slf_GetEmp();
            //    //TPH_GetContractEmp();
            //    //TPH_AddContractEmp();
            //    //TPH_DeleteContractEmp();
            //    //TPR_GetContractEmp();
            //    //TPR_GetPerEmp();
            //    //TPR_AddContractEmp();
            //    //MM_AddCourse();
            //    //MM_AddStudent();
            //    //MM_AddCourseToStudent();
            //    MM_GetStudentsForCourse();
            //    Console.WriteLine("success..!");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //#endregion
            #region CodeFirst
            try
            {
                //GetEmp_Esp();
                //AddEmp_Esp();
                //GetEmp_Cnd();
                //AddEmp_Cnd();
                //AddEmp_Tsp();
                //GetEmp_Tph();
                //AddEmp_Tph();
                //GetEmp_Tpt();
                //AddEmp_Tpt();
                GetStudetns_MM();
                //AddStudentCourse_MM();
                Console.WriteLine("success..!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion
            Console.ReadLine();
        }
        #endregion
        #region DBFirst
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
            DAL.DBFirstApproaches.Employee emp = new DAL.DBFirstApproaches.Employee()
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
            DAL.DBFirstApproaches.Employee emp = new DAL.DBFirstApproaches.Employee()
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
            List<DAL.DBFirstApproaches.Employee> emps = dbFirstOperations.TblSplit_GetEmp();
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

                EmpId = 7,
                HourPay = 300,
                HoursWorked = 200
            };
            dbFirstOperations.TPR_AddContractEmployee(emp);
        }
        #endregion
        #region ManyToMany
        static void MM_AddCourse()
        {
            DAL.DBFirstApproaches.Course course = new DAL.DBFirstApproaches.Course
            {
                CourseName = "Java"
            };
            dbFirstOperations.AddCourse(course);
        }
        static void MM_AddStudent()
        {
            DAL.DBFirstApproaches.Student student = new DAL.DBFirstApproaches.Student
            {
                StudentName = "bhaskar"
            };
            dbFirstOperations.AddStudent(student);
        }
        static void MM_AddCourseToStudent()
        {
            dbFirstOperations.AddCourseToStudent(1, 2);

        }
        static void MM_GetStudentsForCourse()
        {
            DAL.DBFirstApproaches.Course course = dbFirstOperations.GetStudentsForCourse(1);
            foreach (DAL.DBFirstApproaches.Student student in course.Students)
            {
                Console.WriteLine(student.StudentName);
            }
        }
        #endregion
        #endregion
        #region CodeFirst
        #region EntitySplit
        static void GetEmp_Esp()
        {
            List<DAL.CodeFirsApproaches.Employee> emps = codeFirstOperations.Esp_GetEmp();
            if (emps.Count > 0)
            {
                foreach (var emp in emps)
                {
                    Console.WriteLine(emp.Name);
                }
            }
        }
        static void AddEmp_Esp()
        {
            DAL.CodeFirsApproaches.Employee emp = new DAL.CodeFirsApproaches.Employee
            {
                Name = "ashok",
                Salary = 12000,
                MobileNo = "9550937878",
                EmailId = "ashok.ande12@gmail.com"
            };
            codeFirstOperations.Esp_AddEmp(emp);
        }
        #endregion
        #region TableSplit
        static void GetEmp_Tsp()
        {
            List<DAL.CodeFirsApproaches.EmpInfo> emps = codeFirstOperations.Tsp_GetEmp();
            if (emps.Count > 0)
            {
                foreach (var emp in emps)
                {
                    Console.WriteLine(emp.Name+":"+emp.EmpContacInformation.MobileNo);
                }
            }
        }
        static void AddEmp_Tsp()
        {
            DAL.CodeFirsApproaches.EmpInfo emp = new DAL.CodeFirsApproaches.EmpInfo
            {
                Name = "ashok",
                Salary = 12000
            };
            emp.EmpContacInformation = new DAL.CodeFirsApproaches.EmpContactInfo {
                MobileNo = "9550937878",
                Emailid = "ashok.ande12@gmail.com"
            };
            codeFirstOperations.Tsp_AddEmp(emp);
        }
        #endregion
        #region ConditionMapping
        static void GetEmp_Cnd()
        {
            List<DAL.CodeFirsApproaches.CndEmployee> emps = codeFirstOperations.Cnd_GetEmp();
            if (emps.Count > 0)
            {
                foreach (var emp in emps)
                {
                    Console.WriteLine(emp.Name);
                }
            }
        }
        static void AddEmp_Cnd()
        {
            DAL.CodeFirsApproaches.CndEmployee emp = new DAL.CodeFirsApproaches.CndEmployee
            {
                Name = "ashok",
                Salary=12000,
                IsTerminated = true
            };
            codeFirstOperations.Cnd_AddEmp(emp);
        }
        #endregion
        #region TPH
        static void GetEmp_Tph()
        {
            List<DAL.CodeFirsApproaches.TphEmployee> emps = codeFirstOperations.Tph_GetEmp();
            if (emps.Count > 0)
            {
                foreach (var emp in emps)
                {
                    Console.WriteLine(emp.Name);
                }
            }
        }
        static void AddEmp_Tph()
        {
            DAL.CodeFirsApproaches.TphContractEmployee emp = new DAL.CodeFirsApproaches.TphContractEmployee
            {
                Name = "ashok",
                MobileNo = "9550937878",
                HourPay = 400,
                HoursWorked = 200
            };
            codeFirstOperations.Tph_AddEmp(emp);
        }
        #endregion
        #region TPT
        static void GetEmp_Tpt()
        {
            List<DAL.CodeFirsApproaches.TptEmployee> emps = codeFirstOperations.Tpt_GetEmp();
            if (emps.Count > 0)
            {
                foreach (var emp in emps)
                {
                    Console.WriteLine(emp.Name);
                }
            }
        }
        static void AddEmp_Tpt()
        {
            DAL.CodeFirsApproaches.TptContractEmployee emp = new DAL.CodeFirsApproaches.TptContractEmployee
            {
                Name = "ashok",
                MobileNo="9885955600",
                HourPay=500,
                HoursWorked=60
            };
            codeFirstOperations.Tpt_AddEmp(emp);
        }
        #endregion
        #region ManyToMany
        static void GetStudetns_MM()
        {
            List<DAL.CodeFirsApproaches.Student> students = codeFirstOperations.MM_GetStudents();
            if (students.Count > 0)
            {
                foreach (var student in students)
                {
                    Console.WriteLine(student.StudentName);
                    foreach (var course in student.Courses)
                    {
                        Console.WriteLine(course.CourseName);
                    }
                }
            }
        }
        static void AddStudentCourse_MM()
        {
            codeFirstOperations.MM_AddStudentCourse(1,1);
        }
        #endregion
        #endregion
    }
}
