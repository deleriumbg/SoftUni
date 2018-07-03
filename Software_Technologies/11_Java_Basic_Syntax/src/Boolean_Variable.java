import java.util.Scanner;

public class Boolean_Variable {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String input = scanner.nextLine();
        System.out.println(Boolean.parseBoolean(input) ? "Yes" : "No");
    }
}
