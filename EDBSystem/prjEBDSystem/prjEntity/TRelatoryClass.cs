using System;
using System.Collections.Generic;
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
    /// Properties:         IdRelatoryClass
    ///                     DateRelatoryClass
    ///                     Frequencys
    ///                     VisitorsRelatoryClass
    ///                     TotalBiblesRelatoryClass
    ///                     TotalMagazinesRelatoryClass
    ///                     TotalOffersRelatoryClass
    ///                     CommentsRelatoryClass
    /// Constructors:       TRelatoryClass()
    /// Dependencies:       System
    ///                     System.Collections.Generic
    /// =======================================================================
    /// </summary>
    public class TRelatoryClass
    {
        #region PROPERTIES
        [Key]
        public byte IdRelatoryClass { get; set; }
        public DateTime DateRelatoryClass { get; set; }
        public List<TFrequency> Frequencys { get; set; }
        public int VisitorsRelatoryClass { get; set; }
        public int TotalBiblesRelatoryClass { get; set; }
        public int TotalMagazinesRelatoryClass { get; set; }
        public int TotalOffersRelatoryClass { get; set; }
        public string CommentsRelatoryClass { get; set; }
        #endregion PROPERTIES

        #region CONSTRUCTORS
        public TRelatoryClass()
        {
            Frequencys = new List<TFrequency>();
        }
        #endregion CONSTRUCTORS
    }
}
