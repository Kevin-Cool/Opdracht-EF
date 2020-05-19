using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ClassLibrary
{
    public class Team
    {
        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Stamnummer { get; set; }
        [MaxLength(64)]
        [Required]
        public string Naam { get; set; }
        public string Bijnaam { get; set; }
        public string Trainer { get; set; }
        public List<Speler> _spelers { get; set; } = new List<Speler>();
        #endregion

        #region Constructors
        public Team(int Mstamnummer, string Mnaam,string Mbijnaam,string Mtrainer,List<Speler> Mspelers) : this(Mstamnummer, Mnaam, Mbijnaam, Mtrainer)
        {
            _spelers = Mspelers;
        }
        public Team(int stamnr,string team,string bijnaam, string Mtrainer )
        {
            Stamnummer = stamnr;
            Naam = team;
            Bijnaam = bijnaam;
            Trainer = Mtrainer;
        }
        public Team()
        {

        }
        
        #endregion

        #region Methods
        public Team Update(Team team)
        {
            Naam = team.Naam;
            Bijnaam = team.Bijnaam;
            Trainer = team.Trainer;
            _spelers = team._spelers;

            return this;
        }

        #endregion

    }
}
