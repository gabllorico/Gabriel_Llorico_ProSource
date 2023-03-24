using System.Text.RegularExpressions;

namespace Services
{
    public class StringManipulationHelpers
    {
        public static string RemoveCharacters(string input)
        {
            return Regex.Replace(input, @"[^{}]", string.Empty);
        }

        public static bool CheckIfBracketPlacementIsCorrect(string input)
        {
            var stringLength = input.Length;
            var validCombination = false;

            //Checks if first character is } or last character is { and it will return false
            //Checks if length of trimmed characters is odd then it will return false
            //Check if number of { is not equal to number of } then it will return false
            if (input[0].ToString() == "}" || input[stringLength - 1].ToString() == "{" || stringLength % 2 != 0 ||
                input.Count(x => x.ToString() == "}") != input.Count(x => x.ToString() == "{"))
            {
                return validCombination;
            }

            var notStopChecking = true;

            //keeps deleting till input.length is zero or previous before cleanup is equal to cleaned up string
            while (notStopChecking)
            {
                var beforeRemoval = input;
                input = input.Replace("{}", "");
                
                //checks if before removing {} is equal to after removing {}, meaning no more set of closed braces
                if (beforeRemoval == input)
                {
                    validCombination = false;
                    notStopChecking = false;
                }
                //checks if all perfectly closed brackets are removed, meaning it is a perfect set of brackets
                if (input.Length == 0)
                {
                    validCombination = true;
                    notStopChecking = false;
                }
            }

            return validCombination;
        }
    }
}