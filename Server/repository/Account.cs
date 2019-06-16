namespace Server.repository
{
    internal class Account
    {
        internal string Name { get; set; }
        internal uint Wins { get; set; }

        internal Account(string name, uint wins)
        {
            Name = name;
            Wins = wins;
        }

        public override string ToString() => Name + " " + Wins;
    }
}