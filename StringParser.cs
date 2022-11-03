using System;
using System.Collections.Generic;

public class StringParser
{

    public string[] TestCases { get; set; }

    public StringParser(string[] TestCases)
    {
        this.TestCases = TestCases;
    }
    //This pattern will keep repeating for every individual test case.
    //Returns a List of List<string> objects that are ordered as follows: {List<string>blackvalues, List<string>blacksuites, List<string>whitevalues , List<string>whitesuites} <----- This is one test case.
    public static List<List<string>> ValuesandSuitesforBlackandWhite(StringParser p)
    {
        List<List<string>> lists = new List<List<string>>(); //return list

         string[] delim = { " ", ":", "Black", "White" };
         char[] typesep = { '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A' };
         char[] suitesep = { 'H', 'D', 'S', 'C' };

        foreach (string stringarray in p.TestCases)
        {
        List<string[]> bhands = new List<string[]>();
        List<string[]> bhandt = new List<string[]>();
        List<string[]> whands = new List<string[]>();
        List<string[]> whandt = new List<string[]>();
        List<string> bhandv = new List<string>();
        List<string> whandv = new List<string>();
        List<string> bhandss = new List<string>();
        List<string> whandss = new List<string>();

            string[] parts = stringarray.Split(delim, System.StringSplitOptions.RemoveEmptyEntries);

            //Tells us the suites of the match
            foreach (var part in parts)
            {
               part.Split(typesep, System.StringSplitOptions.RemoveEmptyEntries);
            }

            //Tells us the types (hence the values) of the match 
            foreach (var part in parts)
            {
                part.Split(suitesep, System.StringSplitOptions.RemoveEmptyEntries);
            }

            //******************************************************************************************************************************

            //(b)lack and (w)hite (hand)'s (s)uites and (t)ypes
            //NOTE: Because Split() returns an array of strings, these lists are of string[]'s (we will convert them in a moment).
            

            foreach (var part in parts)
            {
                if (bhands.Count < 5)
                    bhands.Add(part.Split(typesep, System.StringSplitOptions.RemoveEmptyEntries));
                else
                    whands.Add(part.Split(typesep, System.StringSplitOptions.RemoveEmptyEntries));

                if (bhandt.Count < 5)
                    bhandt.Add(part.Split(suitesep, System.StringSplitOptions.RemoveEmptyEntries));
                else
                    whandt.Add(part.Split(suitesep, System.StringSplitOptions.RemoveEmptyEntries));

            }

            //********************************************************************************************************************************

            //Convert the types to values in blacks' hand
            foreach (var val in bhandt)
            {
                //With a for loop you can modify elements  
                for (int x = 0; x < val.Length; x++)
                {
                    if (val[x] == "T")
                    {
                        val[x] = "10";
                    }
                    if (val[x] == "J")
                    {
                        val[x] = "11";
                    }
                    if (val[x] == "Q")
                    {
                        val[x] = "12";
                    }
                    if (val[x] == "K")
                    {
                        val[x] = "13";
                    }
                    if (val[x] == "A")
                    {
                        val[x] = "14";
                    }

                }
            }

            //Convert the types to values in whites' hand
            foreach (var val in whandt)
            {
                //With a for loop you can modify elements  
                for (int x = 0; x < val.Length; x++)
                {
                    if (val[x] == "T")
                    {
                        val[x] = "10";
                    }
                    if (val[x] == "J")
                    {
                        val[x] = "11";
                    }
                    if (val[x] == "Q")
                    {
                        val[x] = "12";
                    }
                    if (val[x] == "K")
                    {
                        val[x] = "13";
                    }
                    if (val[x] == "A")
                    {
                        val[x] = "14";
                    }

                }
            }

            //*********************************************************************************************************************************
            

            //Convert string[]'s to int and string arrays for values and suites respectively.
            foreach (var val in bhandt)
            {
                foreach (var v in val)
                {
                    bhandv.Add(v);
                }
            }
            foreach (var val in whandt)
            {
                foreach (var v in val)
                {
                    whandv.Add(v);
                    //Console.WriteLine(String.Join(Environment.NewLine, int.Parse(v)));
                }
            }
            foreach (var val in bhands)
            {
                foreach (var v in val)
                {
                    bhandss.Add(v);
                    //Console.WriteLine(String.Join(Environment.NewLine, int.Parse(v)));
                }
            }
            foreach (var val in whands)
            {
                foreach (var v in val)
                {
                    whandss.Add(v);
                    //Console.WriteLine(String.Join(Environment.NewLine, int.Parse(v)));
                }
            }

            //Sort values lists into linear order (****This eliminates the ordering of the suites******)
            //bhandv.Sort();
            //whandv.Sort();

            lists.Add(bhandv);//black values
            lists.Add(bhandss);//black suites
            lists.Add(whandv);//white values
            lists.Add(whandss);//white suites


            //bhands.Clear();
            //bhandt.Clear();
            //whands.Clear();
            //whandt.Clear();
            //bhandv.Clear();
            //whandv.Clear();
            //bhandss.Clear();
            //whandss.Clear();

        }
            return lists;
    }
}

