using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINAL_TEST
{
    public abstract class CardAction
    {
        public abstract void PerformAction(UnoGame game, Player currentPlayer);
    }
}
