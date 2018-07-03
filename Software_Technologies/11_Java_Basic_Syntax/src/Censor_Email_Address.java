import java.util.Scanner;

public class Censor_Email_Address {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[] email = scanner.nextLine().split("@");
        String emailStr = email[0] + "@" + email[1];
        String username = email[0];
        String domain = email[1];
        String text = scanner.nextLine();
        String censored = newString('*', username.length()) + "@" + domain;
        String replaceString = text.replace(emailStr,censored);
        System.out.println(replaceString);
    }
    public static String newString(char ch, int size) {
        return new String(new char[size]).replace('\0', ch);
    }
}
