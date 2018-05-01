import java.util.Arrays;
import java.util.Scanner;

public class Vowel_or_Digit {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String input = scanner.nextLine();
        String[] digits = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"};
        String[] vowels = {"a", "e", "o", "u", "y", "i"};
        if (Arrays.asList(digits).contains(input)){
            System.out.println("digit");
        }else if (Arrays.asList(vowels).contains(input)){
            System.out.println("vowel");
        }else{
            System.out.println("other");
        }
    }
}
