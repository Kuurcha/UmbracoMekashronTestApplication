

function createAlert(message, type) {

    const alertPlaceholder = document.getElementById('loginAlertPlaceholder')
    alertPlaceholder.innerHTML = ""

    const appendAlert = (message, type) => {
        const wrapper = document.createElement('div')
        wrapper.innerHTML = [
            `<div class="alert alert-${type} alert-dismissible align-self-center" role="alert" style="white-space: pre-line;" >`,
            `   <button type="button" class="btn-close" data-bs-dismiss="alert"></button>`,
            `   <div>${message}</div>`,
            '</div>'
        ].join('')

        alertPlaceholder.append(wrapper)
    }
    appendAlert(message, type)
}

function formSuccesfullMessage(loginDetails) {
    let response = "You have successfully logged in!\n"
    if (loginDetails.firstName) {
        response += "Welcome, " + loginDetails.firstName + " " + (loginDetails.lastName ?? "") + "\n";
    }
    if (loginDetails.city || loginDetails.country || loginDetails.zip) {
        reponse += "Your location details are: \n" + loginDetails.city ? "City: + " + loginDetails.city + "\n " : "" + loginDetails.country ? "Country: " + loginDetails.country + "\n" : "" + loginDetails.zip ? "zip code: " + loginDetails.zip + "\n" : ""
    }
    response += loginDetails.company ? "Working at " + loginDetails.company + "\n" : "";
    if (loginDetails.mobile) {
        response += "Your mobile number is " + loginDetails.mobile + "\n";
        response += loginDetails.mobileConfirm == 0 ? "You have not confirmed your mobile number" + "\n" : "You have confirmed your mobile number" + "\n";
    }
    if (loginDetails.email) {
        response += "Your email is: " + loginDetails.email + "\n";
        response += loginDetails.emailConfirm == 0 ? "You have not confirmed your email" + "\n" : "You have confirmed your email" + "\n";
    }
    response += loginDetails.status ? "Your status: " + loginDetails.status + "\n" : "";
    return response;
}

//test account credentials
//MultilimbedMonster
//VictoriaDallon@parahumans.web

const alertTrigger = document.getElementById('loginBtn')
if (alertTrigger) {
    alertTrigger.addEventListener('click', () => {

        let emailForm = $('#exampleInputEmail1').val();
        let passwordForm = $('#exampleInputPassword1').val();
        if (emailForm)
            emailForm = emailForm.substring(0, 256);
        if (passwordForm)
            passwordForm = passwordForm.substring(0, 256);
        let data = {
            email: emailForm,
            password: passwordForm
        };

        // Send POST request using AJAX
        $.ajax({
            type: "POST",
            url: "/umbraco/api/login/postLogin", // Replace with your API endpoint URL
            data: JSON.stringify(data), // Convert data to JSON string
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                createAlert(formSuccesfullMessage(response), 'primary');
                // Handle the successful response here
            },
            error: function (error) {
                const errorResponse = JSON.parse(error.responseText);
                createAlert("An error occured:  " + errorResponse.resultMessage, 'danger');
                // Handle errors here
            }
        });
    });
}