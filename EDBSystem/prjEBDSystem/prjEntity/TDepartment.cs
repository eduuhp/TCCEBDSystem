using System.Collections.Generic;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace prjEntity
{
    /// <summary>
    /// =======================================================================
    /// Author:             Henryque, Eduardo
    /// Co-Author:          Passos, Lucas
    /// Create date:        01/06/2017
    /// Modification date:  04/06/2017
    /// Description:        Database Transference Object
    /// Properties:         IdDepartment
    ///                     NameDepartment
    ///                     DescriptionDepartment
    ///                     Notices
    ///                     ClassEBD
    /// Constructors:       TDepartment()
    ///                     TDepartment(DataRow row)
    /// Methods:            SelectDepartment(DataRow row)
    /// Dependencies:       using System.Collections.Generic;
    ///                     using System.Data;
    /// =======================================================================
    /// </summary>
    public class TDepartment
    {
        #region PROPERTIES
        public int IdDepartment { get; set; }
        public string NameDepartment { get; set; }
        public string DescriptionDepartment { get; set; }
        public List<TNotice> Notices { get; set; }
        public List<TClassEBD> ClassEBD { get; set; }

        #endregion PROPERTIES

        #region CONSTRUCTORS
        public TDepartment()
        {
            Notices = new List<TNotice>();
            ClassEBD = new List<TClassEBD>();
        }
        public TDepartment(DataRow row)
        {
            SelectDepartment(row);
        }
        #endregion CONSTRUCTORS

        #region METHODS

        private void SelectDepartment(DataRow row)
        {
            IdDepartment = byte.Parse(row["IdDepartment"].ToString());
            NameDepartment = row["NameDepartment"].ToString();
            if (row.Table.Columns.Count == 3)
            {
                DescriptionDepartment = row["DescriptionDepartment"].ToString();
            }
        }

        #endregion
    }
}
