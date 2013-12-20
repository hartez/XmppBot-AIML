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

            // The AIMLBot will learn user names during a conversation 
            // (e.g., you can say "My name is Bob" and thereafter the bot will
            // refer to you as Bob). But since this bot is in a chat room, it should
            // already know a person's name. The AIML settings have the default user
            // name set to "un-named user"; we'll check for that string and replace it
            // with the known chat room name. That way, the bot learning behavior is preserved
            // but the bot seems less dumb when sitting in a chat room

            String result = res.Output.Replace("un-named user", user.UserID);

            return (result);
        }
    }
}