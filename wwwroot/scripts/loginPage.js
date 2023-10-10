const alertTrigger = document.getElementById('loginBtn')
if (alertTrigger) {
    alertTrigger.addEventListener('click', () => {
        console.log("button click!");
        const alertPlaceholder = document.getElementById('loginAlertPlaceholder')
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
        appendAlert('Nice, you triggered this alert message!', 'success')
    })
}

/*<div class="alert alert-success alert-dismissible w-50 align-self-center">
    <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
    <strong>Success!</strong> This alert box could indicate a successful or positive action.
</div>
                        */