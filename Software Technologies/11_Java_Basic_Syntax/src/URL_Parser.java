import java.util.Scanner;

public class URL_Parser {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String url = scanner.nextLine();
        if (url.contains("://")){
            String[] protocol = url.split("://");
            System.out.println("[protocol] = "+"\""+protocol[0]+"\"");
            if (!protocol[1].equals("")){
                String[] server = protocol[1].split("/+?");
                System.out.println("[server] = "+"\""+server[0]+"\"");
                if (server.length != 1){
                    String[] resource = protocol[1].split("^([^\\/]+)\\/");
                    System.out.println("[resource] = "+"\""+resource[1]+"\"");
                }
                else {
                    System.out.println("[resource] = \"\"");
                }
            }
        }
        else {
            System.out.println("[protocol] = \"\"");
            if (url.contains("/")){
                String[] server = url.split("/+?");
                System.out.println("[server] = "+"\""+server[0]+"\"");
                if (server.length != 1){
                    String[] resource = url.split("^([^\\/]+)\\/");
                    System.out.println("[resource] = "+"\""+resource[1]+"\"");
                }
            }
            else {
                System.out.println("[server] = "+"\""+url+"\"");
                System.out.println("[resource] = \"\"");
            }
        }
    }
}
