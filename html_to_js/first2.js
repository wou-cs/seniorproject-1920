console.log("Javascript is being executed.....");

//var h1 = document.getElementById('heading');
//var h1 = $('#heading');
//console.log(h1);

function login(event){
    event.preventDefault();

    var username = $('#username').val();
    var password = $('#password').val();

    $('body').append("<p class='secret'>You re logged in!" + username + " and " + password + "</p>");

    console.log("You're logged in!" + username + " and " + password);
}

$('#loginForm').submit(login);

