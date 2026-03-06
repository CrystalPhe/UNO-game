using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINAL_TEST
{
public class DrawFourAction : CardAction
    {
        public override void PerformAction(UnoGame game, Player currentPlayer)
        {
            Console.WriteLine("Next player draws four cards and choose a color.");
            Player nextPlayer = game.GetNextPlayer(currentPlayer);

            // Draw four cards for the next player
            for (int i = 0; i < 4; i++)
            {
                nextPlayer.Hand.AddCard(game.DrawPile.Draw());
            }

            //// Ask the player to choose a color
            //Console.WriteLine("Choose a color (Red, Yellow, Green, Blue): ");
            //string chosenColor = Console.ReadLine()?.Trim().ToLower();

            //// Validate the chosen color
            //if (new[] { "red", "yellow", "green", "blue" }.Contains(chosenColor))
            //{
            //    // Apply the chosen color to the current top card
            //    game.DiscardPile.Last().Color = chosenColor;
            //    Console.WriteLine($"The color has been changed to {chosenColor}.");
            //}
            //else
            //{
            //    Console.WriteLine("Invalid color choice. The default color remains.");
            //}
        }
    }
}
