using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace SearchWords_ClassLibrary
{
    public class Word
    {
        public string text { get; }

        public Word(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("The text can't be null or empty...", nameof(input));
            }

            text = input;
        }
    }

    public interface IWordsRepository
    {
        IEnumerable<Word> GetWords();
    }

    public class WordsRepository : IWordsRepository
    {
        private readonly List<Word> _words;

        public WordsRepository(List<string> input)
        {
            _words = input.Select(w => new Word(w)).ToList();
        }

        public IEnumerable<Word> GetWords()
        {
            return _words;
        }
    }

    public class DDD_Six_Letter_Words
    {
        private readonly IWordsRepository _wordsRepository;

        public DDD_Six_Letter_Words(IWordsRepository wordsRepository)
        {
            _wordsRepository = wordsRepository;
        }

        public IEnumerable<string> Search_SixLetter_Words()
        {
            List<string> general_words = _wordsRepository.GetWords().Select(w => w.text).ToList();

            if (general_words.Count == 0)
            {
                return new List<string>();
            }

            var six_letter_words = general_words.Where(w => w.Length == 6);

            var result = new List<string>();

            foreach (var word in six_letter_words)
            {
                for (int i = 1; i < 6; i++)
                {
                    string first_part = word.Substring(0, i);
                    string second_part = word.Substring(i);

                    if (general_words.Contains(first_part) && general_words.Contains(second_part))
                    {
                        result.Add(word);
                        break;
                    }
                }
            }

            return result;
        }
    }
}
