function validate() {

    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

    let change = function (e) {

        if (!emailRegex.test(e.target.value)) {
            e.target.className = 'error';
        }
        else{
            //e.target.removeAttribute('class');
            e.target.className = '';
        }
    }

    let input = document.getElementById('email').addEventListener('change', change);
}