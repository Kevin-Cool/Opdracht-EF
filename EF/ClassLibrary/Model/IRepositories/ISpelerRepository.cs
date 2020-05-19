using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Model.IRepositories
{
    public interface ISpelerRepository
    {
        void VoegSpelerToe(Speler speler);
        void UpdateSpeler(Speler speler);
        Speler SelecteerSpeler(int spelerID);
    }
}
