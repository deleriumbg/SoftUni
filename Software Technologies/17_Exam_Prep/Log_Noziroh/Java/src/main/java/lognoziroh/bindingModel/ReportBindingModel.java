package lognoziroh.bindingModel;

public class ReportBindingModel {
    private String status;

    private String message;

    private String origin;

    public ReportBindingModel() {
    }

    public ReportBindingModel(String status, String message, String origin) {
        this.status = status;
        this.message = message;
        this.origin = origin;
    }

    public String getStatus() {
        return status;
    }

    public void setStatus(String status) {
        this.status = status;
    }

    public String getMessage() {
        return message;
    }

    public void setMessage(String message) {
        this.message = message;
    }

    public String getOrigin() {
        return origin;
    }

    public void setOrigin(String origin) {
        this.origin = origin;
    }
}
