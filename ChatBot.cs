using System;
using AIMLbot;

namespace XmppBot_AIML
{
    public class ChatBot : Bot
    {
        public ChatBot(string settingsPath)
        {
            loadSettings(settingsPath);
            isAcceptingUserInput = false;
            loadAIMLFromFiles();
            isAcceptingUserInput = true;
        }

        public String Respond(String input, User user)
        {
            var r = new Request(input, user, this);
            var res = Chat(r);

            return (res.Output);
        }
    }
}