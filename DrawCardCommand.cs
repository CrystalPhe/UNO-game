using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINAL_TEST
{
    public class DrawCardCommand : Command
    {
        private Deck deck;

        public DrawCardCommand(Deck deck)
        {
            this.deck = deck;
        }

        public override string Execute(Player player, string[] text)
        {
            // Draw one card from the deck and add it to the player's hand
            Card drawnCard = player.DrawCard(deck);
            // Move to the next player
            return $"Player {player.Name} drew a card: {drawnCard}.";
        }
    }
}
