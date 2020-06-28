// This exercise is strongly inspired by https://dotnetfiddle.net/o3Q1tc

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
            text = "karunya123.edu  , www.karunya.edu, www.karunya.edu,  " +
                   "http://karunya.edu, https://karunya.edu, www.karunyauniversity.in  ,  " +
                   "https://mykarunya.edu, https://www.karunya.edu  ,  " +
                   "google.com,  google.co.in, www.google.com,  https://www.gmail.com, gmail.com";
        }

        [TestCleanup]
        public void CleanUp() => text = null;

        [TestMethod]
        public void Test_01_extract_all_URLs()
        {
            // 1. Extract all the URLs
            string pattern = @"(http[s]?://)?(www.)?\w+(.\w{2,3})+";
            var matches = EvaluatePattern(pattern);

            var expectedResult = new[]
            {
                "karunya123.edu", "www.karunya.edu", "www.karunya.edu", "http://karunya.edu",
                "https://karunya.edu", "www.karunyauniversity.in", "https://mykarunya.edu",
                "https://www.karunya.edu", "google.com", "google.co.in", "www.google.com",
                "https://www.gmail.com", "gmail.com"
            };
            Assert.IsTrue(EvaluateResult(expectedResult, matches));
        }

        [TestMethod]
        public void Test_02_extract_all_URLs_starting_with_https()
        {
            // 2. Display all the URLs which start with https://
            string pattern = @"https://(www.)?\w+(.\w{2,3})+";
            var matches = EvaluatePattern(pattern);

            var expectedResult = new[]
            {
                "https://karunya.edu", "https://mykarunya.edu",
                "https://www.karunya.edu", "https://www.gmail.com"
            };
            Assert.IsTrue(EvaluateResult(expectedResult, matches));
        }

        [TestMethod]
        public void Test_03_extract_all_URLs_ending_with_edu()
        {
            // 3. URLs ending with .edu
            string pattern = @"(http[s]?://)?(www.)?\w+.edu";
            var matches = EvaluatePattern(pattern);

            var expectedResult = new[]
            {
                "karunya123.edu", "www.karunya.edu", "www.karunya.edu", "http://karunya.edu",
                "https://karunya.edu", "https://mykarunya.edu", "https://www.karunya.edu"
            };
            Assert.IsTrue(EvaluateResult(expectedResult, matches));
        }

        [TestMethod]
        public void Test_04_replace_all_vowels_in_the_text_with_X()
        {
            // 4. Replace all the vowels in the text with given 'X'
            string pattern = @"[aeiou]";
            string result = ReplacePatternInText(pattern, "X");

            var expectedResult = "kXrXnyX123.XdX  , www.kXrXnyX.XdX, www.kXrXnyX.XdX,  http://kXrXnyX.XdX, " +
                                 "https://kXrXnyX.XdX, www.kXrXnyXXnXvXrsXty.Xn  ,  https://mykXrXnyX.XdX, https://www.kXrXnyX.XdX  ,  " +
                                 "gXXglX.cXm,  gXXglX.cX.Xn, www.gXXglX.cXm,  https://www.gmXXl.cXm, gmXXl.cXm";
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Test_05_replace_all_numbers_in_the_text_with_1()
        {
            // 5. Replace all the numbers in the text with 1
            string pattern = @"\d";
            string result = ReplacePatternInText(pattern, "1");

            var expectedResult = "karunya111.edu  , www.karunya.edu, www.karunya.edu,  http://karunya.edu, " +
                                 "https://karunya.edu, www.karunyauniversity.in  ,  https://mykarunya.edu, https://www.karunya.edu  ,  " +
                                 "google.com,  google.co.in, www.google.com,  https://www.gmail.com, gmail.com";
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Test_06_display_all_duplicate_urls()
        {
            // 6. Display all duplicate URLs
            string pattern = @"(http[s]?://)?(www.)?\w+(.\w{2,3})+";
            var matches = EvaluatePattern(pattern).ToList();

            var duplicateResults = new List<string>();
            foreach (var match in matches)
            {
                if (matches.FindAll(m => m.Equals(match)).Count > 1)
                {
                    duplicateResults.Add(match);
                }
            }

            var expectedResult = new string[] { "www.karunya.edu", "www.karunya.edu" };
            Assert.IsTrue(EvaluateResult(expectedResult, duplicateResults.ToArray()));
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