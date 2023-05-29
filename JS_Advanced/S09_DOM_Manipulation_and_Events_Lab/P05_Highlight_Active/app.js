function focused() {
    let allDivs = document.querySelectorAll('div div');



    let focus = function (e) {
        e.currentTarget.parentNode.classList.add('focused');
    }

    let blur = function (e) {
        e.currentTarget.parentNode.classList.remove('focused');
    }


    for (const div of allDivs) {
        div.querySelector('input').addEventListener('focus', focus);
        div.querySelector('input').addEventListener('blur', blur);
    }
}