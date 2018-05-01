import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Change_to_Uppercase {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String text = scanner.nextLine();
        String pattern = "<upcase>(.*?)<\\/upcase>";
        Pattern p = Pattern.compile(pattern);
        Matcher match = p.matcher(text);
        for (int i = 0; i < text.length(); i++) {
            if (match.find()){
                text = text.replace(match.group(), match.group(1).toUpperCase());
             }
        }
        System.out.println(text);
    }
}

