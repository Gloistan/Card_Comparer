import java.util.Scanner;  // Import the Scanner class

public class Main {

    String[] testcases =
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

    public static void main(String[] args) {
        Scanner myObj = new Scanner(System.in);  // Create a Scanner object
        System.out.println("Please enter in  comma separated values with this pattern: \"Black: 2H 2D 5S 9C KD  White: 2C 2H 4S 4C AH\"");

        while(myObj.hasNext())
        {
            System.out.println(myObj);
        }
        //String userName = myObj.nextLine();  // Read user input
        //System.out.println("Username is: " + userName);  // Output user input
    }

}
