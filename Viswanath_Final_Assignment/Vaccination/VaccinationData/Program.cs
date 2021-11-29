using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinationData
{
    class Program
    {
        public static List<BeneficiaryReg> Person = new List<BeneficiaryReg>();

        public static BeneficiaryReg[] person = new BeneficiaryReg[3];
        static void Main(string[] args)
        {

            BeneficiaryReg person1 = new BeneficiaryReg("viswa" , 21 , "Male" , 9597220829 , "Kambainallur");
            BeneficiaryReg person2 = new BeneficiaryReg("Divya", 19, "Female", 9916923486, "TinFactory");
            BeneficiaryReg person3 = new BeneficiaryReg("Pradeep", 20, "Male", 9080224289, "Ambur");

            person1.VaccinationDetail = new List<VaccinationInfo>();
            Person.Add(person1);

            person2.VaccinationDetail = new List<VaccinationInfo>();
            VaccinationInfo vac2 = new VaccinationInfo("Covaxin" , person2.RegNo);
            List<VaccinationInfo> VacList2 = new List<VaccinationInfo>();
            VacList2.Add(vac2);
            person2.VaccinationDetail.AddRange(VacList2);

            Person.Add(person2);


            person3.VaccinationDetail = new List<VaccinationInfo>();
            VaccinationInfo vac3 = new VaccinationInfo("Sputnic" , person3.RegNo);
            List<VaccinationInfo> VacList3 = new List<VaccinationInfo>();
            VacList3.Add(vac3);
            person3.VaccinationDetail.AddRange(VacList3);

            Person.Add(person3);

            displayMenu();


            

            Console.ReadKey();
        }

        public static void TakeVaccination(int regNo)
        {
            foreach (BeneficiaryReg values in Person)
            { 
                if (values.RegNo == regNo)
                {
                    

                    Console.WriteLine("Enter the vaccine type : \n 1.Covaxin \n 2.Covi-Sheild \n 3.Sputnic \n----------------------");
                    string Type = Console.ReadLine();

                    if(values.VaccinationDetail.Count == 0)
                    {
                        VaccinationInfo vac = new VaccinationInfo(Type , regNo);
                        List<VaccinationInfo> Vac = new List<VaccinationInfo>();
                        Vac.Add(vac);
                        values.VaccinationDetail.AddRange(Vac);
                    }
                    else
                    {
                        if(values.VaccinationDetail[0].Type == Type )
                        {
                            VaccinationInfo vac = new VaccinationInfo(Type , regNo);
                            List<VaccinationInfo> Vac = new List<VaccinationInfo>();
                            Vac.Add(vac);
                            values.VaccinationDetail.AddRange(Vac);
                        }
                        
                    }
                    
                }
            }
            VaccinationMenu(regNo);
          
        }

        public static void VaccineHistory(int regNo)
        {
            foreach (BeneficiaryReg pack in Person)
            {
                if (pack.RegNo == regNo)
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine(pack.RegNo);
                    Console.WriteLine(pack.Name);
                    Console.WriteLine(pack.Age);
                    Console.WriteLine(pack.Gender);
                    Console.WriteLine(pack.MobileNumber);
                    Console.WriteLine(pack.Address);

                    if (pack.VaccinationDetail.Count == 0)
                    {
                        Console.WriteLine("You did not take vaccine yet. please take vaccine!");
                        
                    }
                    else if (pack.VaccinationDetail.Count == 1)
                    {
                            Console.WriteLine(pack.VaccinationDetail[0].Type);
                            Console.WriteLine(pack.VaccinationDetail[0].Dose);
                            Console.WriteLine(pack.VaccinationDetail[0].DateOfVaccinated);
                    }
                    else if(pack.VaccinationDetail.Count == 2)
                    {
                        Console.WriteLine(pack.VaccinationDetail[1].Type);
                        Console.WriteLine(pack.VaccinationDetail[1].Dose);
                        Console.WriteLine(pack.VaccinationDetail[1].DateOfVaccinated);

                    }
                    Console.WriteLine("-----------------------------------");
                    VaccinationMenu(regNo);
                        
                    
                }
            }

        }

        

        public static string doseType(int regNo)
        {
            string dose ="";
            foreach (BeneficiaryReg Value in Person)
            {
                if (Value.RegNo == regNo)
                {
                    if (Value.VaccinationDetail.Count == 0)
                    {
                        return dose += "firstdose";

                    }
                    else if (Value.VaccinationDetail.Count == 1)
                    {
                        return dose += "seconddose";

                    }
                    else
                    {
                        Console.WriteLine("You have completed the vaccination course. Thanks for your participation in the vaccination drive.");
                    }
                }

            }


            return dose;
            
        }

        public static void displayMenu()
        {
            Console.WriteLine("Choose the action : \n 1.Beneficiary Details \n 2.Vaccination \n 3.Exit \n---------------------");
            int option = int.Parse(Console.ReadLine());

            switch(option)
            {
                case 1:
                    {
                        BeneficiaryDetails();
                        break;
                    }

                case 2:
                    {
                        Console.WriteLine("Enter your Register Number :");
                        int regNo = int.Parse(Console.ReadLine());

                        foreach (BeneficiaryReg forms in Person)
                        {
                            if(forms.RegNo == regNo)
                            {
                                VaccinationMenu(regNo);
                            }
                            
                        }
                        break;
                    }

                case 3:
                    break;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;

            }

        }

        public static void BeneficiaryDetails()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("1. Name :");
            Console.WriteLine("2. Age");
            Console.WriteLine("3. Gender (Male / Female / Transgender)");
            Console.WriteLine("4. Mobile Number");
            Console.WriteLine("5. City ");


            person[1] = new BeneficiaryReg
                (Console.ReadLine(),
                   int.Parse(Console.ReadLine()),
                   Console.ReadLine(),
                   long.Parse(Console.ReadLine()),
                   Console.ReadLine()
                );

            person[1].VaccinationDetail = new List<VaccinationInfo>();
            
            Person.Add(person[1]);

            Console.WriteLine(person[1].RegNo);

            Console.WriteLine("-----------------------------------");

            displayMenu();
        }

        public static void VaccinationMenu(int regNo)
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine("Your Register Number is matched. Choose the task? ");
            Console.WriteLine("1. Take Vaccine \n 2.Vaccination History \n 3.Next due date \n 4.Exit");
            Console.WriteLine("--------------------------");

            int choice = int.Parse(Console.ReadLine());

            switch(choice)
            {
                case 1:
                    TakeVaccination(regNo);
                    break;

                case 2:
                    VaccineHistory(regNo);
                    break;

                case 3:
                    {
                        foreach (BeneficiaryReg cons in Person)
                        {
                            if (cons.RegNo == regNo)
                            {
                                if (cons.VaccinationDetail.Count == 0)
                                {
                                    Console.WriteLine("You did not take vaccine yet. please take vaccine!");
                                    VaccinationMenu(cons.RegNo);
                                }
                                else if(cons.VaccinationDetail.Count == 1)
                                {
                                    BeneficiaryReg.nextDoseDueDate(cons.VaccinationDetail[0].Dose, cons.VaccinationDetail[0].DateOfVaccinated);
                                }
                                else
                                {
                                    BeneficiaryReg.nextDoseDueDate(cons.VaccinationDetail[1].Dose, cons.VaccinationDetail[1].DateOfVaccinated);
                                }
                            }
                        }
                        VaccinationMenu(regNo);
                        break;
                    }

                case 4:
                    displayMenu();
                    break;

                default:
                    {
                        Console.WriteLine("Invalid option! please enter correct option.");
                        displayMenu();
                        break;
                    }
            }

            
        }
    }
}
