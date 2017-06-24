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
    /// Properties:         IdRestriction
    ///                     NameRestriction
    ///                     Profiles
    /// Constructors:       TRestriction()
    /// Dependencies:       System.Collections.Generic
    /// =======================================================================
    /// </summary>
    public class TRestriction
    {
        #region PROPERTIES
        [Key]
        public byte IdRestriction { get; set; }
        public string NameRestriction { get; set; }
        public List<TProfile> Profiles { get; set; }
        #endregion PROPERTIES

        #region CONSTRUCTORS
        public TRestriction()
        {
            Profiles = new List<TProfile>();
        }

        public TRestriction(DataRow row)
        {
            SelectRestriction(row);
        }
        #endregion CONSTRUCTORS

        #region METHODS

        private void SelectRestriction(DataRow row)
        {
            IdRestriction = byte.Parse(row["IdRestriction"].ToString());
            NameRestriction = row["NameRestriction"].ToString();
        }

        #endregion
    }
}
