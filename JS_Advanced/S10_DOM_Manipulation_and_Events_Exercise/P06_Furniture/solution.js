function solve() {
    let tableBodyElement = document.getElementsByTagName('tbody')[0];
    let buttonElements = document.getElementsByTagName('button');
    let textAreaElements = document.getElementsByTagName('textarea');
    let generateTextArea = textAreaElements[0];
    let buyTextArea = textAreaElements[1];
    let buyButton = buttonElements[1];
    let generateButton = buttonElements[0];

    buyButton.addEventListener('click', Buy);
    generateButton.addEventListener('click', Generate);

    function Generate() {



        let arrObjs = JSON.parse(generateTextArea.value);

        for (const obj of arrObjs) {

            let trElement = document.createElement('tr');

            let tdImgElement = document.createElement('td');
            let imgElement = document.createElement('img');
            let img = obj.img;
            imgElement.src = img;
            tdImgElement.appendChild(imgElement);
            trElement.appendChild(tdImgElement);

            let tdNameElement = document.createElement('td');
            let pNameElement = document.createElement('p');
            let name = obj.name;
            pNameElement.textContent = name;
            tdNameElement.appendChild(pNameElement);
            trElement.appendChild(tdNameElement);

            let tdPriceElement = document.createElement('td');
            let pPriceElement = document.createElement('p');
            let price = obj.price;
            pPriceElement.textContent = price;
            tdPriceElement.appendChild(pPriceElement);
            trElement.appendChild(tdPriceElement);

            let tdDecFactorElement = document.createElement('td');
            let pDecFactorElement = document.createElement('p');
            let decFactor = obj.decFactor;
            pDecFactorElement.textContent = decFactor;
            tdDecFactorElement.appendChild(pDecFactorElement);
            trElement.appendChild(tdDecFactorElement);

            let tdCheckBoxInputElement = document.createElement('td');
            let pCheckBoxInputElement = document.createElement('input');
            pCheckBoxInputElement.type = 'checkbox';
            tdCheckBoxInputElement.appendChild(pCheckBoxInputElement);
            trElement.appendChild(tdCheckBoxInputElement);

            tableBodyElement.appendChild(trElement);


        }
    }

    function Buy() {

        let bought = Array.from(document.querySelectorAll('input[type="checkbox"]:checked'))
            .map(b => b.parentNode.parentNode);

        let boughtItems = [];
        let totalPrice = 0;
        let totalDecFactor = 0;

        for (const item of bought) {
            let name = item.childNodes[1].textContent;
            let price = Number(item.childNodes[2].textContent);
            let decorationFactor = Number(item.childNodes[3].textContent);

            boughtItems.push(name);
            totalPrice += price;
            totalDecFactor += decorationFactor;
        }

        let averageDecFactor = totalDecFactor / boughtItems.length;
        let output = `Bought furniture: ${boughtItems.join(", ")}\nTotal price: ${totalPrice.toFixed(2)}\nAverage decoration factor: ${averageDecFactor}`;

        buyTextArea.value = output;

    }

}