using ClassLibrary.Model.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary.Data.Repositories
{
    public class TransferRepository : ITransferRepository
    {
        private readonly EFoefContext _context;
        private readonly DbSet<Transfer> _transfer;

        public TransferRepository(EFoefContext dbContext)
        {
            _context = dbContext;
            _transfer = dbContext.Transfers;
        }

        public Transfer SelecteerTransfer(int transferID)
        {
            return _transfer.Include(tr => tr._speler).ThenInclude(s => s._Team)
                            .Include(tr => tr.OudeClub).ThenInclude(te => te._spelers)
                            .Include(tr => tr.NieuweClub).ThenInclude(te => te._spelers).FirstOrDefault(tr => tr.TransferID.Equals(transferID));
        }

        public void VoegTransferToe(Transfer tranfer)
        {
            _transfer.Add(tranfer);
            //_context.SaveChanges();
        }
    }
}
