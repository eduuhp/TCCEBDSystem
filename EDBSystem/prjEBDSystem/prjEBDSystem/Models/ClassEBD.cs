using System.Collections.Generic;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace prjEBDSystem.Models
{
    /// <summary>
    /// =======================================================================
    /// Author:             Henryque, Eduardo
    /// Co-Author:          Passos, Lucas
    /// Create date:        01/06/2017
    /// Modification date:  13/06/2017
    /// Description:        Database Transference Object
    /// Properties:         IdClassEBD
    ///                     NameClassEBD
    ///                     Department
    ///                     Period
    ///                     Users
    /// Constructors:       TClassEBD()
    /// Dependencies:       System.Collections.Generic
    /// =======================================================================
    /// </summary>
    public class ClassEBD
    {
        #region PROPERTIES
        [Key]
        [Display(Name = "Id")]
        public byte IdClassEBD { get; set; }
        [Display(Name = "Nome")]
        public string NameClassEBD { get; set; }
        [Display(Name = "Departamento")]
        public Department Departament { get; set; }
        [Display(Name = "Período")]
        public Period Period { get; set; }
        [Display(Name = "Matriculados")]
        public List<User> Users { get; set; }
        #endregion PROPERTIES

        #region CONSTRUCTORS
        public ClassEBD()
        {
            Departament = new Department();
            Period = new Period();
            Users = new List<User>();
        }

        public ClassEBD(DataRow row)
        {
            Departament = new Department();
            Period = new Period();

            SelectClassEBD(row);
        }
        #endregion CONSTRUCTORS

        private void SelectClassEBD(DataRow row)
        {
            IdClassEBD = byte.Parse(row["IdClassEBD"].ToString());
            NameClassEBD = row["NameClassEBD"].ToString();
            Departament.IdDepartment = byte.Parse(row["IdDepartment"].ToString());
            Departament.NameDepartment = row["NameDepartment"].ToString();
            Period.IdPeriod = byte.Parse(row["IdPeriod"].ToString());
            Period.NamePeriod = row["NamePeriod"].ToString();
        }
    }
}