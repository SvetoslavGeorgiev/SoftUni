function addItem() {

    let ulElement = document.getElementById('items');
    let text = document.getElementById('newItemText').value;
    let liElement = document.createElement('li');
    liElement.textContent = text;
    ulElement.appendChild(liElement);
}