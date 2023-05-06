function solve(rows, columns) {
    let matrix = [];
    for (let i = 0; i < rows; i++) {
      matrix[i] = [];
    }
  
    let counter = 1;
  
    function fillMatrix(startRow, endRow, startColumn, endColumn) {

      for (let i = startColumn; i <= endColumn; i++) {
        matrix[startRow][i] = counter++;
      }
  
      for (let i = startRow + 1; i <= endRow; i++) {
        matrix[i][endColumn] = counter++;
      }
  
      for (let i = endColumn - 1; i >= startColumn; i--) {
        matrix[endRow][i] = counter++;
      }
  
      for (let i = endRow - 1; i > startRow; i--) {
        matrix[i][startColumn] = counter++;
      }
  
      if (startRow + 1 >= endRow || startColumn + 1 >= endColumn) {
        return;
      }
  
      fillMatrix(startRow + 1, endRow - 1, startColumn + 1, endColumn - 1);
    }
  
    fillMatrix(0, rows - 1, 0, columns - 1);
  
    matrix.forEach(x => console.log(x.join(' ')));
}



solve(3, 3);

solve(5, 5);

