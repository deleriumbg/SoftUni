function solve() {
    class Melon {
        constructor(weight, melonSort) {
            if (new.target === Melon) {
                throw new TypeError("Abstract class cannot be instantiated directly");
            }

            this.weight = weight;
            this.melonSort = melonSort;
        }

        toString() {
            let element = this.constructor.name
                .split('melon')
                .filter(e => e !== '')[0];
            if (this.constructor.name === 'Melolemonmelon') {
                element = 'Water';
            }
            return `Element: ${element}\nSort: ${this.melonSort}\n`
        }
    }

    class Watermelon extends Melon {
        constructor(weight, melonSort) {
            super(weight, melonSort);
        }

        get elementIndex() {
            return this.weight * this.melonSort.length;
        }

        toString() {
            return super.toString() + `Element Index: ${this.elementIndex}`;
        }
    }

    class Firemelon extends Melon {
        constructor(weight, melonSort) {
            super(weight, melonSort);
        }

        get elementIndex() {
            return this.weight * this.melonSort.length;
        }

        toString() {
            return super.toString() + `Element Index: ${this.elementIndex}`;
        }
    }

    class Earthmelon extends Melon{
        constructor(weight, melonSort) {
            super(weight, melonSort);
        }

        get elementIndex() {
            return this.weight * this.melonSort.length;
        }

        toString() {
            return super.toString() + `Element Index: ${this.elementIndex}`;
        }
    }

    class Airmelon extends Melon {
        constructor(weight, melonSort) {
            super(weight, melonSort);
        }

        get elementIndex() {
            return this.weight * this.melonSort.length;
        }

        toString() {
            return super.toString() + `Element Index: ${this.elementIndex}`;
        }
    }

    class Melolemonmelon extends Watermelon {
        constructor(weight, melonSort) {
            super(weight, melonSort);
            this.counter = 0;
            this.elements = [Watermelon, Firemelon, Earthmelon, Airmelon];
        }

        morph() {
            this.counter++;
            return this;
        }

        toString() {
            return new this.elements[this.counter % 4](this.weight, this.melonSort).toString()
        }
    }

    return {
        Melon,
        Watermelon,
        Firemelon,
        Earthmelon,
        Airmelon,
        Melolemonmelon
    }
}