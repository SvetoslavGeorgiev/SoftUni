function generateReport() {

    let columnsNeeded = Array.from(document.querySelectorAll('th input'));
    let checkedBoxesindexes = [];

    columnsNeeded.forEach((column, index) => {
        if (column.checked) {
            checkedBoxesindexes.push(index);
        }
    })

    let result = [];

    let rowsElements = document.querySelectorAll('tbody tr');
    let rows = Array.from(rowsElements);

    for (const row of rows) {
        let object = {};
        console.log(row.children);

        for (const index of checkedBoxesindexes) {
            let key = columnsNeeded[index].name;
            let value = row.children[index].textContent;
            object[key] = value;
        }

        result.push(object);
    }

    let output = document.getElementById('output');

    let report = JSON.stringify(result, null, 2);

    output.textContent = report;


}