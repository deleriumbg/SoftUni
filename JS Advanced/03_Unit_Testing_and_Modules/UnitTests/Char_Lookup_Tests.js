const expect = require('chai').expect;
let lookupChar = require('../Char_Lookup');

describe('lookupChar', function(){
    it('should return undefined with a non-string first parameter', function () {
        expect(lookupChar(3, 0)).to.equal(undefined);
    });

    it('should return undefined for type different form string',function () {
        expect(lookupChar({}, 0)).to.equal(undefined);
    });

    it('should return undefined with a non-number second parameter', function () {
        expect(lookupChar('Pesho', 'Gosho')).to.equal(undefined);
    });

    it('should return undefined with a floating-point number as a second parameter', function () {
        expect(lookupChar('test', 2.2)).to.equal(undefined);
    });

    it('should return incorrect index with an incorrect index value', function () {
        expect(lookupChar('test', 12)).to.equal('Incorrect index');
    });

    it('should return incorrect index with a negative index value', function () {
        expect(lookupChar('test', -2)).to.equal('Incorrect index');
    });

    it('should return incorrect index with an index value equal to the string length', function () {
        expect(lookupChar('test', 4)).to.equal('Incorrect index');
    });

    it('should return correct value with correct input parameters', function () {
        expect(lookupChar('test', 0)).to.equal('t');
    });

    it('should return o for string Pesho and index 4',function () {
        expect(lookupChar('Pesho', 4)).to.equal('o');
    });

    it('should return undefined for no string and no number',function () {
        expect(lookupChar(1, 'Pesho')).to.equal(undefined);
    });
});