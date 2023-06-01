function lockedProfile() {
    let btns = document.getElementsByTagName('button');

    let onClick = function (e) {
        let button = e.currentTarget;
        let unlockElement = e.currentTarget.parentNode.querySelectorAll('input[value=unlock]')[0];
        let hiddenElement = e.currentTarget.parentNode.getElementsByTagName('div')[0];

        if (unlockElement.checked && button.textContent == 'Show more') {
            hiddenElement.style.display = 'block'
            button.textContent = 'Hide it';
        }else if (unlockElement.checked && button.textContent == 'Hide it') {
            hiddenElement.style.display = 'none'
            button.textContent = 'Show more';
        }

    }

    for (const btn of btns) {
        btn.addEventListener('click', onClick)
    }
}