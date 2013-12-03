using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        }

        [Test]
        public void no_response_if_not_conversing()
        {
            ParsedLine line = new ParsedLine("What's up, bot?", "Bob");

            _plugin.Evaluate(line).Should().BeNull();
        }

        [Test]
        public void start_talking_on_partial_trigger()
        {
            ParsedLine line = new ParsedLine("Hey Bot, what's up?", "Bob");

            _plugin.Evaluate(line).Should().NotBeNull();
        }

        [Test]
        public void stop_talking_on_partial_trigger()
        {
            // Start the conversation
            var line = new ParsedLine("Hey Bot, what's up?", "Bob");
            _plugin.Evaluate(line).Should().NotBeNull();

            // End the conversation
            line = new ParsedLine("Quiet, Bot, we're done talking.", "Bob");
            _plugin.Evaluate(line).Should().NotBeNull();

            // No more responses
            line = new ParsedLine("Just saying some random stuff", "Bob");
            _plugin.Evaluate(line).Should().BeNull();
        }
    }
}
