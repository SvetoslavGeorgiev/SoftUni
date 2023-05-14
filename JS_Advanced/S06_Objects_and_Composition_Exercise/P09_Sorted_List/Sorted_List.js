function createSortedList() {

    let sortedList = { arrOfNumbers: [], size: 0 };


    sortedList.add = function (number) {
        this.arrOfNumbers.push(Number(number))
        sortIt();
        getSize();
    };
    sortedList.remove = (index) => {
        if (isValid(index)) {
            sortedList.arrOfNumbers.splice(index, 1)
            getSize();
        }

    };
    sortedList.get = (index) => {
        if (isValid(index)) {
            return sortedList.arrOfNumbers[index];
        }
    };


    const sortIt = function sortIt() {
        sortedList.arrOfNumbers.sort((a, b) => a - b)
    };

    function getSize() {
        sortedList.size = sortedList.arrOfNumbers.length;
    };

    const isValid = function isValid(index) {
        return index >= 0 && index < sortedList.size;
    }

    return sortedList;
}



let list = createSortedList();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1));
list.remove(1);
console.log(list.get(1));
console.log(list.arrOfNumbers)
console.log(list.size);