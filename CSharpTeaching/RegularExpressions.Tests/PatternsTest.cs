using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
using System;
using System.Linq;
using System.Collections.Generic;

namespace RegularExpressions.Tests
{
    [TestClass]
    public class PatternsTest
    {
        private string text;

        [TestInitialize]
        public void Initialize()
        {
            text = "https://tokyo2020.org  ,  " +
                   "https://www.bing.com , www.bing.com , " +
                   "www.google.com, www.google.com,  https://www.gmail.com, gmail.com, " +
                   "http://web.mit.edu,  https://www.rwth-aachen.de";
        }

        [TestCleanup]
        public void CleanUp() => text = null;

        [TestMethod]
        public void Test_01_extract_all_URLs()
        {
            // 1. Extract all the URLs
            var pattern = string.Empty; // Insert pattern to extract the expected result below
            var matches = EvaluatePattern(pattern);

            var expectedResult = new[]
            {
                "https://tokyo2020.org",
                "https://www.bing.com",
                "www.bing.com",
                "www.google.com",
                "www.google.com",
                "https://www.gmail.com",
                "gmail.com",
                "http://web.mit.edu",
                "https://www.rwth-aachen.de"
            };
            Assert.IsTrue(EvaluateResult(expectedResult, matches));
        }

        [TestMethod]
        public void Test_02_extract_all_URLs_starting_with_https()
        {
            // 2. Display all the URLs which start with https://
            var pattern = string.Empty; // Insert pattern to extract the expected result below
            var matches = EvaluatePattern(pattern);

            var expectedResult = new[]
            {
                "https://tokyo2020.org",
                "https://www.bing.com",
                "https://www.gmail.com",
                "https://www.rwth-aachen.de"
            };
            Assert.IsTrue(EvaluateResult(expectedResult, matches));
        }

        [TestMethod]
        public void Test_03_extract_all_URLs_ending_with_com()
        {
            // 3. URLs ending with .com
            var pattern = string.Empty; // Insert pattern to extract the expected result below
            var matches = EvaluatePattern(pattern);

            var expectedResult = new[]
            {
                "https://www.bing.com",
                "www.bing.com",
                "www.google.com",
                "www.google.com",
                "https://www.gmail.com",
                "gmail.com",
            };
            Assert.IsTrue(EvaluateResult(expectedResult, matches));
        }

        [TestMethod]
        public void Test_04_replace_all_vowels_in_the_text_with_X()
        {
            // 4. Replace all the vowels in the text with given 'X'
            var pattern = string.Empty; // Insert pattern to extract the expected result below
            string result = ReplacePatternInText(pattern, "X");

            var expectedResult = "https://tXkyX2020.Xrg  ,  " +
                   "https://www.bXng.cXm , www.bXng.cXm , " +
                   "www.gXXglX.cXm, www.gXXglX.cXm,  https://www.gmXXl.cXm, gmXXl.cXm, " +
                   "http://wXb.mXt.XdX,  https://www.rwth-XXchXn.dX";
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Test_05_replace_all_numbers_in_the_text_with_1()
        {
            // 5. Replace all the numbers in the text with 1
            var pattern = string.Empty; // Insert pattern to extract the expected result below
            string result = ReplacePatternInText(pattern, "1");

            var expectedResult = "https://tokyo1111.org  ,  " +
                   "https://www.bing.com , www.bing.com , " +
                   "www.google.com, www.google.com,  https://www.gmail.com, gmail.com, " +
                   "http://web.mit.edu,  https://www.rwth-aachen.de";
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Test_06_display_all_duplicate_urls()
        {
            // 6. Display all duplicate URLs
            var expectedResult = new string[] { "www.google.com", "www.google.com" };

            // Your code belongs here!
            // Also adjust the assert statement below

            Assert.AreEqual(expectedResult, null);
        }

        private string[] EvaluatePattern(string pattern)
        {
            var expression = new Regex(pattern);
            var matches = expression.Matches(text);

            Console.WriteLine("Found matches: \n");
            foreach (var match in matches)
            {
                Console.WriteLine(match);
            }

            return (from match in matches select match.Value).ToArray();
        }

        private string ReplacePatternInText(string pattern, string replacement)
        {
            var expression = new Regex(pattern);
            var replacedText = expression.Replace(text, replacement);

            Console.WriteLine("Replaced text: \n");
            Console.WriteLine(replacedText);
            return replacedText;
        }

        private bool EvaluateResult(string[] expected, string[] actual)
        {
            Assert.AreEqual(expected.Length, actual.Length);
            foreach (var item in expected)
                Assert.IsTrue(actual.Contains(item));

            return true;
        }
    }
}