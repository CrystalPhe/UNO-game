using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINAL_TEST
{
    public class SkipAction : CardAction
    {
        public override void PerformAction(UnoGame game, Player currentPlayer)
        {
            Console.WriteLine("Skipping the next player.");
            game.SkipNextPlayer();

        }
    }
}
