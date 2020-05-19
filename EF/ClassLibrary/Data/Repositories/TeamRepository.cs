using ClassLibrary.Model.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary.Data.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly EFoefContext _context;
        private readonly DbSet<Team> _team;

        public TeamRepository(EFoefContext dbContext)
        {
            _context = dbContext;
            _team = dbContext.Teams;
        }

        public Team SelecteerTeam(int stamnummer)
        {
            return _team.Include(s => s._spelers).FirstOrDefault(te => te.Stamnummer.Equals(stamnummer));
        }

        public void UpdateTeam(Team team)
        {
            _team.Include(s => s._spelers).FirstOrDefault(te => te.Stamnummer.Equals(team.Stamnummer)).Update(team);
            //_context.SaveChanges();
        }

        public void VoegTeamToe(Team team)
        {
            _team.Add(team);
            //_context.SaveChanges();
        }
    }
}
