using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINAL_TEST
{
    public class Card
    {
        public string Color { get; set; }
        public string Type { get; set; }
        public CardAction Action { get; set; }

        public Card(string color, string type, CardAction action = null)
        {
            Color = color;
            Type = type;
            Action = action;
        }

        public override string ToString()
        {
            return $"{Color} {Type}";
        }
    }
}
