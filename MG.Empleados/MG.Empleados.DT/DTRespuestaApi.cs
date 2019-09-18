

namespace MG.Empleados.DT
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DTRespuestaApi
    {

        private int idField = 0;
        private string  nameField = String.Empty;
        public string contractTypeNameField = String.Empty;
        private int roleIdField = 0;
        private string roleNameField = String.Empty;
        private string roleDescriptionField = String.Empty;
        private double hourlySalaryField = 0;
        private double monthlySalaryField = 0;

        public int id {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
        public string contractTypeName
        {
            get
            {
                return this.contractTypeNameField;
            }
            set
            {
                this.contractTypeNameField = value;
            }
        }
        public int roleId
        {
            get
            {
                return this.roleIdField;
            }
            set
            {
                this.roleIdField = value;
            }
        }
        public string roleName
        {
            get
            {
                return this.roleNameField;
            }
            set
            {
                this.roleNameField = value;
            }
        }
        public string roleDescription
        {
            get
            {
                return this.roleDescriptionField;
            }
            set
            {
                this.roleDescriptionField = value;
            }
        }
        public double hourlySalary
        {
            get
            {
                return this.hourlySalaryField;
            }
            set
            {
                this.hourlySalaryField = value;
            }
        }
        public double monthlySalary
        {
            get
            {
                return this.monthlySalaryField;
            }
            set
            {
                this.monthlySalaryField = value;
            }
        }


    }
}
