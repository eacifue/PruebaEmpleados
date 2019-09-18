using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MG.Empleados.AD;
using MG.Empleados.DT;
using System.Threading.Tasks;

namespace MG.Empleados.BM
{
    public class BMEmpleados
    {


        public List<DTEmpleado> ConsultarEmpleado(int Id)
        {

            List<DTRespuestaApi> ListaEmpleadosApi = new List<DTRespuestaApi>();
            List<DTEmpleado> ListaEmpleados = new List<DTEmpleado>();

            BMData objData = new BMData();
            
            
            ListaEmpleadosApi = objData.ConsultarData();

            ListaEmpleados = LlenarEmpleado(ListaEmpleadosApi);

            return   (from em in ListaEmpleados
                        where em.id.Equals(Id)
                        select em).ToList();

        }

        public List<DTEmpleado> ConsultarEmpleado()
        {

            List<DTRespuestaApi> ListaEmpleadosApi = new List<DTRespuestaApi>();
            List<DTEmpleado> ListaEmpleados = new List<DTEmpleado>();
            BMData objData = new BMData();


            ListaEmpleadosApi = objData.ConsultarData();

            ListaEmpleados = LlenarEmpleado(ListaEmpleadosApi);
            return (from em in ListaEmpleados
                    select em).ToList();

        }


        private List<DTEmpleado> LlenarEmpleado(List<DTRespuestaApi> ListaEmpleadosApi)
        {

            List<DTEmpleado> _ListaEmpleados = new List<DTEmpleado>();
            try
            {
                foreach (DTRespuestaApi empleado in ListaEmpleadosApi)
                {
                    DTEmpleado Empleado = new DTEmpleado();
                    Empleado.id = empleado.id;
                    Empleado.name = empleado.name;
                    Empleado.contractTypeName = empleado.contractTypeName;
                    Empleado.roleId = empleado.roleId;
                    Empleado.roleName = empleado.roleName;
                    Empleado.roleDescription = empleado.roleDescription;
                    Empleado.hourlySalary = empleado.hourlySalary;
                    Empleado.monthlySalary = empleado.monthlySalary;
                    if (Empleado.contractTypeName == CreadorSalarioAnual.Horas)
                    {
                        CalcularSalario objSalario = CreadorSalarioAnual.CalcularSalarioAnual(CreadorSalarioAnual.Horas);
                        Empleado.yearSalary = objSalario.SalarioAnual(Empleado.hourlySalary);
                    }
                    else
                    {
                        CalcularSalario objSalario = CreadorSalarioAnual.CalcularSalarioAnual(CreadorSalarioAnual.Mensual);
                        Empleado.yearSalary = objSalario.SalarioAnual(Empleado.monthlySalary);

                    }


                    _ListaEmpleados.Add(Empleado);
                }
            }
            catch (Exception ex)
            {

            }

            return _ListaEmpleados;
        }



        public abstract class CalcularSalario
        {
            public abstract double SalarioAnual(double Salario);

        }
        class ContratoMensual : CalcularSalario
        {
            public override double SalarioAnual(double SalarioMensual)
            {
                double Salario = SalarioMensual * 12;
                return Salario;
            }

        }


        class ContratoHoras : CalcularSalario
        {
            public override double SalarioAnual(double SalarioHOras)
            {
                double Salario = 120 * SalarioHOras * 12;
                return Salario;
            }

        }

        public class CreadorSalarioAnual
        {
            public const string Mensual = "MonthlySalaryEmployee";
            public const string Horas = "HourlySalaryEmployee";

            public static CalcularSalario CalcularSalarioAnual(string Tipo)
            {

                switch (Tipo)
                {
                    case Mensual:
                        return new ContratoMensual();
                    case Horas:
                        return new ContratoHoras();
                    default: return null;

                }



            }

        }

    }

    


}

