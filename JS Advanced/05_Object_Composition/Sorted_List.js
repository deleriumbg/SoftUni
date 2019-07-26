function sortedList() {
    let listObj = (() => {
        let arr = [];
        let sortOrder = (a, b) => a - b;

        let add = function (element) {
            arr.push(element);
            arr.sort(sortOrder);
            this.size++;
            return arr;
        };

        let remove = function (index) {
            if(index >= 0 && index < arr.length) {
                arr.splice(index, 1);
                arr.sort(sortOrder);
                this.size--;
                return arr;
            }
        };

        let get = function (index) {
            if(index >= 0 && index< arr.length){
                return arr[index];
            }
        };

        let size = 0;
        return {add, remove, get, size}
    })();

    return listObj;
}