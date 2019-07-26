class Stringer {
    constructor(string, initialLength){
        this.innerString = string;
        this.innerLength = +initialLength;
    }

    increase(length){
        return this.innerLength += length;
    }

    decrease(length){
        if (this.innerLength - length < 0) {
            return this.innerLength = 0;
        }
        return this.innerLength -= length;
    }

    toString(){
        if (this.innerString.length <= this.innerLength) {
            return this.innerString;
        }
        return this.innerString.substring(0, this.innerLength) + '...';
    }
}