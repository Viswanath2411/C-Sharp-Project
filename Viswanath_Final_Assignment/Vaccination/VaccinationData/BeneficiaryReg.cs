using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinationData
{
    class BeneficiaryReg
    {
        public int RegNo { get; set; }

        private static int autoIncrementId = 1001;

        public string Name { get; set; }

        public long MobileNumber { get; set; }

        public string Address { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public List<VaccinationInfo> VaccinationDetail { get; set; }

        public BeneficiaryReg(string Name, int Age, string Gender, long MobileNumber, string City)
        {
            this.Name = Name;
            this.MobileNumber = MobileNumber;
            this.Address = City;
            this.Age = Age;
            this.Gender = Gender;
            this.RegNo = autoIncrementId;
            autoIncrementId++;

        }

        public static void nextDoseDueDate(string DoseType, DateTime DateOfVaccine)
        {
            DateTime DateOfVac = DateOfVaccine;
            switch (DoseType)
            {
                case "firstdose":
                    Console.WriteLine("The due date for the second dose is " + DateOfVac.AddDays(30));
                    break;

                case "seconddose":
                    Console.WriteLine("You have completed the vaccination course. Thanks for your participation in the vaccination drive.");
                    break;

                default:
                    Console.WriteLine("Invalid Type!");
                    break;
            }

        }






    }
}

public enum Gender
{
    Male,
    Female,
    Transgender
}
