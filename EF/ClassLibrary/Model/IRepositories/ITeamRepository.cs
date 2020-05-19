using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Model.IRepositories
{
    public interface ITeamRepository
    {
        void VoegTeamToe(Team team);
        void UpdateTeam(Team team);
        Team SelecteerTeam(int stamnummer);
    }
}
