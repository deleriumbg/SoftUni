var HttpRequest = /** @class */ (function () {
    function HttpRequest(method, uri, version, message) {
        this.method = method;
        this.uri = uri;
        this.version = version;
        this.message = message;
        this.response = undefined;
        this.fulfilled = false;
    }
    return HttpRequest;
}());
var request = new HttpRequest('GET', 'http://google.com', 'HTTP/1.1', '');
console.log(request);
