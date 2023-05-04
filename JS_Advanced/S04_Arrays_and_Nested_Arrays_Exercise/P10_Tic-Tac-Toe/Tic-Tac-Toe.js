function solve(input){

    let turn = 0;

    let player;

    let noWinner = true;

    const allEqualInRow = arr => arr.every(v => v === arr[0]);

    function allEqualInColumn(matrix, column) {
        const firstElement = matrix[0][column];
        for (let i = 1; i < matrix.length; i++) {
          if (matrix[i][column] !== firstElement) {
            return false;
          }
        }
        return firstElement === 'false' ? false : true;
    }

    function checkLeftDiagonal(matrix) {
        const topLeft = matrix[0][0];
        for (let i = 1; i < matrix.length; i++) {
          if (matrix[i][i] !== topLeft) {
            return false;
          }
        }
        return topLeft === 'false' ? false : true;
    }

    function checkRightDiagonal(matrix) {
        const topRight = matrix[0][2];
        let y = 2;
        for (let i = 1; i < matrix.length; i++) {
            if(matrix[i][y - i] !== topRight){
                return false;
            }
        }
        return topRight === 'false' ? false : true;
    }

    function printWiner(){
        console.log(`Player ${player} wins!`)
    }
      
    let initialMatrix = [['false', 'false', 'false'],
                         ['false', 'false', 'false'],
                         ['false', 'false', 'false']];

    for (const el of input) {
        var currCoordinates = el.split(' ').map(Number);

        let x = currCoordinates[0];
        let y = currCoordinates[1];

        if (initialMatrix[x][y] === 'false') {

            player = turn % 2 === 0 ? 'X' : 'O';

            initialMatrix[x][y] = player;

            turn++;
            
        }else{
            console.log('This place is already taken. Please choose another!');
        }

        if (turn === 9) {
            break;
        }

        if ((allEqualInRow(initialMatrix[0]) && initialMatrix[0][0] !== 'false') || 
            (allEqualInRow(initialMatrix[1]) && initialMatrix[1][0] !== 'false') ||
            (allEqualInRow(initialMatrix[2]) && initialMatrix[2][0] !== 'false') ||
            allEqualInColumn(initialMatrix, 0) || allEqualInColumn(initialMatrix, 1) ||
            allEqualInColumn(initialMatrix, 2) || checkRightDiagonal(initialMatrix) || 
            checkLeftDiagonal(initialMatrix)) {
            printWiner();
            noWinner = false;
            break;
        }
    }

    if (noWinner) {
        console.log('The game ended! Nobody wins :(')
    }

    initialMatrix.forEach(x => console.log(x.join('\t')))
}


solve(["0 1",
       "0 0",
       "0 2", 
       "2 0",
       "1 0",
       "1 1",
       "1 2",
       "2 2",
       "2 1",
       "0 0"]
);

solve(["0 0",
       "0 0",
       "1 1",
       "0 1",
       "1 2",
       "0 2",
       "2 2",
       "1 2",
       "2 2",
       "2 1"]
);

solve(["0 1",
       "0 0",
       "0 2",
       "2 0",
       "1 0",
       "1 2",
       "1 1",
       "2 1",
       "2 2",
       "0 0"]
);