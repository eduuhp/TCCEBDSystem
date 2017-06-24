using System.Collections.Generic;
using System.Data;
using System.ComponentModel.DataAnnotations;


namespace prjEntity
{
    /// <summary>
    /// =======================================================================
    /// Author:             Henryque, Eduardo
    /// Co-Author:          Passos, Lucas
    /// Create date:        02/06/2017
    /// Modification date:  04/06/2017
    /// Description:        Interface Data Acess Object
    /// Properties:         IdNotice
    ///                     TitleNotice
    ///                     ContentNotice
    ///                     Departments
    /// Constructors:       TNotice()
    ///                     TNotice(DataRow row)
    /// Methods:            SelectNotice(DataRow row)
    /// Dependencies:       System.Collections.Generic,
    ///                     System.Data
    /// =======================================================================
    /// </summary>
    public class TNotice
    {
        #region PROPERTIES
        [Key]
        public byte IdNotice { get; set; }
        public string TitleNotice { get; set; }
        public string ContentNotice { get; set; }
        public List<TDepartment> Departments { get; set; }

        #endregion PROPERTIES

        #region CONSTRUCTORS
        public TNotice()
        {
            Departments = new List<TDepartment>();
        }

        public TNotice(DataRow row)
        {
            Departments = new List<TDepartment>();
            SelectNotice(row);
        }
        #endregion CONSTRUCTORS

        #region METHODS

        private void SelectNotice(DataRow row)
        {
            IdNotice = byte.Parse(row["IdNotice"].ToString());
            TitleNotice = row["TitleNotice"].ToString();
            ContentNotice = row["ContentNotice"].ToString();
        }

        #endregion
    }
}
