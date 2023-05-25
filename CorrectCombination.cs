using System;
using System.Xml.Linq;

namespace SpilbergTest
{
	public class CorrectCombination
	{
		public List<string> wordsUsed { get; set; }

		public string result { get { return String.Join("", wordsUsed); } }

		public CorrectCombination()
		{
			this.wordsUsed = new List<string>();
        }

        public CorrectCombination(List<string> words)
        {
            this.wordsUsed = words;
        }

        public override string ToString()
        {
            return $"{System.String.Join("+", this.wordsUsed)}={result}";
        }
    }
}

