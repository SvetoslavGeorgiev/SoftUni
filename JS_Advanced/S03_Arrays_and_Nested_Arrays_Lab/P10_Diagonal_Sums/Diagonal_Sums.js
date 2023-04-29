function solve(matrix){

    let mainSum = 0;
    let secondarySum = 0;
    let mainDiagonalIndex = 0;
    let secondaryDiagonalIndex = matrix[0].length - 1;

    matrix.forEach(array => {
        mainSum += array[mainDiagonalIndex++];
        secondarySum += array[secondaryDiagonalIndex--];
    });

    console.log(mainSum, secondarySum);
}

solve([[20, 40],
    [10, 60]]
   );

solve([[3, 5, 17],
    [-1, 7, 14],
    [1, -8, 89]]);