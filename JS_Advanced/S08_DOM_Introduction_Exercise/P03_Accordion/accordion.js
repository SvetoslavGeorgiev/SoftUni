function toggle() {


    let button = document.querySelector('.button');
    let text = document.getElementById('extra');

    if (button.textContent === 'More') {

        button.textContent = 'Less';

        text.style.display = "block"

    } else {
        button.textContent = 'More';
        text.style.display = "none"
    }

}