using System;

namespace Net.Library.message.implementation
{
    [Serializable]
    public struct TextMessage : Message
    {
        public string Text { get; }

        public TextMessage(string text)
        {
            Text = text;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}