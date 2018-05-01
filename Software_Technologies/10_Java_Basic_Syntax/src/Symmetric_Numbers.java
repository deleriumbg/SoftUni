import java.util.Scanner;

public class Symmetric_Numbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = scanner.nextInt();
        for (int i = 1; i <= n; i++) {
            if (IsPalindrome(Integer.toString(i))){
                System.out.println(i);
            }
        }
    }

    public static boolean IsPalindrome(String str)
    {
        for (int i = 0; i < str.length() / 2; i++) {
            if (str.charAt(i) != str.charAt(str.length() - 1 - i)) {
                return false;
            }
        }
        return true;
    }
}
