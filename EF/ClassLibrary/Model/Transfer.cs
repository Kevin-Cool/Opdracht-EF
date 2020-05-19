using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClassLibrary
{
    public class Transfer
    {
        #region Properties
        [Key]
        public int TransferID { get; set; }
        [Required]
        public Speler _speler { get; set; }
        [Required]
        public int _spelerID { get; set; }
        [Required]
        public double Transferprijs { get; set; }
        [Required]
        public Team OudeClub { get; set; }
        [Required]
        public int TeamIDOud { get; set; }
        [Required]
        public Team NieuweClub { get; set; }
        [Required]
        public int TeamIDONieuw { get; set; }
        #endregion

        #region Constructors
        public Transfer(Speler Mspeler,double Mtransferprijs,Team MoudeClub,Team MnieuweClub)
        {
            _speler = Mspeler;
            Transferprijs = Mtransferprijs;
            OudeClub = MoudeClub;
            NieuweClub = MnieuweClub;
        }
        public Transfer()
        {

        }
        #endregion
    }
}
