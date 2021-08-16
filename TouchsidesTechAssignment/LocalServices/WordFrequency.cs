using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace TouchsidesTechAssignment.LocalServices
{
    public class WordFrequency
    {
        public WordFrequency()
        {
        }
        public async Task<string> GetMostFrequentWord(string fileContent)
        {
            var item = WordCount(fileContent).ToList().FirstOrDefault();
            return $"Most frequent word: {item.Key} occurred {item.Value} times";
        }

        public async Task<string> GetMostFrequentSevenCharWord(string fileContent)
        {
            var item = WordCount(fileContent).Where(x => x.Key.Length == 7).OrderByDescending(y => y.Value).FirstOrDefault();
            return $"Most frequent 7-character word: {item.Key} occurred {item.Value} times";
        }

        public async Task<string> GetHighestScoringWord(string fileContent)
        {
            var item = GetWordWithScoreValue(fileContent).FirstOrDefault();
            return $"Highest scoring word(s) (according to the score table): {item.Key} with a score of {item.Value}";
        }

        public static Dictionary<string, int> GetWordWithScoreValue(string text, int numWords = int.MaxValue)
        {
            var delimiterChars = new char[] { ' ', ',', ':', '\t', '\"', '\r', '{', '}', '[', ']', '=', '/' };
            return text
                .Split(delimiterChars)
                .Where(x => x.Length > 0)
                .Select(x => x.ToLower())
                .GroupBy(x => x)
                .Select(x => new { Word = x.Key, Score = GetWordScoreValue(x.Key) })
                .OrderByDescending(x => x.Score)
                .Take(numWords)
                .ToDictionary(x => x.Word, x => x.Score);
        }

        public static int GetWordScoreValue(string word)
        {
            int score = 0;
            foreach (char cha in word)
            {
                score += GetScoreValuesPerChar(cha);
            }
            return score;
        }

        public static int GetScoreValuesPerChar(char letter)
        {
            var listScoreValues = new Dictionary<char, int>
            {
              {'A', 1  }, {'B', 3  }, {'C', 3  }, {'D', 2  }, {'E', 1  },{'F', 4  },{'G', 2  },{'H', 4  },{'I', 1  },
              {'J', 8  },{'K', 5  }, {'L', 1  },{'M', 3  },{'N', 1  }, {'O', 1  }, {'P', 3  }, {'Q', 10 },{'R', 1  },
              {'S', 1  },{'T', 1  },{'U', 1  },{'V', 4  },{'W', 4  },{'X', 8  }, {'Y', 4  },  {'Z', 10 }
            };
            return listScoreValues.Where(x => x.Key.Equals(char.Parse(letter.ToString().ToUpper()))).FirstOrDefault().Value;
        }
        public static Dictionary<string, int> WordCount(string text, int numWords = int.MaxValue)
        {
            var delimiterChars = new char[] { ' ', ',', ':', '\t', '\"', '\r', '{', '}', '[', ']', '=', '/' };
            return text
                .Split(delimiterChars)
                .Where(x => x.Length > 0)
                .Select(x => x.ToLower())
                .GroupBy(x => x)
                .Select(x => new { Word = x.Key, Count = x.Count() })
                .OrderByDescending(x => x.Count)
                .Take(numWords)
                .ToDictionary(x => x.Word, x => x.Count);
        }
    }
}