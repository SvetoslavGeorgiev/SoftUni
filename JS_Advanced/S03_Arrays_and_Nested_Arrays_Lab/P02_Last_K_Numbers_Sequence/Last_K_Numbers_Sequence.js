function solve(n, k){

    let arr = [];
    arr.length = Number(n);
    arr[0] = 1


    for (let index = 1; index < arr.length; index++) {
        let currentSum = 0;

        for (let j = 0 - Number(k); j < index; j++) {
            currentSum += Number(arr[j]) || 0;
        }

        arr[index] = currentSum;
    }

    console.log(arr.join(', '));

}

solve(6, 3)
solve(8, 2)