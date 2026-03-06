using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINAL_TEST
{
    public class UnoCommand : Command
    {
        public override string Execute(Player player, string[] text)
        {
            if (player.Hand.Cards.Count == 1)
            {
                return $"Player {player.Name} called UNO!";
            }
            else
            {
                return "You can only call UNO when you have one card left.";
            }
        }
    }
}
