using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace prjEBDSystem.Models
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
    public class Department
    {
        #region PROPERTIES
        [Key]
        [Display(Name = "Id")]
        public int IdDepartment { get; set; }
        [Display(Name = "Nome")]
        public string NameDepartment { get; set; }
        [Display(Name = "Descrição")]
        public string DescriptionDepartment { get; set; }
        public string Checked { get; set; }
        [Display(Name = "Notícias")]
        public List<Notice> Notices { get; set; }
        [Display(Name = "Classes")]
        public List<ClassEBD> ClassEBD { get; set; }

        #endregion PROPERTIES

        #region CONSTRUCTORS
        public Department()
        {
            Notices = new List<Notice>();
            ClassEBD = new List<ClassEBD>();
        }
        public Department(DataRow row)
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