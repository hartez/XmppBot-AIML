using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using AIMLbot;
using SimpleConfig;
using XmppBot.Common;

namespace XmppBot_AIML
{
    [Export(typeof(IXmppBotPlugin))]
    public class AimlPlugin : IXmppBotPlugin
    {
        private AimlBotConfig _config;
        private ChatBot _bot;
        private Dictionary<string, User> _users;
        private bool _conversing;

        public AimlPlugin()
        {
            Initialize(Configuration.Load<AimlBotConfig>());
        }

        public AimlPlugin(string configPath)
        {
            Initialize(Configuration.Load<AimlBotConfig>(configPath: configPath));
        }

        private void Initialize(AimlBotConfig config)
        {
            _config = config;
            _users = new Dictionary<string, User>();
            _bot = new ChatBot(config.SettingsPath);
        }

        public string Evaluate(ParsedLine line)
        {
            if(line.IsCommand)
            {
                return null;
            }

            if(!_users.ContainsKey(line.User))
            {
                _users[line.User] = new User(line.User, _bot);
            }

            if(_conversing)
            {
                // Check for stop triggers
                if(_config.StopTriggers.Any(trigger => trigger.Matches(line.Raw)))
                {
                    _conversing = false;
                    return "Good talk, " + line.User;
                }
            }
            else if(Enumerable.Any(_config.StartTriggers, trigger => trigger.Matches(line.Raw)))
            {
                _conversing = true;
                return _bot.Respond(line.Raw, _users[line.User]) + " [By the way, if my chattering starts to get annoying, you can type 'Stop Talking' and I might.]";
            }

            if(_conversing)
            {
                return _bot.Respond(line.Raw, _users[line.User]);
            }

            return null;
        }

        public string Name
        {
            get { return "AIML Bot"; }
        }
    }
}