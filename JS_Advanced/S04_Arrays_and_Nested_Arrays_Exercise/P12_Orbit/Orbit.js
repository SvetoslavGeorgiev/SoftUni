function solve(input) {

    let rows = input[1];
    let cols = input[0];
    let x = Number(input[2]);
    let y = Number(input[3]);

    let matrix = [];

    for (let i = 0; i < rows; i++) {
        matrix.push([]);
    }


    for (let row = 0; row < rows; row++) {
        for (let col = 0; col < cols; col++) {
            matrix[row][col] = Math.max(Math.abs(row - x), Math.abs(col - y)) + 1;
        }
    }

    matrix.forEach(x => console.log(x.join(' ')));

}


solve([4, 4, 0, 0])

solve([5, 5, 2, 2])

solve([3, 3, 2, 2])

solve([6, 6, 2, 2])

solve([4, 4, 1, 1])