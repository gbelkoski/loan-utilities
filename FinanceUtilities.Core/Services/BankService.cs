using FinanceUtilities.Data;
using System.Collections.Generic;
using System.Linq;
using System;
using FinanceUtilities.Domain;

namespace FinanceUtilities.Core
{
    public class BankService : ServiceBase, IBankService
    {
        public BankService(IFinanceContext context) : base(context)
        {
        }

        public List<Bank> GetAll()
        {
            return _context.Banks.ToList();
        }


        public Bank Get(int id)
        {
            return _context.Banks.FirstOrDefault(b => b.Id == id);
        }

        public bool Save(Bank bank)
        {
            try
            {
                _context.Banks.Add(bank);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int bankId)
        {
            throw new NotImplementedException();
        }
    }
}
