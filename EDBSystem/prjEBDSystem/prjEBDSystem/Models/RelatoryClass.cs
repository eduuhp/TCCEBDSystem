using System;
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
    public class RelatoryClass
    {
        #region PROPERTIES
        [Key]
        [Display(Name = "Id")]
        public byte IdRelatoryClass { get; set; }
        [Display(Name = "Data")]
        public DateTime DateRelatoryClass { get; set; }
        [Display(Name = "Total de visitantes")]
        public int VisitorsRelatoryClass { get; set; }
        [Display(Name = "Total de Bíblias")]
        public int TotalBiblesRelatoryClass { get; set; }
        [Display(Name = "Total de revistas")]
        public int TotalMagazinesRelatoryClass { get; set; }
        [Display(Name = "Total de ofertas")]
        public int TotalOffersRelatoryClass { get; set; }
        [Display(Name = "Comentários")]
        public string CommentsRelatoryClass { get; set; }
        #endregion PROPERTIES

        #region CONSTRUCTORS
        public RelatoryClass(DataRow row)
        {
            SelectRelatoryClass(row);
        }
        #endregion CONSTRUCTORS

        #region METHODS

        private void SelectRelatoryClass(DataRow row)
        {
            IdRelatoryClass = byte.Parse(row["IdRelatoryClass"].ToString());
            DateRelatoryClass = DateTime.Parse(row["DateRelatoryClass"].ToString());
            VisitorsRelatoryClass = byte.Parse(row["VisitorsRelatoryClass"].ToString());
            TotalBiblesRelatoryClass = byte.Parse(row["TotalBiblesRelatoryClass"].ToString());
            TotalMagazinesRelatoryClass = byte.Parse(row["TotalMagazinesRelatoryClass"].ToString());
            TotalOffersRelatoryClass = byte.Parse(row["TotalOffersRelatoryClass"].ToString());
            CommentsRelatoryClass = row["CommentsRelatoryClass"].ToString();
        }

        #endregion CONSTRUCTORS
    }
}