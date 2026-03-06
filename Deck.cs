using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINAL_TEST
{
    public class Deck
    {
        private List<Card> cards;

        public Deck()
        {
            cards = new List<Card>();
            string[] colors = { "Red", "Yellow", "Green", "Blue" };
            string[] numberTypes = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string[] actionTypes = { "Skip", "DrawTwo", "Reverse" };

            foreach (var color in colors)
            {
                cards.Add(new Card(color, "0"));

                foreach (var numberType in numberTypes.Skip(1))
                {
                    cards.Add(new Card(color, numberType));
                    cards.Add(new Card(color, numberType));
                }

                cards.Add(new Card(color, "Skip", new SkipAction()));
                cards.Add(new Card(color, "Skip", new SkipAction()));
                cards.Add(new Card(color, "DrawTwo", new DrawTwoAction()));
                cards.Add(new Card(color, "DrawTwo", new DrawTwoAction()));
                cards.Add(new Card(color, "Reverse", new ReverseAction()));
                cards.Add(new Card(color, "Reverse", new ReverseAction()));
            }

            for (int i = 0; i < 4; i++)
            {
                cards.Add(new Card("Wild", "Color", new WildAction()));
                cards.Add(new Card("Wild", "DrawFour", new DrawFourAction()));
            }
        }

        public void Shuffle()
        {
            Random rng = new Random();
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = cards[k];
                cards[k] = cards[n];
                cards[n] = value;
            }
            Console.WriteLine("Deck shuffled.");
        }

        public void AddCardToTop(Card card)
        {
            cards.Insert(0, card);
            Console.WriteLine($"Card {card} added back to the deck.");
        }

        public Card Draw()
        {
            if (cards.Count == 0)
                throw new InvalidOperationException("No cards left in the deck.");

            Card drawnCard = cards[0];
            cards.RemoveAt(0);
            Console.WriteLine($"Drew card: {drawnCard}");
            return drawnCard;
        }
    }
}
