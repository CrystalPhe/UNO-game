using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FINAL_TEST
{
    public class ShowHandCommand : Command
    {
        public override string Execute(Player player, string[] text)
        {
            // Display the player's hand
            if (player.Hand.Cards.Count == 0)
            {
                return $"{player.Name} has no cards in hand.";
            }

            var handDisplay = new StringBuilder();
            handDisplay.AppendLine($"{player.Name}'s hand:");

            foreach (var card in player.Hand.Cards)
            {
                handDisplay.AppendLine(card.ToString()); // Assuming Card class has a ToString() method
            }

            return handDisplay.ToString();
        }
    }

}
