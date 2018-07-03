package Average_Grades;

import java.util.ArrayList;

public class Student {
    private String name;
    private ArrayList<Double> grades = new ArrayList<>();
    private Double average;

    public Student(String name, ArrayList<Double> grades) {
        this.name = name;
        this.grades = grades;

        Double total = 0.0;
        for(Double grade : grades){
            total += grade;
        }
        this.average = total / grades.size();
    }

    public Student() {
    }

    public String getName() {
        return name;
    }

    public ArrayList<Double> getGrades() {
        return grades;
    }

    public Double getAverage() {
        return average;
    }

    public void setName(String name) {
        this.name = name;
    }

    public void setGrades(ArrayList<Double> grades) {
        this.grades = grades;
    }
}
