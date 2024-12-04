using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HardGroup;

namespace HardGroup
{
    public class DialogNode
    {
        public string Prompt { get; set; }
        public TimeSpan ResponseTimeLimit { get; set; } // Ограничение по времени на ответ
        public List<DialogOption> Options { get; set; }
        public List<Event> Events { get; set; } // Список событий, которые вызываются при выборе этой вершины
        public string AudioLocalization { get; set; } // Озвучка на разных языках

        public DialogNode(string prompt, int time, string audioLocalization)//TimeSpan responseTimeLimit
        {
            Prompt = prompt;
            //ResponseTimeLimit = responseTimeLimit;
            Options = new List<DialogOption>();
            Events = new List<Event>();
            AudioLocalization = audioLocalization;
        }

        public void AddOption(DialogOption option)
        {
            Options.Add(option);
        }

        public void AddEvent(Event eventAction)
        {
            Events.Add(eventAction);
        }
    }
}
