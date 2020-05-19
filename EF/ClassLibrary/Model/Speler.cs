using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ClassLibrary
{
    public class Speler
    {
        #region Properties
        [Key]
        public int SpelerID { get; set; }
        [MaxLength(64)]
        [Required]
        public string Naam { get; set; }
        [Required]
        public int Rugnummer { get; set; }
        public double Waarde { get; set; }
        [Required]
        public Team _Team { get; set; }
        [Required]
        public int _TeamID { get; set; }

        #endregion

        #region Constructors
        public Speler(string Mnaam,int Mrugnummer,double Mwaarde,Team Mteam)
        {
            Naam = Mnaam;
            Rugnummer = Mrugnummer;
            Waarde = Mwaarde;
            _Team = Mteam;
        }
        public Speler()
        {
            //naam, nummer, teamrDict[team], waarde
        }
        #endregion

        #region Methods
        public Speler Update(Speler speler)
        {
            Naam = speler.Naam;
            Rugnummer = speler.Rugnummer;
            Waarde = speler.Waarde;
            _Team = speler._Team;
            _TeamID = speler._TeamID;

            return this;
        }

        #endregion



    }
}
