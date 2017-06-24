using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace prjEBDSystem.Models
{
    /// <summary>
    /// =======================================================================
    /// Author:             Henryque, Eduardo
    /// Co-Author:          Passos, Lucas
    /// Create date:        02/06/2017
    /// Modification date:  04/06/2017
    /// Description:        Interface Data Acess Object
    /// Properties:         IdPeriod
    ///                     NamePeriod
    ///                     StartDate
    ///                     EndDate
    ///                     ClassEBD
    /// Constructors:       TPeriod()
    /// Dependencies:       System
    ///                     System.Collections.Generic
    /// =======================================================================
    /// </summary>
    public class Period
    {
        #region PROPERTIES
        [Key]
        [Display(Name = "Id")]
        public byte IdPeriod { get; set; }
        [Display(Name = "Nome")]
        public string NamePeriod { get; set; }
        [Display(Name = "Data de início")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Data de término")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Classes")]
        public List<ClassEBD> ClassEBD { get; set; }
        #endregion PROPERTIES

        #region CONSTRUCTORS
        public Period()
        {
            ClassEBD = new List<ClassEBD>();
        }

        public Period(DataRow row)
        {
            SelectPeriod(row);
        }
        #endregion CONSTRUCTORS

        #region METHODS

        private void SelectPeriod(DataRow row)
        {
            IdPeriod = byte.Parse(row["IdPeriod"].ToString());
            NamePeriod = row["NamePeriod"].ToString();
            StartDate = Convert.ToDateTime(row["StartDate"]);
            EndDate = Convert.ToDateTime(row["EndDate"]);
        }

        #endregion METHODS
    }
}