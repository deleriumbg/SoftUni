package Book_Library;

import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.Scanner;
import java.util.TreeMap;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int n = scanner.nextInt();
        scanner.nextLine();

        ArrayList<Book> books = new ArrayList<>();
        Library library = new Library();
        for (int i = 0; i < n; i++) {
            String[] input = scanner.nextLine().split(" ");
            Book book = new Book();
            book.setTitle(input[0]);
            book.setAuthor(input[1]);
            book.setPublisher(input[2]);
            book.setReleaseDate(LocalDate.parse(input[3], DateTimeFormatter.ofPattern("dd.MM.yyyy")));
            book.setIsbn(input[4]);
            book.setPrice(Double.parseDouble(input[5]));
            books.add(book);
        }
        library.setName("My Library");
        library.setBookList(books);
        TreeMap<String, Double> authorPrice = new TreeMap<>();
        for (Book book : library.getBookList()) {
            if (!authorPrice.containsKey(book.getAuthor()))
            {
                authorPrice.put(book.getAuthor(), book.getPrice());
            }
            else
            {
                double oldValue = authorPrice.get(book.getAuthor());
                authorPrice.put(book.getAuthor(), oldValue + book.getPrice());
            }
        }
        authorPrice.entrySet().stream().sorted((e1, e2) -> {
            int compareResult = Double.compare(e2.getValue(), e1.getValue());
            if (compareResult == 0){
                compareResult = e1.getKey().compareTo(e2.getKey());
            }
            return compareResult;
        }).forEach(e-> System.out.printf("%s -> %.2f%n", e.getKey(), e.getValue()));
    }
}
