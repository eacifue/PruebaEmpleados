using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Empleados.DT
{
    public class DTEmpleado: DTRespuestaApi
    {

        private double yearSalaryField { get; set; }


        public double yearSalary
        {
            get
            {
                return this.yearSalaryField;
            }
            set
            {
                this.yearSalaryField = value;
            }
        }
    }
}
