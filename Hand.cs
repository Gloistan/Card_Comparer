using System;
using System.Collections.Generic;

public class Hand
{
	
		public string Owner { get; set; }

		public List<string> Suites { get; set; }

		public List<string> Values { get; set; }

		public List<int> sortedValues { get; set; }


	public Hand(string Owner, List<string> Suites, List<string> Values, List<int> sortedValues)
        {
			this.Owner = Owner;
			this.Suites = Suites;
			this.Values = Values;
			this.sortedValues = sortedValues;
        }

	public static List<int> returnIntList(List<string> stringvalues)
    {
		List<int> IntList = new List<int>();

		foreach(string s in stringvalues)
        {
			IntList.Add(int.Parse(s));
        }

        IntList.Sort();

		return IntList;
    }

	public static List<Hand> handBuilder(List<List<string>> testcases)
    {
        List<Hand> hands = new List<Hand>();


        int listindexer = 0;
        int blackorwhite = 0;
        List<String> values = new List<String>();

        foreach (List<string> ls in testcases)
        {
            List<String> suites = new List<String>();


            listindexer++; //odd numbers are values, even numbers are suites; each set of 2 alternates between black and white.

            string owner = "";

            if (listindexer % 2 == 1)
            {
                values = ls;
                //Console.WriteLine(String.Join(Environment.NewLine, ls));
            }
            if (listindexer % 2 == 0) //If we have advanced two List<string> objects further into the List<List<string>> array.
            {
                if (blackorwhite % 2 == 0) //This is a black hand (every even hand)
                {
                    suites = ls;
                    owner = "Black";
                    //Console.WriteLine(String.Join(Environment.NewLine, values));
                    hands.Add(new Hand(owner, suites, values, Hand.returnIntList(values)));
                    values.Clear();
                    blackorwhite++;
                }
                else //This is a white hand (every odd hand)
                {
                    suites = ls;
                    owner = "White";
                    hands.Add(new Hand(owner, suites, values, Hand.returnIntList(values)));
                    values.Clear();
                    blackorwhite++;
                }
            }
        }
        return hands;
    }

}
