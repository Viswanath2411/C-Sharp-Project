using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinationData
{
    public class VaccinationInfo
    {
        public string Type { get; set; }

        public string Dose { get; set; }

        public DateTime DateOfVaccinated { get; set; }

        public VaccinationInfo(string Type , int regNo)
        {
            this.Type = Type;
            this.Dose = Program.doseType(regNo);
            this.DateOfVaccinated = DateTime.Now;
        }

        

    }

    
}


public enum VaccineType
{
    Covid_sheild,
    Co_Vaccine,
    Sputnic
}

public enum doseValue
{
    firstDose,
    secondDose
}