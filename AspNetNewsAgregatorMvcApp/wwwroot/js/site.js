let a = {};

a.A = 1;
a.B = "abc";
a.x = '1111';

let z = 15 + a.A;

let userName = 'Vasily Puplun';


//showHelloMessage(userName);


let printMessage = function (message) {
    console.log(message);
} 


function showHelloMessage(user, value, value2) {

    let message = `Hello, ${user}`;

    let a = alert(message);
    console.log('a:', a);

    let b = prompt(message);
    console.log('b:', b);

    let c = confirm(message);
    console.log('c:', c);

    let x = sum(1, 2);
    console.log(x);

    doSmth(alert);

    //printMessage('Hello');
}

function sum(a, b) {
    return a + b;
}

function doSmth(sum) {
    sum();
}
//alert(message);