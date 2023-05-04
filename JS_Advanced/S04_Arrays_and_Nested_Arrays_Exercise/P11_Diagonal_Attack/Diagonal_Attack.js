function solve(input){

    let matrix = [];

    while (input.length > 0) {
        matrix.push(input.shift().split(' ').map(Number));
    }

    function checkLeftDiagonal(matrix) {
        let topLeft = matrix[0][0];
        let topRight = matrix[0][matrix.length - 1];
        let y = matrix.length - 1;
        for (let i = 1; i < matrix.length; i++) {
          topLeft += matrix[i][i];
          topRight += matrix[i][y - i];
        }
        return [topLeft, topRight];
    };

    
    let firstDiagonal = checkLeftDiagonal(matrix)[0];
    let secondDiagonal = checkLeftDiagonal(matrix)[1];

    if (firstDiagonal === secondDiagonal) {
        for (let i = 0; i < matrix.length; i++) {
            for (let j = 0; j < matrix.length; j++) {
                if (j !== i && j !== matrix.length - 1 - i) {
                    matrix[i][j] = firstDiagonal;
                }
            }
        }
    }

    matrix.forEach(x => console.log(x.join(' ')));

}


solve(['5 3 12 3 1',
       '11 4 23 2 5',
       '101 12 3 21 10',
       '1 4 5 2 2',
       '5 22 33 11 1']
)