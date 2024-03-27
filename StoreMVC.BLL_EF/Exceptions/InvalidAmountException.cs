using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreMVC.BLL_EF.Exceptions
{
    public class InvalidAmountException : Exception
    {
        public InvalidAmountException(string mes) : base(mes) { }
      
    }
}
