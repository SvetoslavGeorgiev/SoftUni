function addItem() {
    let newElementText = document.getElementById('newItemText');
    let newElementValue = document.getElementById('newItemValue');

    let optionElement = document.createElement('option');
    optionElement.textContent = newElementText.value;
    optionElement.value = newElementValue.value;

    let selectElement = document.getElementById('menu');
    selectElement.appendChild(optionElement);

    newElementText.value = '';
    newElementValue.value = '';
}