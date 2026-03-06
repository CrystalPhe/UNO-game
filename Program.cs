namespace FINAL_TEST
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> playerNames = new List<string> { "P1", "P2", "P3"};
            UnoGame game = new UnoGame(playerNames);
            game.StartGame();

            bool gameIsRunning = true;
            while (gameIsRunning)
            {
                Player currentPlayer = game.Players[game.currentPlayerIndex];
                Console.WriteLine($"\nIt's {currentPlayer.Name}'s turn.");
                Console.WriteLine("Enter move: ");
                string input = Console.ReadLine();

                if (string.Equals(input, "quit", StringComparison.OrdinalIgnoreCase))
                {
                    gameIsRunning = false;
                    Console.WriteLine("Game ended by player.");
                }
                else
                {
                    game.ProcessCommand(input);
                }

                //  logic to check for end of game conditions
                foreach (var player in game.Players)
                {
                    if (player.Hand.Cards.Count == 0)
                    {
                        Console.WriteLine($"{player.Name} wins!");
                        gameIsRunning = false;
                        break;
                    }
                }
            }
        }
    }
}
