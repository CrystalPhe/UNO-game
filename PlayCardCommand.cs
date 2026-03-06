using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINAL_TEST
{
    public class PlayCardCommand : Command
    {
        private UnoGame game;

        public PlayCardCommand(UnoGame game)
        {
            this.game = game;
        }

        public override string Execute(Player player, string[] text)
        {
            // Example text: "play red 1", "play wild color", "play wild drawfour"
            if (text.Length < 3) return "Invalid command format for play card.";

            string color = text[1].ToLower();
            string type = text[2].ToLower();

            // Find the card in the player's hand
            Card cardToPlay = player.Hand.Cards.FirstOrDefault(c =>
                c.Color.ToLower() == color && c.Type.ToLower() == type);

            // Check if the card is playable
            if (cardToPlay != null)
            {
                if (game.IsCardPlayable(cardToPlay))
                {
                    player.Hand.RemoveCard(cardToPlay);
                    game.DiscardPile.Add(cardToPlay);
                    if (cardToPlay.Action != null)
                    {
                        cardToPlay.Action.PerformAction(game, player);
                    }
                    return $"Player {player.Name} played {cardToPlay}.";
                }
                else
                {
                    return $"Cannot play {cardToPlay}. It does not match the color or type of the top card on the discard pile.";
                }
            }
            else
            {
                return "You do not have that card.";
            }
        }
    }

}
