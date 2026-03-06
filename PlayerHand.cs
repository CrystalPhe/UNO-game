using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINAL_TEST
{
    public class PlayerHand
    {
        private List<Card> cards;

        public PlayerHand()
        {
            cards = new List<Card>();
        }

        public void AddCard(Card card)
        {
            cards.Add(card);
        }

        public void RemoveCard(Card card)
        {
            cards.Remove(card);
        }

        public void DisplayCards()
        {
            foreach (var card in cards)
            {
                Console.WriteLine(card.ToString());
            }
        }

        public void Clear()
        {
            cards.Clear();
        }

        public List<Card> Cards
        {
            get { return cards; }
        }
    }
}
