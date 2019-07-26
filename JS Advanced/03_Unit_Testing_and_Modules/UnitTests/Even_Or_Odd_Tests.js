const expect = require('chai').expect;
let isOddOrEven = require('../Even_Or_Odd');

describe('isOddOrEven', function(){
    it('should return undefined with a parameter number', function () {
        expect(isOddOrEven(3)).to.equal(undefined)
    });

    it('should return undefined with an object parameter', function () {
        expect(isOddOrEven({name: 'Pesho'})).to.equal(undefined)
    });

    it('should return correct result with an even length', function () {
        expect(isOddOrEven('test')).to.equal('even')
    });

    it('should return correct result with an odd length', function () {
        expect(isOddOrEven('tes')).to.equal('odd')
    });
});
