function solve() {

    // let selectFromMenu = document.querySelectorAll('#selectMenuFrom option');

    // for (const op of selectFromMenu) {
    //     console.log(op.value);
    //     console.log(op.textContent);
    // }

    let selectToMenu = document.getElementById('selectMenuTo');

    let optionHexa = document.createElement('option');
    optionHexa.value = "hexadecimal";
    optionHexa.textContent = "Hexadecimal"
    let optionBinary = optionHexa.cloneNode();
    optionBinary.value = "binary";
    optionBinary.textContent = "Binary";

    selectToMenu.appendChild(optionBinary);
    selectToMenu.appendChild(optionHexa);

    document.querySelector('div button').addEventListener('click', onClick);

    let result = '';

    function onClick(){

        let calculateTo = selectToMenu.value;
        let input = Number(document.getElementById('input').value)

        if(calculateTo === 'hexadecimal'){

            result += (input >>> 0).toString(16).toUpperCase();

        }else if (calculateTo === 'binary') {

            result += (input >>> 0).toString(2);
        }else{
            result += 'Error'
        }

        let output = document.getElementById('result');

        output.value = result;

    }
}