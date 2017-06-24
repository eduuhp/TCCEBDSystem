using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace prjEntity
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
    public class TClassEBD
    {
        #region PROPERTIES
        [Key]
        public byte IdClassEBD { get; set; }
        public string NameClassEBD { get; set; }
        public TDepartment Departament { get; set; }
        public TPeriod Period { get; set; }
        public List<TUser> Users { get; set; }
        #endregion PROPERTIES

        #region CONSTRUCTORS
        public TClassEBD()
        {
            Departament = new TDepartment();
            Period = new TPeriod();
            Users = new List<TUser>();
        }

        public TClassEBD(DataRow row)
        {
            Departament = new TDepartment();
            Period = new TPeriod();

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
