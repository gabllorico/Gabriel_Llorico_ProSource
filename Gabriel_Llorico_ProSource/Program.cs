using Services;

namespace Gabriel_Llorico_ProSource
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var isNullAllowed = true;
            //List<string?> TestData() is populated below, you can add test cases below
            foreach (var testString in TestData())
            {
                //to remove immediately null or empty or whitespace
                if (string.IsNullOrWhiteSpace(testString))
                {
                    if (testString == null)
                    {
                        if (isNullAllowed)
                        {
                            Console.WriteLine("null will return true");
                        }
                        else
                        {
                            Console.WriteLine("null will return false");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{testString} will return true");
                    }
                    continue;
                }

                var removedUnnecessaryCharacters = StringManipulationHelpers.RemoveCharacters(testString);

                if (string.IsNullOrWhiteSpace(removedUnnecessaryCharacters))
                {
                    Console.WriteLine($"{testString} will return true");
                }
                else
                {
                    if (StringManipulationHelpers.CheckIfBracketPlacementIsCorrect(removedUnnecessaryCharacters))
                    {
                        Console.WriteLine($"{testString} will return true");
                    }
                    else
                    {
                        Console.WriteLine($"{testString} will return false");
                    }
                }
            }
        }

        private static List<string?> TestData()
        {
            return new List<string?>
            {
                "{}", //will return true (closed set of bracket)
                "}{", //will return false (closed bracket cant proceed all open brackets)
                "{{}", //will return false (one bracket pair was not closed)
                "", //will return true (empty string will return true)
                "{abcdE1234.}", //will return true (non bracket will be ignored)
                "{{a}{b{c}d}E1234.}", //will return true (perfectly closed brackets)
                "{{}}}{", //will return false (equal brackets but one is open)
                "abcdE1234.", //will return true (ignore characters)
                "{a}bc}De{12{34.}", //will return false (unclosed bracket)
                "{}}{{}", //will return false (equal sets but not closed)
                null //will return true or false dependent on the value listed on the variable isNullAllowed
            };
        }
    }
}