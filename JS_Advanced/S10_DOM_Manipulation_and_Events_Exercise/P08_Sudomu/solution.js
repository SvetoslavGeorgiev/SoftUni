function solve() {
    let [checkButton, clearButton] = document.querySelectorAll('button');
    let allRowsElement = Array.from(document.querySelectorAll('tbody tr'));
    let tableElement = document.querySelector('table');
    let resultElement = document.querySelector('div p');
    let isRowCorrect = true;
    let isColCorrect = true;

    checkButton.addEventListener('click', onCheckClick);
    clearButton.addEventListener('click', onClearClick);

    function onCheckClick() {
        let sudoku = createMatrix();
        for (let i = 0; i < sudoku.length; i++) {
            isRowCorrect = checkRow(sudoku, i);
            isColCorrect = checkColumn(sudoku, i);

            if (!isRowCorrect || !isColCorrect) {
                console.log('false');
                break;
            }
        }
        if (isRowCorrect && isColCorrect) {
            tableElement.style.border = '2px solid green';
            resultElement.textContent = 'You solve it! Congratulations!';
            resultElement.style.color = 'green';
        } else {
            tableElement.style.border = '2px solid red';
            resultElement.textContent = 'NOP! You are not done yet...';
            resultElement.style.color = 'red';
        }
    }

    function onClearClick() {
        let inputElements = document.querySelectorAll('td input');
        tableElement.style = 'none';
        resultElement.textContent = '';
        for (const input of inputElements) {
            input.value = '';
        }
    }

    function createMatrix() {
        let matrix = [];
        for (let row of allRowsElement) {
            let rowArr = [];
            for (let num of row.querySelectorAll('td input')) {
                rowArr.push(num.value);
            }
            matrix.push(rowArr);
        }
        return matrix;
    }

    function checkRow(matrix, row) {
        let correctRow = [1, 2, 3].join('');
        let currentRow = [];

        for (let i = 0; i < matrix.length; i++) {
            currentRow.push(matrix[row][i]);
        }
        return currentRow.sort().join('') === correctRow;
    }

    function checkColumn(matrix, col) {
        let correctColumn = [1, 2, 3].join('');
        let currentColumn = [];

        for (let i = 0; i < matrix.length; i++) {
            currentColumn.push(matrix[i][col]);
        }
        return currentColumn.sort().join('') === correctColumn;
    }
}