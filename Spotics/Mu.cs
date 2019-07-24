namespace Spotics
{
    internal class Mu
    {
        public string id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public int lang { get; set; }
        public string text { get; set; }

        public Translate[] translate { get; set; }
    }

    internal class Translate
    {
        public string id { get; set; }
        public int lang { get; set; }
        public string url { get; set; }
        public string text { get; set; }
    }
}