using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINAL_TEST
{
    public class WildAction : CardAction
    {
        public override void PerformAction(UnoGame game, Player currentPlayer)
        {
            //// Prompt the player to choose a color
            //Console.WriteLine("Choose a color (Red, Yellow, Green, Blue):");
            //string chosenColor = Console.ReadLine()?.Trim().ToLower();

            //// Validate the chosen color
            //string[] validColors = { "red", "yellow", "green", "blue" };
            //if (validColors.Contains(chosenColor))
            //{
            //    // Update the top card of the discard pile with the chosen color
            //    var topCard = game.DiscardPile.Last();
            //    topCard.Color = chosenColor;
            //    Console.WriteLine($"The color has been changed to {chosenColor}.");
            //}
            //else
            //{
            //    Console.WriteLine("Invalid color choice. The color remains unchanged.");
            //}
        }
    }
}
