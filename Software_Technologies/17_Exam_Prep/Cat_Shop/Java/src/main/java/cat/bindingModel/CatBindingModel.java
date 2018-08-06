package cat.bindingModel;

public class CatBindingModel {

    private String name;

    private String nickname;

    private Double price;

    public CatBindingModel() {
    }

    public CatBindingModel(String name, String nickname, Double price) {
        this.name = name;
        this.nickname = nickname;
        this.price = price;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getNickname() {
        return nickname;
    }

    public void setNickname(String nickname) {
        this.nickname = nickname;
    }

    public Double getPrice() {
        return price;
    }

    public void setPrice(Double price) {
        this.price = price;
    }
}
