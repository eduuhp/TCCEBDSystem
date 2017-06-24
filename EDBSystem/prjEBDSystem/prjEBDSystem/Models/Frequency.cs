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
    /// Properties:         IdFrequency
    ///                     DataFrequency
    ///                     Frequent
    ///                     User
    /// Constructors:       TFrequency()
    /// Dependencies:       System
    /// =======================================================================
    /// </summary>
    public class Frequency
    {

        #region PROPERTIES
        [Key]
        [Display(Name = "Id")]
        public byte IdFrequency { get; set; }
        [Display(Name = "Data")]
        public DateTime DateFrequency { get; set; }
        [Display(Name = "Usuários")]
        public List<User> Users { get; set; }
        [Display(Name = "Relatório")]
        public RelatoryClass RelatoryClass { get; set; }
        #endregion PROPERTIES

        #region CONSTRUCTORS
        public Frequency()
        {
            Users = new List<User>();
            //RelatoryClass = new RelatoryClass();
        }
        public Frequency(DataRow row)
        {
            Users = new List<User>();
            SelectFrequency(row);
        }
        #endregion CONSTRUCTORS

        #region METHODS

        private void SelectFrequency(DataRow row)
        {
            IdFrequency = byte.Parse(row["IdFrequency"].ToString());
            DateFrequency = DateTime.Parse(row["DateFrequency"].ToString());
        }

        #endregion CONSTRUCTORS
    }
}