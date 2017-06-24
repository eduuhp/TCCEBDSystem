using System;
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
    /// Properties:         IdFrequency
    ///                     DataFrequency
    ///                     Frequent
    ///                     User
    /// Constructors:       TFrequency()
    /// Dependencies:       System
    /// =======================================================================
    /// </summary>
    public class TFrequency
    {

        #region PROPERTIES
        [Key]
        public byte IdFrequency { get; set; }
        public DateTime DateFrequency { get; set; }
        public bool Frequent { get; set; }
        public TUser User { get; set; }
        #endregion PROPERTIES

        #region CONSTRUCTORS
        public TFrequency()
        {
            User = new TUser();
        }
        #endregion CONSTRUCTORS
    }
}
