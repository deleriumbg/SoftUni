import java.time.DayOfWeek;
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.Scanner;

public class Count_Working_Days {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String start = scanner.nextLine();
        String end = scanner.nextLine();
        LocalDate startDate = LocalDate.parse(start, DateTimeFormatter.ofPattern("dd-MM-yyyy"));
        LocalDate endDate = LocalDate.parse(end, DateTimeFormatter.ofPattern("dd-MM-yyyy"));
        int counter = 0;
        int[] holidayDays = {1, 3, 1, 6, 24, 6, 22, 1, 24, 25, 26};
        int[] holidayMonths = {1, 3, 5, 5, 5, 9, 9, 11, 12, 12, 12};
        for (LocalDate current = startDate; current.isBefore(endDate.plusDays(1)); current = current.plusDays(1)) {
            if (current.getDayOfWeek() == DayOfWeek.SATURDAY || current.getDayOfWeek() == DayOfWeek.SUNDAY ){
                continue;
            }
            Boolean isHoliday = false;
            for (int i = 0; i < holidayDays.length; i++) {
                if (current.getDayOfMonth() == holidayDays[i] && current.getMonthValue() == holidayMonths[i]){
                    isHoliday = true;
                    break;
                    }
                }
            if (isHoliday){
                continue;
            }else{
                counter++;
            }
        }
        System.out.println(counter);
    }
}
