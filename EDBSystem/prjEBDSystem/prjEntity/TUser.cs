using System;
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
    /// Properties:         IdUser
    ///                     FirstNameUser
    ///                     LastNameUser
    ///                     DateBirthUser
    ///                     LoginUser
    ///                     PasswordUser
    ///                     Profile
    ///                     Frequency
    /// Constructors:       TUser()
    /// Dependencies:       System
    ///                     System.Collections.Generic
    /// =======================================================================
    /// </summary>
    public class TUser
    {
        #region PROPERTIES

        [Key]
        public byte IdUser { get; set; }
        public string FirstNameUser { get; set; }
        public string LastNameUser { get; set; }
        public DateTime DateBirthUser { get; set; }
        public string LoginUser { get; set; }
        public string PasswordUser { get; set; }
        public TProfile Profile { get; set; }
        public TClassEBD ClassEBD { get; set; }
        public List<TFrequency> Frequency { get; set; }
        #endregion PROPERTIES

        #region CONSTRUCTORS
        public TUser()
        {
            Profile = new TProfile();
            ClassEBD = new TClassEBD();
            Frequency = new List<TFrequency>();
        }

        public TUser(DataRow row)
        {
            Profile = new TProfile();
            ClassEBD = new TClassEBD();

            SelectUser(row);
        }
        #endregion CONSTRUCTORS        

        private void SelectUser(DataRow row)
        {
            IdUser = byte.Parse(row["IdUser"].ToString());
            FirstNameUser = row["FirstNameUser"].ToString();
            LastNameUser =row["LastNameUser"].ToString();
            DateBirthUser = DateTime.Parse(row["DateBirthUser"].ToString());
            LoginUser = row["LoginUser"].ToString();
            Profile.IdProfile = byte.Parse(row["IdProfile"].ToString());
            Profile.NameProfile = row["NameProfile"].ToString();
            ClassEBD.IdClassEBD = byte.Parse(row["IdClassEBD"].ToString());
            ClassEBD.NameClassEBD = row["NameClassEBD"].ToString();
        }
    }
}
