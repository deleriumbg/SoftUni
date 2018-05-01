import java.util.Scanner;

public class Sum_Two_Numbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double num1 = scanner.nextDouble();
        double num2 = scanner.nextDouble();
        System.out.printf("%.2f", num1 + num2);
    }
}
