import java.util.Scanner;
import java.util.TreeMap;

public class Phonebook_Upgrade {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String input = scanner.nextLine();
        TreeMap<String, String> phonebook = new TreeMap<>();
        while(!input.equals("END")){
            String[] commands = input.split(" ");
            switch(commands[0]){
                case "A":
                    String name = commands[1];
                    String number = commands[2];
                    phonebook.put(name, number);
                    break;
                case "S":
                    String contact = commands[1];
                    if (!phonebook.containsKey(contact)){
                        System.out.printf("Contact %s does not exist.%n", contact);
                    }else{
                        System.out.printf("%s -> %s%n",contact, phonebook.get(contact));
                    }
                    break;
                case "ListAll":
                    for (String key : phonebook.keySet()) {
                        System.out.printf("%s -> %s%n", key, phonebook.get(key));
                    }
                    break;
            }
            input = scanner.nextLine();
        }
    }
}
