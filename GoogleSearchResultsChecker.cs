using NUnit.Framework;
using System;

namespace CertentTestTask
{
    public static class GoogleSearchResultsChecker
    {
       
        public static void CheckResultsArePresent(int arg1, int arg2)
        {
            try
            {
                Assert.Greater(arg1, arg2);
            }
            catch (Exception)
            {
                TestContext.WriteLine("Assertion failed");
                TestContext.WriteLine("There are no search results");
                throw;
            }
        }

        public static void CheckSearchResults(string arg1, string arg2)
        {
            try
            {
                Assert.IsTrue(arg1.ToLower().Contains(arg2.ToLower()));
            }
            catch (Exception)
            {
                TestContext.WriteLine("Assertion failed");
                TestContext.WriteLine("Seach result do not contain seached query");
                throw;
            }
            finally
            {
                TestContext.WriteLine("Searching for: {0}", arg2);
                TestContext.WriteLine("Actual seach result content: {0} \n", arg1);
            }
        }

        public static void CheckSearchResultsLinks(string arg1, string arg2)
        {
            try
            {
                Assert.IsTrue(arg1.Contains(arg2));
            }
            catch (Exception)
            {
                TestContext.WriteLine("Assertion failed");
                TestContext.WriteLine("Link do not point to a given site");
                throw;
            }
            finally
            {
                TestContext.WriteLine("Link shoul point to: {0}", arg2);
                TestContext.WriteLine("Actual link points to: {0} \n", arg1);
            }
        }

        public static void CheckNumberOfSearchResults(int arg1, int arg2)
        {
            try
            {
                Assert.AreEqual(arg1, arg2);
            }
            catch (Exception)
            {
                TestContext.WriteLine("Assertion failed");
                TestContext.WriteLine("Actual number of seach results do not meet expected");
                throw;
            }
            finally
            {
                TestContext.WriteLine("Expected number of seach results: {0}", arg1.ToString());
                TestContext.WriteLine("Actual number of seach results: {0} \n", arg2.ToString());
            }


        }
    }
}
