using System;
using System.Collections.Generic;
using System.Linq;

namespace Card_Comparer
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] testcases =
            {
                "Black: 2H 2D 5S 9C KD  White: 2C 2H 4S 4C AH",
                "Black: 2H 4S 4C 2D 4H  White: 8S 9S TS JS QS",
                "Black: 2H 3D 3S 3C KD  White: 2C 3H 4S 8C KH",
                "Black: 2H 2D 2S 2C KD  White: 2D 3H 4C 5S 6H",
                "Black: AH AD AS KC KD  White: 2C 2H 2S 2C AH",
                "Black: TH JH QH KH AH  White: TS JS QS KS AS", //Royal Flush tie
                "Black: 2H 3D 4S AC KD  White: 2C 3H 4S 8C KH",
                "Black: 2H 2D 3S 7C KD  White: 2D 2H 4C 5S AH",
                "Black: 2H 2D 3S 7C KD  White: 2D 2H 4C 5S AH"
            };

            StringParser tests = new StringParser(testcases);
            List<List<String>> lls = StringParser.ValuesandSuitesforBlackandWhite(tests);

            
            List<Hand> handslist = Hand.handBuilder(lls);

            List<HandRankBool> scoresheet = new List<HandRankBool>();

            foreach (Hand hand in handslist)
            {
                string owner = hand.Owner;
                var valgroup = hand.sortedValues.GroupBy(i => i);
                var suitegroup = hand.Suites.GroupBy(i => i);

                scoresheet.Add(HandRankBool.totalCheck(owner, valgroup, suitegroup));
            }

            List<string> results = HandRankBool.winner(scoresheet);

            foreach(string s in results)
            {
                Console.WriteLine(String.Join(Environment.NewLine, s));
            }

                
            
        }
    }
}
