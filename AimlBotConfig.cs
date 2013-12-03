using System;
using System.Collections.Generic;

namespace XmppBot_AIML
{
    public class AimlBotConfig
    {
        public String SettingsPath { get; set; }
        public List<Trigger> StartTriggers { get; set; }
        public List<Trigger> StopTriggers { get; set; }
    }
}