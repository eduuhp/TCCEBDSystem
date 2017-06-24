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
    public class User
    {
        #region PROPERTIES

        [Key]
        [Display(Name = "Id")]
        public byte IdUser { get; set; }
        [Display(Name = "Nome")]
        public string FirstNameUser { get; set; }
        [Display(Name = "Sobrenome")]
        public string LastNameUser { get; set; }
        [Display(Name = "Data de nascimento")]
        public DateTime DateBirthUser { get; set; }
        [Display(Name = "Login")]
        public string LoginUser { get; set; }
        [Display(Name = "Senha")]
        public string PasswordUser { get; set; }
        public string Checked { get; set; }
        [Display(Name = "Perfil")]
        public Profile Profile { get; set; }
        [Display(Name = "Classe")]
        public ClassEBD ClassEBD { get; set; }
        [Display(Name = "Frequências")]
        public List<Frequency> Frequency { get; set; }
        #endregion PROPERTIES

        #region CONSTRUCTORS
        public User()
        {
            Profile = new Profile();
            ClassEBD = new ClassEBD();
            Frequency = new List<Frequency>();
        }

        public User(DataRow row)
        {
            Profile = new Profile();
            ClassEBD = new ClassEBD();

            SelectUser(row);
        }
        #endregion CONSTRUCTORS        

        private void SelectUser(DataRow row)
        {
            IdUser = byte.Parse(row["IdUser"].ToString());
            if (row.Table.Columns.Count == 5 || row.Table.Columns.Count == 9 || row.Table.Columns.Count == 3)
            {
                FirstNameUser = row["FirstNameUser"].ToString();
                LastNameUser = row["LastNameUser"].ToString();
                if (row.Table.Columns.Count == 5 || row.Table.Columns.Count == 9)
                {
                    Profile.IdProfile = byte.Parse(row["IdProfile"].ToString());
                    ClassEBD.IdClassEBD = byte.Parse(row["IdClassEBD"].ToString());
                    if (row.Table.Columns.Count == 9)
                    {
                        DateBirthUser = DateTime.Parse(row["DateBirthUser"].ToString());
                        LoginUser = row["LoginUser"].ToString();
                        Profile.NameProfile = row["NameProfile"].ToString();
                        ClassEBD.NameClassEBD = row["NameClassEBD"].ToString();
                    }
                }
                
               
                
            }
        }
    }
}