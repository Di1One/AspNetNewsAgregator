function init() {
    const name = 'Vasiy Pip';  // local var created by init

    function displayName() { // inner func CLOSURE
        console.log(name); // use variable declared in parent func
    }

    return displayName();
}

const myFunc = init();
myFunc();  // have a link to name variable

console.log(name);