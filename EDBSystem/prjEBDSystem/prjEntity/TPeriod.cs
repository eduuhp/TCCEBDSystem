using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace prjEntity
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
    public class TPeriod
    {
        #region PROPERTIES
        public byte IdPeriod { get; set; }
        public string NamePeriod { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<TClassEBD> ClassEBD { get; set; }
        #endregion PROPERTIES

        #region CONSTRUCTORS
        public TPeriod()
        {
            ClassEBD = new List<TClassEBD>();
        }

        public TPeriod(DataRow row)
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
