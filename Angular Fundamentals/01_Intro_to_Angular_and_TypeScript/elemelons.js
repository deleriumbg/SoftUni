var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var Melon = /** @class */ (function () {
    function Melon(weight, melonSort) {
        this.weight = weight;
        this.melonSort = melonSort;
    }
    return Melon;
}());
var Watermelon = /** @class */ (function (_super) {
    __extends(Watermelon, _super);
    function Watermelon(weight, melonSort) {
        var _this = _super.call(this, weight, melonSort) || this;
        _this.elementIndex = weight * melonSort.length;
        return _this;
    }
    Watermelon.prototype.toString = function () {
        return "Element: Water\nSort: " + this.melonSort + "\nElement Index: " + this.elementIndex;
    };
    return Watermelon;
}(Melon));
var Firemelon = /** @class */ (function (_super) {
    __extends(Firemelon, _super);
    function Firemelon(weight, melonSort) {
        var _this = _super.call(this, weight, melonSort) || this;
        _this.elementIndex = weight * melonSort.length;
        return _this;
    }
    Firemelon.prototype.toString = function () {
        return "Element: Fire\nSort: " + this.melonSort + "\nElement Index: " + this.elementIndex;
    };
    return Firemelon;
}(Melon));
var Earthmelon = /** @class */ (function (_super) {
    __extends(Earthmelon, _super);
    function Earthmelon(weight, melonSort) {
        var _this = _super.call(this, weight, melonSort) || this;
        _this.elementIndex = weight * melonSort.length;
        return _this;
    }
    Earthmelon.prototype.toString = function () {
        return "Element: Earth\nSort: " + this.melonSort + "\nElement Index: " + this.elementIndex;
    };
    return Earthmelon;
}(Melon));
var Airmelon = /** @class */ (function (_super) {
    __extends(Airmelon, _super);
    function Airmelon(weight, melonSort) {
        var _this = _super.call(this, weight, melonSort) || this;
        _this.elementIndex = weight * melonSort.length;
        return _this;
    }
    Airmelon.prototype.toString = function () {
        return "Element: Air\nSort: " + this.melonSort + "\nElement Index: " + this.elementIndex;
    };
    return Airmelon;
}(Melon));
var Melolemonmelon = /** @class */ (function (_super) {
    __extends(Melolemonmelon, _super);
    function Melolemonmelon(weight, melonSort) {
        var _this = _super.call(this, weight, melonSort) || this;
        _this.element = ['Water', 'Fire', 'Earth', 'Air'];
        return _this;
    }
    Melolemonmelon.prototype.morph = function () {
        var currentElement = this.element.shift();
        this.element.push(currentElement);
        return this;
    };
    Melolemonmelon.prototype.toString = function () {
        return "Element: " + this.element[0] + "\nSort: " + this.melonSort + "\nElement Index: " + this.elementIndex;
    };
    return Melolemonmelon;
}(Watermelon));
var watermelon = new Watermelon(12.5, "Kingsize");
console.log(watermelon.toString());
