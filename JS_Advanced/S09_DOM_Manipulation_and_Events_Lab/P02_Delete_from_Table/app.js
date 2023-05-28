function deleteByEmail() {
    let inputElement = document.querySelector('input[name="email"]');
    let emails = document.querySelectorAll('tr td:nth-child(2)');
    //let emails2 = document.querySelectorAll('tr td:nth-of-type(2)'); //returns the same as line 3;
    let resultElement = document.getElementById('result');

    let emailsArr = Array.from(emails);
    let targetElement = emailsArr.find(x => x.textContent == inputElement.value)

    inputElement.value = '';

    if (targetElement) {
        targetElement.parentNode.remove();
        resultElement.textContent = 'Deleted.'
    }else{
        resultElement.textContent = 'Not found.'
    }
}