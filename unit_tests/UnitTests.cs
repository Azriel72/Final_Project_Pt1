using SearchWords_ClassLibrary;

namespace unit_tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestMethod_Empty()
        {
            List<string> input = new List<string>() {};
            IWordsRepository repository = new WordsRepository(input);
            var search_service = new DDD_Six_Letter_Words(repository);
            var six_letter_words = search_service.Search_SixLetter_Words();
            List<string> expected_result = new List<string>() { };
            Assert.IsTrue(expected_result.SequenceEqual(six_letter_words));
        }

        [TestMethod]
        public void TestMethod_OneFound()
        {
            List<string> input = new List<string>() {"ho", "laas", "holaas"};
            IWordsRepository repository = new WordsRepository(input);
            var search_service = new DDD_Six_Letter_Words(repository);
            var six_letter_words = search_service.Search_SixLetter_Words();
            List<string> expected_result = new List<string>() { "holaas" };
            Assert.IsTrue(expected_result.SequenceEqual(six_letter_words));
        }

        [TestMethod]
        public void TestMethod_OneFound_pt2()
        {
            List<string> input = new List<string>() { "ca", "chus", "cachus" };
            IWordsRepository repository = new WordsRepository(input);
            var search_service = new DDD_Six_Letter_Words(repository);
            var six_letter_words = search_service.Search_SixLetter_Words();
            List<string> expected_result = new List<string>() { "cachus" };
            Assert.IsTrue(expected_result.SequenceEqual(six_letter_words));
        }
    }
}