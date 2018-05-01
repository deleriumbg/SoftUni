import java.util.Arrays;
import java.util.Scanner;

public class Most_Frequent_Number {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int[] numbers = Arrays.stream(scanner.nextLine().split(" ")).mapToInt(Integer::parseInt).toArray();
        int count = 0;
        int maxCount = 0;
        int maxNumber = numbers[0];
        for (int i = 0; i < numbers.length; i++) {
            for (int j = i; j < numbers.length; j++) {
                if (numbers[i] == numbers[j]){
                    count++;
                }
                if (count > maxCount){
                    maxCount = count;
                    maxNumber = numbers[i];
                }
            }
            count = 0;
        }
        System.out.println(maxNumber);
    }
}
