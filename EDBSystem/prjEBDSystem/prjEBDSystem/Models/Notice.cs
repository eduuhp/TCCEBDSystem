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
    public class Notice
    {
        #region PROPERTIES
        [Key]
        [Display(Name = "Id")]
        public byte IdNotice { get; set; }
        [Display(Name = "Título")]
        public string TitleNotice { get; set; }
        [Display(Name = "Conteúdo")]
        public string ContentNotice { get; set; }
        [Display(Name = "Departamentos")]
        public List<Department> Departments { get; set; }

        #endregion PROPERTIES

        #region CONSTRUCTORS
        public Notice()
        {
            Departments = new List<Department>();
        }

        public Notice(DataRow row)
        {
            Departments = new List<Department>();
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