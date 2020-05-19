using ClassLibrary.Model.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace ClassLibrary.Data.Repositories
{
    public class SpelerRepository : ISpelerRepository
    {
        private readonly EFoefContext _context;
        private readonly DbSet<Speler> _speler;

        public SpelerRepository()
        {
        }

        public SpelerRepository(EFoefContext dbContext)
        {
            _context = dbContext;
            _speler = dbContext.Spelers;
        }

        
        public Speler SelecteerSpeler(int spelerID)
        {
            return _speler.Include(s => s._Team).FirstOrDefault(s => s.SpelerID.Equals(spelerID));
        }

        public void UpdateSpeler(Speler speler)
        {
            _speler.Include(s => s._Team).FirstOrDefault(s => s.SpelerID.Equals(speler.SpelerID)).Update(speler);
            //_context.SaveChanges();
        }

        public void VoegSpelerToe(Speler speler)
        {
            _speler.Add(speler);
            //_context.SaveChanges();
        }
    }
}
