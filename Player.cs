using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINAL_TEST
{
    public class Player
    {
        public string Name { get; set; }
        public PlayerHand Hand { get; set; }
        public int Position { get; set; }

        public Player(string name, int position)
        {
            Name = name;
            Hand = new PlayerHand();
            Position = position;
        }

        public Card DrawCard(Deck deck)
        {
            Card drawnCard = deck.Draw();
            Hand.AddCard(drawnCard);
            return drawnCard;
        }
    }
}
