class List{
    constructor(){
        this.innerList = [];
        this.size = 0;
    }

    add(number){
        this.innerList.push(number);
        this.innerList.sort((a, b) => a - b);
        this.size++;
        return this.innerList;
    }

    remove(index){
        if (index < 0 || index >= this.innerList.length) {
            throw new Error('Invalid index');
        }
        this.innerList.splice(index, 1);
        this.innerList.sort((a, b) => a - b);
        this.size--;
        return this.innerList;
    }

    get(index){
        if (index < 0 || index >= this.innerList.length) {
            throw new Error('Invalid index');
        }
        return this.innerList[index];
    }
}