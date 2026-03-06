using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINAL_TEST
{
    public class ReverseAction : CardAction
    {
        public override void PerformAction(UnoGame game, Player currentPlayer)
        {
            Console.WriteLine("Reversing the order of play.");
            game.ReverseOrder();
        }
    }
}
