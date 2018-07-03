import java.util.Random;
import java.util.Scanner;

public class Advertisement_Message {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int messages = scanner.nextInt();

        String[] phrases = {"Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can't live without this product."};
        String[] events = {"Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!"};
        String[] authors = {"Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"};
        String[] cities = {"Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"};

        for (int i = 0; i < messages; i++) {
            String randomPhrase = phrases[new Random().nextInt(phrases.length)];
            String randomEvent = events[new Random().nextInt(events.length)];
            String randomAuthor = authors[new Random().nextInt(authors.length)];
            String randomCity = cities[new Random().nextInt(cities.length)];
            System.out.printf("%s %s %s %s%n", randomPhrase, randomEvent, randomAuthor, randomCity);
        }
    }
}
