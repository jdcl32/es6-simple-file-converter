function test(){
    var method1 = function(){}
    var method2=function(arg1, arg2){}
    var method3= function (arg1, arg2) {}
}

test.prototype.method = function(){
    return "invoked";
}