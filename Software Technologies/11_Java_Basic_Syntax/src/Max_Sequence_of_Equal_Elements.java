import java.util.Arrays;
import java.util.Scanner;

public class Max_Sequence_of_Equal_Elements {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int[] numbers = Arrays.stream(scanner.nextLine().split(" ")).mapToInt(Integer::parseInt).toArray();
        int count = 1;
        int maxCount = 0;
        int maxNumber = numbers[0];
        for (int i = 0; i < numbers.length - 1; i++) {
            if (numbers[i] == numbers[i + 1]){
                count++;
                if (maxCount < count){
                    maxCount = count;
                    maxNumber = numbers[i];
                }
            }else{
                count = 1;
            }
        }
        for (int i = 0; i < maxCount; i++) {
            System.out.printf("%d ", maxNumber);
        }
    }
}
