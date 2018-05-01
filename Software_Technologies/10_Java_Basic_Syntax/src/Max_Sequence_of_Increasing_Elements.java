import java.util.Arrays;
import java.util.Scanner;

public class Max_Sequence_of_Increasing_Elements {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int[] numbers = Arrays.stream(scanner.nextLine().split(" ")).mapToInt(Integer::parseInt).toArray();
        int count = 0;
        int start = 0;
        int maxCount = 0;

        for (int i = 0; i < numbers.length - 1; i++) {
            if (numbers[i] < numbers[i + 1]) {
                count++;
                if (count > maxCount) {
                    start = i - count;
                    maxCount = count;
                }
            } else {
                count = 0;
            }
        }
        for (int i = start + 1; i <= start + maxCount + 1; i++) {
            System.out.print(numbers[i] + " ");
        }
    }
}
