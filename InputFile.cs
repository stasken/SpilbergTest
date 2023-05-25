using System;
namespace SpilbergTest
{
	public class InputFile
	{
		public string filePath { get; set; }
		public List<string> words { get; set; }

        public int minLengthWord { get; set; }
        public int maxLengthWord { get; set; }

		public InputFile(string fileName)
		{
			words = new List<string>();

            this.filePath = Path.Combine(GetProjectRootDirectory(), fileName);

            StoreWordsFromFileIntoList();

            this.minLengthWord = this.words.Min(word => word.Length);
            this.maxLengthWord = this.words.Max(word => word.Length);
        }

        public void StoreWordsFromFileIntoList()
		{
            try
            {
                using (StreamReader sr = new StreamReader(this.filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line!="") words.Add(line);
                    }
                }
                words = words.Distinct().ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        static string GetProjectRootDirectory()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string solutionRootDirectory = Directory.GetParent(currentDirectory).Parent.Parent.FullName;
            return solutionRootDirectory;
        }
    }
}

