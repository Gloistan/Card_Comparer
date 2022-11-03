using System;
using System.Collections.Generic;
using System.Linq;

public class HandRankBool
{
    public string Owner { get; set; }
    public int Highcard { get; set; }
    public int HighcardHand { get; set; }
    public string Hand { get; set; }
    public bool Straight { get; set; }
    public bool Flush { get; set; }

    public HandRankBool(string Owner, int Highcard, int HighcardHand, String Hand, bool Straight, bool Flush)
    {
        this.Owner = Owner;
        this.Highcard = Highcard;
        this.HighcardHand = HighcardHand;
        this.Hand = Hand;
        this.Straight = Straight;
        this.Flush = Flush;
    }

    private static bool checkFlush(IEnumerable<IGrouping<string, string>> skc)
    {
        if (skc.Count() > 1)
            return false;
        else
            return true;
    }
    private static bool checkStraight(IEnumerable<IGrouping<int, int>> vkc)
    {
        if (vkc.Count() < 5)
            return false;
        else
        {
            List<int> intlist = new List<int>();
            foreach (var grp in vkc)
            {
                intlist.Add(grp.Key);
            }

            if (intlist.Max() - intlist.Min() == 4)
                return true;
        }
        return false;
    }
    private static bool checkScratch(IEnumerable<IGrouping<int, int>> vkc)
    {
        if (check1pair(vkc) || check2pair(vkc) || check3kind(vkc) || check4kind(vkc) || checkFullHouse(vkc) || checkStraight(vkc))
            return false;
        else
            return true;
    }
    private static bool check1pair(IEnumerable<IGrouping<int, int>> vkc)
    {
        foreach (var grp in vkc)
        {
            if (grp.Count() == 2 && vkc.Count() == 4)
            {
                return true;
            }
        }
        return false;
    }
    private static bool check2pair(IEnumerable<IGrouping<int, int>> vkc)
    {
        foreach (var grp in vkc)
        {
            if (grp.Count() == 2 && vkc.Count() == 3)
            {
                return true;
            }
        }
        return false;
    }
    private static bool check3kind(IEnumerable<IGrouping<int, int>> vkc)
    {
        foreach (var grp in vkc)
        {
            if (grp.Count() == 3 && vkc.Count() == 3)
            {
                return true;
            }
        }
        return false;
    }
    private static bool check4kind(IEnumerable<IGrouping<int, int>> vkc)
    {
        foreach (var grp in vkc)
        {
            if (grp.Count() == 4)
            {
                return true;
            }
        }
        return false;
    }
    private static bool checkFullHouse(IEnumerable<IGrouping<int, int>> vkc)
    {
        foreach (var grp in vkc)
        {
            if (grp.Count() == 2 && vkc.Count() == 2 || grp.Count() == 3 && vkc.Count() == 2)
            {
                return true;
            }
        }
        return false;
    }
    private static int checkHighValue(IEnumerable<IGrouping<int, int>> vkc)
    {
        int highcard = 0;
            foreach (var grp in vkc)
            {
                if (grp.Key > highcard)
                    highcard = grp.Key;
            }
            return highcard;
    }
    private static int checkHighValueHand(IEnumerable<IGrouping<int, int>> vkc)
    {
        int highcard = 0;
        
        int high_count = 0;
            foreach (var grp in vkc)
            {
                if (grp.Count() > high_count)
                    high_count = grp.Count();
            }
            foreach (var grp in vkc)
            {
                if (grp.Count() == high_count && grp.Key > highcard)
                    highcard = grp.Key;
            }
            return highcard;
     
    }
    private static int StringValue(HandRankBool hr)
    {
        if (hr.Hand == "Scratch") { return 1; }
        if (hr.Hand == "Pair") { return 2; }
        if (hr.Hand == "2 Pairs") { return 3; }
        if (hr.Hand == "3 of a kind") { return 4; }
        if (hr.Hand == "Straight") { return 5; }
        if (hr.Hand == "Flush") { return 6; }
        if (hr.Hand == "Full House") { return 7; }
        if (hr.Hand == "4 of a kind") { return 8; }
        if (hr.Hand == "Straight Flush") { return 9; }
        if (hr.Hand == "Royal Flush") { return 10; }
        return 0;
    }





    public static HandRankBool totalCheck(string owner, IEnumerable<IGrouping<int, int>> vkc, IEnumerable<IGrouping<string, string>> skc)
    {
        //Console.WriteLine(String.Join(Environment.NewLine, vkc.Count()));

        int highvaluehand = checkHighValueHand(vkc);
        int highvalue = checkHighValue(vkc);
        bool flush = checkFlush(skc);
        bool straight = checkStraight(vkc);

        string hand = "";
        if (checkScratch(vkc)) { hand = "Scratch"; }
        if (check1pair(vkc)) { hand = "Pair"; }
        if (check2pair(vkc)) { hand = "2 Pairs"; }
        if (check3kind(vkc)) { hand = "3 of a kind"; }
        if (check4kind(vkc)) { hand = "4 of a kind"; }
        if (checkFullHouse(vkc)) { hand = "Full House"; }
        if (checkStraight(vkc)) { hand = "Straight"; }
        if (checkFlush(skc)) { hand = "Flush"; }
        if (checkStraight(vkc) && checkFlush(skc)) { hand = "Straight Flush"; }
        if (checkStraight(vkc) && checkFlush(skc) && highvalue == 14) { hand = "Royal Flush"; }


        return new HandRankBool(owner, highvalue, highvaluehand, hand, straight, flush);

    }
    
    public static List<string> winner(List<HandRankBool> hrb)
    {
        List<string> winners = new List<string>();
        if(hrb.Count % 2 == 0)
        {
        for (int i = 0; i <= ((hrb.Count() / 2) - 1); i++)
        {
            //Console.WriteLine(String.Join(Environment.NewLine, $"{hrb.ElementAt((2 * i))}, {hrb.ElementAt((2 * i) + 1)}"));
            if (StringValue(hrb.ElementAt((2*i))) > StringValue(hrb.ElementAt((2*i) + 1)))
            {
                winners.Add($"{ hrb.ElementAt((2 * i)).Owner } wins: {hrb.ElementAt((2 * i)).Hand} - High card: {hrb.ElementAt((2 * i)).HighcardHand}."); //black wins
            }
            
            if (StringValue(hrb.ElementAt((2 * i))) < StringValue(hrb.ElementAt((2 * i) + 1)))
            {
                winners.Add($"{ hrb.ElementAt((2 * i) + 1).Owner } wins: {hrb.ElementAt((2 * i) + 1).Hand} - High card: {hrb.ElementAt((2 * i) + 1).HighcardHand}."); //white wins
            }
            
            
            //Potential tie scenario
            if (StringValue(hrb.ElementAt((2 * i))) == StringValue(hrb.ElementAt((2 * i) + 1)))
            {
                if((hrb.ElementAt((2 * i) + 1).Highcard) > (hrb.ElementAt((2 * i)).Highcard))
                {
                    winners.Add($"{ hrb.ElementAt((2 * i) + 1).Owner } wins: {hrb.ElementAt((2 * i) + 1).Hand} - High card: {hrb.ElementAt((2 * i) + 1).Highcard}."); //white wins tie
                }
                if ((hrb.ElementAt((2 * i) + 1).Highcard) < (hrb.ElementAt((2 * i)).Highcard))
                {
                    winners.Add($"{ hrb.ElementAt((2 * i)).Owner } wins: {hrb.ElementAt((2 * i)).Hand} - High card: {hrb.ElementAt((2 * i)).Highcard}."); //black wins tie
                }
                if ((hrb.ElementAt((2 * i) + 1).Highcard == hrb.ElementAt((2 * i)).Highcard))
                {
                    winners.Add($"tie - Highcards: {hrb.ElementAt((2 * i) + 1).Highcard} vs {hrb.ElementAt((2 * i)).Highcard}");
                }
            }

        }
        return winners;

        }
        else
        {
            decimal d = (hrb.Count()/2);
            for (int i = 0; i <= (Math.Floor(d) + 1); i++)
            {
                //Console.WriteLine(String.Join(Environment.NewLine, $"{hrb.ElementAt((2 * i))}, {hrb.ElementAt((2 * i) + 1)}"));
                if (StringValue(hrb.ElementAt((2 * i))) > StringValue(hrb.ElementAt((2 * i) + 1)))
                {
                    winners.Add($"{ hrb.ElementAt((2 * i)).Owner } wins: {hrb.ElementAt((2 * i)).Hand} - High card: {hrb.ElementAt((2 * i)).HighcardHand}."); //black wins
                }

                if (StringValue(hrb.ElementAt((2 * i))) < StringValue(hrb.ElementAt((2 * i) + 1)))
                {
                    winners.Add($"{ hrb.ElementAt((2 * i) + 1).Owner } wins: {hrb.ElementAt((2 * i) + 1).Hand} - High card: {hrb.ElementAt((2 * i) + 1).HighcardHand}."); //white wins
                }


                //Potential tie scenario
                if (StringValue(hrb.ElementAt((2 * i))) == StringValue(hrb.ElementAt((2 * i) + 1)))
                {
                    if ((hrb.ElementAt((2 * i) + 1).Highcard) > (hrb.ElementAt((2 * i)).Highcard))
                    {
                        winners.Add($"{ hrb.ElementAt((2 * i) + 1).Owner } wins: {hrb.ElementAt((2 * i) + 1).Hand} - High card: {hrb.ElementAt((2 * i) + 1).Highcard}."); //white wins tie
                    }
                    if ((hrb.ElementAt((2 * i) + 1).Highcard) < (hrb.ElementAt((2 * i)).Highcard))
                    {
                        winners.Add($"{ hrb.ElementAt((2 * i)).Owner } wins: {hrb.ElementAt((2 * i)).Hand} - High card: {hrb.ElementAt((2 * i)).Highcard}."); //black wins tie
                    }
                    if ((hrb.ElementAt((2 * i) + 1).Highcard == hrb.ElementAt((2 * i)).Highcard))
                    {
                        winners.Add($"tie - Highcards: {hrb.ElementAt((2 * i) + 1).Highcard} vs {hrb.ElementAt((2 * i)).Highcard}");
                    }
                }

            }
            return winners;
        }

    }
}


