using System.Diagnostics;
using FluentAssertions;
using NUnit.Framework;
using XmppBot.Common;
using XmppBot_AIML;

namespace AIML.Tests
{
    [TestFixture]
    public class AimlBotTests
    {
        AimlPlugin _plugin;

        [SetUp]
        public void Setup()
        {
            _plugin = new AimlPlugin();
            ParsedLine start = new ParsedLine("Hey Bot, what's up?", "Bob");
            _plugin.Evaluate(start);
        }

        [TearDown]
        public void TearDown()
        {
            ParsedLine stop = new ParsedLine("Stop Talking", "Bob");
            _plugin.Evaluate(stop);
        }

        [Test]
        public void knows_user_name()
        {
            var line = new ParsedLine("GOOD NIGHT", "Bob");

            _plugin.Evaluate(line).Should().Be("Goodnight, Bob.");
        }
    }
}