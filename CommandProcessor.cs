using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINAL_TEST
{
    public class CommandProcessor
    {
        private List<Command> _commands = new List<Command>();

        public void AddCommand(Command command)
        {
            _commands.Add(command);
        }

        public string Execute(Player player, string[] text)
        {
            if (text.Length == 1 && text[0].ToLower() == "uno")
            {
                var command = _commands.Find(cmd => cmd is UnoCommand);
                return command?.Execute(player, text) ?? "Command not found.";
            }
            else if (text.Length == 2 && text[0].ToLower() == "draw" && text[1].ToLower() == "card")
            {
                var command = _commands.Find(cmd => cmd is DrawCardCommand);
                return command?.Execute(player, text) ?? "Command not found.";
            }
            else if (text.Length == 3 && text[0].ToLower() == "play")
            {
                var color = text[1];
                var type = text[2];
                var card = player.Hand.Cards.FirstOrDefault(c => c.Color.Equals(color, StringComparison.OrdinalIgnoreCase) && c.Type.Equals(type, StringComparison.OrdinalIgnoreCase));
                if (card == null)
                {
                    return "You do not have that card.";
                }
                var command = _commands.Find(cmd => cmd is PlayCardCommand);
                return command?.Execute(player, new string[] { "play", color, type }) ?? "Command not found.";
            }
            else if (text.Length == 2 && text[0].ToLower() == "show" && text[1].ToLower() == "hand")
            {
                var command = _commands.Find(cmd => cmd is ShowHandCommand);
                return command?.Execute(player, text) ?? "Command not found.";
            }

            return "Invalid move.";
        }

    }
}
