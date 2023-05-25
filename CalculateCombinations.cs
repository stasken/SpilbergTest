using System;
namespace SpilbergTest
{
    public class CalculateCombinations
    {
        public List<CorrectCombination> combinations { get; set; }
        public InputFile wordsFile { get; set; }

        public int lengthFullWord { get; set; }
        public int countWordsNeeded { get; set; }

        public List<string> possibleResultWords { get; set; }

        public CalculateCombinations(InputFile inputFile, int length, int countWords = 2)
        {
            this.combinations = new List<CorrectCombination>();
            this.wordsFile = inputFile;

            this.lengthFullWord = length;
            this.countWordsNeeded = countWords;

            int maxLengthWord = inputFile.words.Max(a => a.Length);
            if (maxLengthWord >= length)
            {
                this.possibleResultWords = this.wordsFile.words.Where(a => a.Length.Equals(this.lengthFullWord)).ToList();
                GetAllCombinations();
            }
            else
            {
                this.possibleResultWords = new List<string>();
            }
        }

        public void GetAllCombinations()
        {
            // 2 words

            // for index = min length of any word in list
            // until index = max length of combination result length - minimum length as above described
            for (int lengthWord = this.wordsFile.minLengthWord; lengthWord <= this.lengthFullWord - this.wordsFile.minLengthWord; lengthWord++)
            {
                // for every index of possible lengths, we'll look for complementary words in the list where total length of the combination
                // is the length we're looking for. And see which combinations of these results in a combination existing in the file

                // All words of lists with current length and all words with length difference of total length - current length
                List<string> currentBeginWordsOfCurrentLength = this.wordsFile.words.Where(word => word.Length.Equals(lengthWord)).ToList();
                List<string> currentEndWordsOfCurrentLength = this.wordsFile.words.Where(word => word.Length.Equals(lengthFullWord - lengthWord)).ToList();

                // For each begin of word, check if possible result starts with that word. If so then check that result if endwords contains last part without beginWord
                foreach (var beginOfWord in currentBeginWordsOfCurrentLength)
                {
                    if (this.possibleResultWords.Any(result => result.StartsWith(beginOfWord) && currentEndWordsOfCurrentLength.Contains(result.Substring(lengthWord))))
                    {
                        List<string> resultsFound = this.possibleResultWords.Where(result => result.StartsWith(beginOfWord) && currentEndWordsOfCurrentLength.Contains(result.Substring(lengthWord))).ToList();

                        foreach (var result in resultsFound)
                        {
                            string endWord = result.Substring(lengthWord);
                            List<string> combinationWords = new List<string>
                            {
                                beginOfWord,
                                endWord
                            };
                            CorrectCombination combination = new CorrectCombination(combinationWords);

                            combinations.Add(combination);
                        }
                    }
                }

            }
        }
    }
}
