//(() => {
//    'use strict'

//    // Fetch all the forms we want to apply custom Bootstrap validation styles to
//    const forms = document.querySelectorAll('.needs-validation')

//    // Loop over them and prevent submission
//    Array.from(forms).forEach(form => {
//        form.addEventListener('submit', event => {
//            if (!form.checkValidity()) {
//                event.preventDefault()
//                event.stopPropagation()
//            }

//            form.classList.add('was-validated')
//        }, false)
//    })
//})()
(() => {
    'use strict';

    const forms = document.querySelectorAll('.needs-validation');
    const passwordMismatchAlert = document.getElementById('passwordMismatchAlert');

    Array.from(forms).forEach(form => {
        form.addEventListener('submit', event => {
            const password = form.querySelector('#inputPassword').value;
            const repeatPassword = form.querySelector('#inputPasswordRepit').value;

            if (!form.checkValidity() || password !== repeatPassword) {
                event.preventDefault();
                event.stopPropagation();

                passwordMismatchAlert.classList.remove('d-none');
            } else {
                passwordMismatchAlert.classList.add('d-none');
                form.classList.add('was-validated');
            }

        }, false);
    });
})();