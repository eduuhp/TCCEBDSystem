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
    /// Properties:         IdProfile
    ///                     NameProfile
    ///                     Restrictions
    ///                     Users
    /// Constructors:       TProfile()
    /// Dependencies:       System.Collections.Generic
    /// =======================================================================
    /// </summary>
    public class Profile
    {
        #region PROPERTIES
        [Key]
        [Display(Name = "Id")]
        public byte IdProfile { get; set; }
        [Display(Name = "Nome")]
        public string NameProfile { get; set; }
        [Display(Name = "Restrições")]
        public List<Restriction> Restrictions { get; set; }
        [Display(Name = "Usuários")]
        public List<User> Users { get; set; }
        #endregion PROPERTIES

        #region CONSTRUCTORS
        public Profile()
        {
            Restrictions = new List<Restriction>();
            Users = new List<User>();
        }

        public Profile(DataRow row)
        {
            Restrictions = new List<Restriction>();
            SelectProfile(row);
        }
        #endregion CONSTRUCTORS

        #region METHODS

        private void SelectProfile(DataRow row)
        {
            IdProfile = byte.Parse(row["IdProfile"].ToString());
            NameProfile = row["NameProfile"].ToString();
        }

        #endregion
    }
}