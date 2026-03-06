using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINAL_TEST
{
    public class DrawTwoAction : CardAction
    {
        public override void PerformAction(UnoGame game, Player currentPlayer)
        {
            Console.WriteLine("Next player draws two cards.");
            Player nextPlayer = game.GetNextPlayer(currentPlayer);
            nextPlayer.Hand.AddCard(game.DrawPile.Draw());
            nextPlayer.Hand.AddCard(game.DrawPile.Draw());
        }
    }
}
