package Book_Library_Modification;

import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.Comparator;
import java.util.Scanner;

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
        LocalDate startDate = LocalDate.parse(scanner.nextLine(), DateTimeFormatter.ofPattern("dd.MM.yyyy"));
        Book[] sortedBooks = library.getBookList()
                .stream()
                .filter(a -> a.getReleaseDate().isAfter(startDate))
                .sorted(Comparator.comparing(Book::getReleaseDate).thenComparing(Book::getTitle)).toArray(Book[]::new);

        DateTimeFormatter df = DateTimeFormatter.ofPattern("dd.MM.yyyy");
        for (Book book : sortedBooks){
            System.out.printf("%s -> %s%n", book.getTitle(), df.format(book.getReleaseDate()));
        }
    }
}
