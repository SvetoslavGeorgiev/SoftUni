function GetEvenElements(input){

    let resultArr = [];

    input.forEach((item, index)=>{
        if (index % 2 == 0) {
            resultArr.push(item)
        }
    });

    console.log(resultArr.join(' '));

}


GetEvenElements(['20', '30', '40', '50', '60'])