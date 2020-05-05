import java.util.Arrays;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Collectors;

public class Bomb_Numbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        List<Integer> numbers = Arrays.stream(scanner.nextLine().split(" ")).map(Integer::parseInt).collect(Collectors.toList());
        int[] bombArr = Arrays.stream(scanner.nextLine().split(" ")).mapToInt(Integer::parseInt).toArray();
        int bombNumber = bombArr[0];
        int range = bombArr[1];
        while(numbers.contains(bombNumber)){
            int position = numbers.indexOf(bombNumber);
            int start = Math.max(position - range, 0);
            int end = Math.min(position + 1 + range, numbers.size());
            numbers.subList(start, end).clear();
        }
        int sum = numbers.stream().mapToInt(Integer::intValue).sum();
        System.out.println(sum);
    }
}
