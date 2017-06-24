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
    /// Properties:         IdProfile
    ///                     NameProfile
    ///                     Restrictions
    ///                     Users
    /// Constructors:       TProfile()
    /// Dependencies:       System.Collections.Generic
    /// =======================================================================
    /// </summary>
    public class TProfile
    {
        #region PROPERTIES
        [Key]
        public byte IdProfile { get; set; }
        public string NameProfile { get; set; }
        public List<TRestriction> Restrictions { get; set; }
        public List<TUser> Users { get; set; }
        #endregion PROPERTIES

        #region CONSTRUCTORS
        public TProfile()
        {
            Restrictions = new List<TRestriction>();
            Users = new List<TUser>();
        }

        public TProfile(DataRow row)
        {
            Restrictions = new List<TRestriction>();
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
