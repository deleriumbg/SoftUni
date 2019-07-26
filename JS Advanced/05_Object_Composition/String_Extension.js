(function solve(){
    String.prototype.ensureStart = function(str){
        if (!this.toString().startsWith(str)) {
            return str + this.toString();
        }
        return this.toString();
    };

    String.prototype.ensureEnd = function(str){
        if (!this.toString().endsWith(str)) {
            return this.toString() + str;
        }
        return this.toString();
    };

    String.prototype.isEmpty = function(){
        return this.toString().length === 0;
        
    };

    String.prototype.truncate = function(n){
        if (this.toString().length <= n) {
            return this.toString();
        } else if(n < 4){
            return '.'.repeat(n);
        } else {
            let lastIndex = this.toString().substr(0, n - 2).lastIndexOf(" ");
            if(lastIndex !== -1){
                return this.toString().substr(0, lastIndex) + "...";
            } else {
                return this.toString().substr(0, n-3) + "...";
            }
        }
    };

    String.format = function (string, ...params) {
        for(let i = 0; i < params.length; i++){
            let index = string.indexOf("{"+i+"}");
            while (index != -1) {
                string = string.replace("{"+i+"}", params[i]);
                index = string.indexOf("{"+i+"}");
            }
        }
        return string;
    };
})();