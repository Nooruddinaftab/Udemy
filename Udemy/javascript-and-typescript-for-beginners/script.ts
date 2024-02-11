let myName = "john";
const aNumber = 5;
let bNumber: 5 = 5;

const xNumber = 5;
bNumber = bNumber + 1;
bNumber = 5 + 1;
//bNumber = 6; // will not work bNumber is of type 5.
let aStringOrNumber: string | number = "str";
aStringOrNumber = 4;
console.log(aStringOrNumber);

aStringOrNumber = "name";

let gift: undefined | number | Float64Array;
gift = 0.001 + 1;
console.log(gift);

console.log(bNumber);
console.log(aStringOrNumber);
