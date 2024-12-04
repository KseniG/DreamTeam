using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardGroup
{
    public class DialogOption
    {
        public string Text { get; set; }
        public DialogNode NextNode { get; set; }

        public DialogOption(string text, DialogNode nextNode)
        {
            Text = text;
            NextNode = nextNode;
        }
    }
}
