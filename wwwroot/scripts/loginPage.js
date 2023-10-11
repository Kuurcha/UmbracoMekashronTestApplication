



const alertTrigger = document.getElementById('loginBtn')
if (alertTrigger) {
    alertTrigger.addEventListener('click', () => {

        $.ajax({
            url: '/umbraco/api/login/getlogin', // URL to your controller action
            type: 'GET',
            dataType: 'text',
            success: function (data) {
                // Handle the data returned from the controller action
                console.log(data);
            },
            error: function (error) {
                // Handle errors, if any
                console.error(JSON.stringify(error));
            }
        });
    });
}
    /*        console.log("button click!");
const alertPlaceholder = document.getElementById('loginAlertPlaceholder')
alertPlaceholder.innerHTML = ""
const appendAlert = (message, type) => {
const wrapper = document.createElement('div')
wrapper.innerHTML = [
`<div class="alert alert-${type} alert-dismissible align-self-center" role="alert">`,
`   <button type="button" class="btn-close" data-bs-dismiss="alert"></button>`,
`   <div>${message}</div>`,
'</div>'
].join('')
 
alertPlaceholder.append(wrapper)
}
appendAlert('Nice, you triggered this alert message!', 'success')*/


/*<div class="alert alert-success alert-dismissible w-50 align-self-center">
    <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
    <strong>Success!</strong> This alert box could indicate a successful or positive action.
</div>
                        */