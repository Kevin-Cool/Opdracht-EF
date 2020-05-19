using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Model.IRepositories
{
    public interface ITransferRepository
    {
        void VoegTransferToe(Transfer tranfer);
        Transfer SelecteerTransfer(int transferID);
    }
}
