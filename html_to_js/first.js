$('body').append($('<p>This is some dynamically added content</p>'))

/*
    The submit button was not working in-class because I was trying to
    add the callback to the button.  Submitting a form is an action on the form
    not the button, so the callback should be added to the form itself, not the button.
    You then need a button or input inside the form that has type submit, to trigger
    the submit call.

    You could alternately NOT put your input elements in a form and use a regular
    button.  Then add the callback to the button like I was trying to do.  Then it wouldn't
    be the submit action but just click.  

    To summarize, submit is for forms and click is for buttons.  We do want to start using
    forms now because that's what we'll use extensively later.
*/

//$('#myButton').click(function(){alert("Clicked!");});

$('#addNumbersForm').on("submit",function(event){
    // prevent the form from sending request to the web server
    event.preventDefault();
    // Extract values from our input elements
    var a = parseFloat($('#numberA').val());
    var b = parseFloat($('#numberB').val());
    // Compute result and write into the output
    var c = a + b;
    $('#result').val(`Adding ${a} and ${b} results in ${c}`);
    // The string above uses template literals.  The $ is not jQuery there.  
    // Note the backticks rather than quotes
});

 