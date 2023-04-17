function GetYesterday(year, month, day){
    let yesterday = new Date(year, month - 1, day - 1);

    let printDate = `${yesterday.getFullYear()}-${yesterday.getMonth() + 1}-${yesterday.getDate()}`

    console.log(printDate);

}


GetYesterday(2016, 9, 30)
GetYesterday(2015, 5, 10)
GetYesterday(2016, 9, 1)