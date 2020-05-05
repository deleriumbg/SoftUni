package Average_Grades;

import java.util.*;

public class Main {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        ArrayList<Student> students = new ArrayList<>();

        int studentsCount = scanner.nextInt();
        scanner.nextLine();

        for (int i = 0; i < studentsCount; i++) {
            String[] input = scanner.nextLine().split(" ");
            String name = input[0];
            ArrayList<Double> grades = new ArrayList<>();
            for (int j = 1; j < input.length; j++) {
                grades.add(Double.parseDouble(input[j]));
            }
            students.add(new Student(name, grades));
        }

        students.stream()
                .filter(s -> s.getAverage() >= 5.00)
                .sorted((a, b) -> {
                    int result = a.getName().compareTo(b.getName());
                    if (result == 0) {
                        result = Double.compare(b.getAverage(), a.getAverage());
                    }
                    return result;
                })
                .forEach(s -> {
                    System.out.printf("%s -> %.2f%n", s.getName(), s.getAverage());
                });
    }
}

