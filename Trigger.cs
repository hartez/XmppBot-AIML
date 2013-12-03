using System;

namespace XmppBot_AIML
{
    public class Trigger
    {
        public bool CaseSensitive { get; set; }
        public string Text { get; set; }
        public bool Partial { get; set; }

        public bool Matches(string line)
        {
            if(!Partial)
            {
                return String.Equals(line, Text,
                    CaseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase);
            }

            return line.IndexOf(Text, CaseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}