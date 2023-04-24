function solve(arr) {
    return Number(arr.pop()) + Number(arr.shift());
  }

  
  console.log(solve(['20', '30', '40']));
  console.log(solve(['10', '5']));