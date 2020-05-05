import java.util.Scanner;

public class Fit_String_in_20_Chars {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String input = scanner.nextLine();
        char[] arr = input.toCharArray();
        if (input.length() >= 20){
            for (int i = 0; i < 20; i++) {
                System.out.print(arr[i]);
            }
        }else{
            System.out.print(input);
            for (int i = input.length(); i < 20; i++) {
                System.out.print("*");
            }
        }
    }
}
