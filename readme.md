# AIML Plugin for XmppBot

This is a simple plugin for [XmppBot For HipChat](https://github.com/patHyatt/XmppBot-for-HipChat) which connects the [AIMLBot project] to XmppBot. AIML stands for [Artificial Intelligence Markup Language](http://en.wikipedia.org/wiki/AIML).

## Installation

Copy the .dlls (Bender.dll, SimpleConfig.dll, XmppBot.Common.dll, and XmppBot-AIML.dll) into the /plugins folder. You'll also need to include the AIML folder and its subfolders (aiml and config) somewhere accessible (making AIML a subfolder of /plugins works pretty well).
 
## Configuration

Add the following to the `<configSections>` element of XmppBot's configuration file:

    <section name="aimlBotConfig" type="SimpleConfig.Section, SimpleConfig, Version=1.0.29.0, Culture=neutral, PublicKeyToken=null"/>

Then add the following to the `configuration ` element:

	<aimlBotConfig settingsPath="plugins/AIML/config/Settings.xml">
    <startTriggers>
      <trigger Partial="true" CaseSensitive="false" Text="Hey, Bot"></trigger>
      <trigger Partial="true" CaseSensitive="false" Text="Hey Bot"></trigger>
      <trigger Partial="true" CaseSensitive="false" Text="Bot!"></trigger>
    </startTriggers>
    <stopTriggers>
      <trigger Partial="true" CaseSensitive="false" Text="That's enough, bot"></trigger>
      <trigger Partial="true" CaseSensitive="false" Text="Stop Talking"></trigger>
    </stopTriggers>
  </aimlBotConfig>

Where `settingsPath` is the path to the `.xml` file containing containing the AIMLBot settings. The `startTriggers` and `stopTriggers` elements control the phrases which will cause the chatbot to engage; when the bot starts up it will remain silent until one of the `startTriggers` occurs in the chat. Once triggered, it will continue to respond until a `stopTrigger` occurs. Triggers can be exact or partial matches, and may be made case sensitive.

## Customization

The libraries, settings, and AIML files from the [AIMLBot project] have been included in this repo for convenience. You can modify the existing AIML files or add new ones to the `aiml` folder and they'll be picked up when the plugin is loaded.

[AIMLBot project]: http://sourceforge.net/projects/aimlbot/?source=navbar
