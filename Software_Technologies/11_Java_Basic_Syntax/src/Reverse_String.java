import java.util.Scanner;

public class Reverse_String {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        char[] input = scanner.nextLine().toCharArray();
        for (int i = input.length - 1; i >= 0 ; i--) {
            System.out.printf("%s", input[i]);
        }
    }
}
