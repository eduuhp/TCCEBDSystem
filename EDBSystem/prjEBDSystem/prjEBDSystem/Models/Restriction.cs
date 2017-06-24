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
    /// Properties:         IdRestriction
    ///                     NameRestriction
    ///                     Profiles
    /// Constructors:       TRestriction()
    /// Dependencies:       System.Collections.Generic
    /// =======================================================================
    /// </summary>
    public class Restriction
    {
        #region PROPERTIES
        [Key]
        [Display(Name = "Id")]
        public byte IdRestriction { get; set; }
        [Display(Name = "Nome")]
        public string NameRestriction { get; set; }
        public string Checked { get; set; }
        [Display(Name = "Perfis")]
        public List<Profile> Profiles { get; set; }
        #endregion PROPERTIES

        #region CONSTRUCTORS
        public Restriction()
        {
            Profiles = new List<Profile>();
        }

        public Restriction(DataRow row)
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