function checkIsUserAuth() {
    const checkIsUserAuthUrl = `${window.location.origin}/Account/IsLoggedIn`;

    fetch(checkIsUserAuthUrl)
        .then(function (response) {
            return response.json();
        }).then(function (result) {
            return result;
        }).catch(function () {
            console.error('smth goes wrong');
        });
}

function generateUserManagementPreview(navbar) {
    let userData = getUserData();

    navbar.innerHTML = `<li class="nav-item">
        <a class="nav-link text-dark" href="#">Hello ${userData.Email}</a>
    </li>
    <li class="nav-item">
        <a class="nav-link text-dark" href="/account/logout" >Logout</a>
    </li>`
}

function generateLoginPanel(navbar) {
}

function getUserData() {
    const checkIsUserAuthUrl = `${window.location.origin}/Account/GetUserData`;

    fetch(checkIsUserAuthUrl)
        .then(function (response) {
            return response.json();
        }).then(function (result) {
            return result;
        }).catch(function () {
            console.error('smth goes wrong');
        });
}

let isUserLoggedIn = checkIsUserAuth();
let navbar = document.getElementById('login-nav');

if (isUserLoggedIn) {
    generateUserManagementPreview(navbar);
}
else {
    generateLoginPanel(navbar);
}