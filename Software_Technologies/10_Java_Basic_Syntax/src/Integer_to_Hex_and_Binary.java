import java.util.Scanner;

public class Integer_to_Hex_and_Binary {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int input = scanner.nextInt();
        String hex = Integer.toString(input,16).toUpperCase();
        String binary = Integer.toString(input,2);
        System.out.printf("%s%n%s", hex, binary);
    }
}
