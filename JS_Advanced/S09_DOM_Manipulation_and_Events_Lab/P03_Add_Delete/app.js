function addItem() {
    let ulElement = document.getElementById('items');
    let text = document.getElementById('newItemText');
    let liElement = document.createElement('li');
    let aElement = document.createElement('a');
    aElement.textContent = '[Delete]';
    aElement.href = '#';
    aElement.addEventListener('click', onClick, true)
    liElement.textContent = text.value;
    text.value = '';

    liElement.appendChild(aElement);
    ulElement.appendChild(liElement);

    function onClick(e) {
        e.currentTarget.parentNode.remove();
    }
}

