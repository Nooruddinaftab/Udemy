var myName = "john";
var aNumber = 5;
var bNumber = 5;
var xNumber = 5;
bNumber = bNumber + 1;
bNumber = 5 + 1;
//bNumber = 6; // will not work bNumber is of type 5.
var aStringOrNumber = "str";
aStringOrNumber = 4;
console.log(aStringOrNumber);
aStringOrNumber = "name";
var gift;
gift = 0.001 + 1;
console.log(gift);
console.log(bNumber);
console.log(aStringOrNumber);
function testVarLet(checkvar) {
    if (checkvar) {
        var x = "abc", y = 123;
        console.log(x);
        console.log(y);
    }
    else {
        var scoped = 1;
        var xlet = 123;
        var ylet = "abc";
        console.log(xlet);
        console.log(scoped);
    }
    //console.log(ylet);
    // console.log(scoped);
}
testVarLet(true);
testVarLet(false);
