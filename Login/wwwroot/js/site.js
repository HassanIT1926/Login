// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

function ValidateSubmit() {
    
    var x =NameCheck();
    var y =emailcheck();
    var z = passwordcheck();
    if (x && y && z) {
        return true;
    }
    else {
        return false;
    }
}


function NameCheck() {
    var flag1 = false;
    var str = document.getElementById('UserName').value;
    var letter = /^[a-zA-Z]+$/.test(str);
    console.log(str);
    if ((letter)) {
        flag1 = true;
        return flag1;
    }

    else {
        document.getElementById("Error1").innerHTML = "Please enter alphabets only";
        return flag1;

    }
}
function emailcheck() {
    var flag2 = false;
    var email = document.getElementById('Email').value;
    var correctEmail = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/.test(email);
    console.log(email);
    if ((correctEmail)) {
        flag2 = true;
        return flag2;
    }
    else {
        document.getElementById("Error2").innerHTML = "Invalid Email";
        return flag2;
    }
}

function passwordcheck() {
    var flag3 = false;
    var pwd = document.getElementById('UserPassword').value;
    if (pwd.match(/[a-z]/g) && pwd.match(
        /[A-Z]/g) && pwd.match(
            /[0-9]/g) && pwd.match(
                /[^a-zA-Z\d]/g) && pwd.length > 7) {
        flag3 = true;
        return flag3;

    }

    else {
        document.getElementById("Error3").innerHTML = "Password should have upper, lower, num, special and greater than 7.";
        return flag3;
    }
}



// Write your JavaScript code.
