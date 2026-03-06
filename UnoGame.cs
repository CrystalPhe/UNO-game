using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FINAL_TEST
{
    public class UnoGame
    {
        public List<Player> Players { get; set; }
        public Deck DrawPile { get; set; }
        public List<Card> DiscardPile { get; set; }
        public int currentPlayerIndex { get; private set; }
        private bool isReversed;
        private CommandProcessor commandProcessor;

        public UnoGame(List<string> playerNames)
        {
            Players = new List<Player>();
            int position = 1;
            foreach (var name in playerNames)
            {
                Players.Add(new Player(name, position++));
            }
            DrawPile = new Deck();
            DiscardPile = new List<Card>();
            currentPlayerIndex = 0;
            isReversed = false;

            // Initialize CommandProcessor and add commands
            commandProcessor = new CommandProcessor();
            commandProcessor.AddCommand(new PlayCardCommand(this));
            commandProcessor.AddCommand(new DrawCardCommand(DrawPile));
            commandProcessor.AddCommand(new ShowHandCommand());
            commandProcessor.AddCommand(new UnoCommand());  
        }

        public void StartGame()
        {
            DrawPile.Shuffle();
            foreach (var player in Players)
            {
                player.Hand.Clear();
            }
            DiscardPile.Clear();

            Console.WriteLine("Starting a new game of UNO.");

            // Each player draws 7 cards
            foreach (var player in Players)
            {
                for (int i = 0; i < 7; i++)
                {
                    player.Hand.AddCard(DrawPile.Draw());
                }
                Console.WriteLine($"\n{player.Name}'s hand: ");
                player.Hand.DisplayCards();
            }

            // Draw the first card for the discard pile and handle action cards
            Card firstCard;
            do
            {
                firstCard = DrawPile.Draw();
                if (firstCard.Action != null)
                {
                    Console.WriteLine($"First card drawn was {firstCard} which has an action. Putting it back and drawing another card.");
                    DrawPile.AddCardToTop(firstCard); // Assuming you have this method to put the card back on top of the deck
                    DrawPile.Shuffle(); // Shuffle the deck after putting the card back
                }
            } while (firstCard.Action != null);

            DiscardPile.Add(firstCard);
            Console.WriteLine($"First card on the discard pile: {firstCard}");

            // Perform any action associated with the first card (if any)
            if (firstCard.Action != null)
            {
                firstCard.Action.PerformAction(this, Players[currentPlayerIndex]);
            }
        }

        public void PlayCard(Player player, Card card)
        {
            if (!IsCardPlayable(card))
            {
                Console.WriteLine($"Cannot play {card}. It does not match the color or type of the top card on the discard pile.");
                return;
            }
            DiscardPile.Add(card);
            player.Hand.RemoveCard(card);
            Console.WriteLine($"{player.Name} played {card}");

            if (card.Action != null)
            {
                card.Action.PerformAction(this, Players[currentPlayerIndex]);
            }
        }

        public bool IsCardPlayable(Card card)
        {
            var topCard = DiscardPile.Last();
            return card.Color == topCard.Color || card.Type == topCard.Type || card.Color == "Wild";
        }

        public Player GetNextPlayer(Player currentPlayer)
        {
            if (isReversed)
            {
                // Move to the previous player in reversed order
                int nextPlayerIndex = (currentPlayer.Position - 2 + Players.Count) % Players.Count;
                return Players[nextPlayerIndex];
            }
            else
            {
                // Move to the next player in normal order
                int nextPlayerIndex = (currentPlayer.Position % Players.Count);
                return Players[nextPlayerIndex];
            }
        }

        public void ReverseOrder()
        {
            isReversed = !isReversed;
        }

        public void SkipNextPlayer()
        {
            currentPlayerIndex = (currentPlayerIndex + 2) % Players.Count;
        }

        public void ProcessCommand(string input)
        {
            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Player currentPlayer = Players[currentPlayerIndex];
            string result = commandProcessor.Execute(currentPlayer, parts);
            Console.WriteLine(result);

            // Check if the command result indicates a successful action
            if (result.Contains("played") || result.Contains("drew") || result.Contains("skipped"))
            {
                // Update the current player index based on the reversed order
                currentPlayerIndex = Players.IndexOf(GetNextPlayer(currentPlayer));
            }
            // If the result does not contain "played" or "drew", it means no action was performed
            // and the current player remains the same
        }

    }
}
