package Intersection_of_Circles;

import java.util.Arrays;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int[] first = Arrays.stream(scanner.nextLine().split(" ")).mapToInt(Integer::parseInt).toArray();
        int[] second = Arrays.stream(scanner.nextLine().split(" ")).mapToInt(Integer::parseInt).toArray();
        Point firstPoint = new Point(first[0], first[1]);
        Point secondPoint = new Point(second[0], second[1]);
        Circle firstCircle = new Circle(firstPoint, first[2]);
        Circle secondCircle = new Circle(secondPoint, second[2]);
        boolean intersect = Intersects(firstCircle, secondCircle);
        System.out.println(intersect ? "Yes" : "No");
    }

    public static Boolean Intersects (Circle c1, Circle c2)
    {
        double distance = Math.sqrt(Math.pow(c1.getCenter().getX() - c2.getCenter().getX(),2) +
                Math.pow(c1.getCenter().getY() - c2.getCenter().getY(),2));
        if(distance <= c1.getRadius() + c2.getRadius()){
            return true;
        }
        return false;
    }
}
