function attachEventsListeners() {
    let [inputElement, outputElement] = document.querySelectorAll('input[type="text"]');
    let buttonConvertElement = document.getElementById('convert');

    let inputUnitsElement = document.getElementById('inputUnits');
    let outputUnitsElement = document.getElementById('outputUnits');

    let rations = {
        km: 1000,
        m: 1,
        cm: 0.01,
        mm: 0.001,
        mi: 1609.34,
        yrd: 0.9144,
        ft: 0.3048,
        in: 0.0254
    }

    let convert = function (){
        let valueToConvert = Number(inputElement.value);
        let unitFrom = inputUnitsElement.value;
        let unitTo = outputUnitsElement.value;

        let valueToMeters = valueToConvert * rations[unitFrom];

        let result = valueToMeters / rations[unitTo];
        outputElement.value = result;
    }

    buttonConvertElement.addEventListener('click', convert);
}