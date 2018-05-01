import java.util.Scanner;
import java.util.TreeMap;

public class Sums_by_Town {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        TreeMap<String, Double> towns = new TreeMap<>();
        int n = Integer.parseInt(scanner.nextLine());
        for (int i = 0; i < n; i++) {
            String[] townInfo = scanner.nextLine().split("\\s+\\|");
            String town = townInfo[0];
            Double income = Double.parseDouble(townInfo[1]);
            if (!towns.containsKey(town)){
                towns.put(town, income);
            }else{
                towns.put(town, towns.get(town) + income);
            }
        }
        for (String key : towns.keySet()) {
            System.out.println(key + " -> " + towns.get(key));
        }
    }
}
