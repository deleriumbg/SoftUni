import java.util.Arrays;
import java.util.Scanner;

public class Largest_3_Numbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int[] numbers = Arrays.stream(scanner.nextLine().split(" ")).mapToInt(Integer::parseInt).sorted().toArray();
        int resultCount = Math.min(numbers.length, 3);
        for (int i = numbers.length - 1; i >= numbers.length - resultCount; i--) {
            System.out.printf("%d%n", numbers[i]);
        }
    }
}
