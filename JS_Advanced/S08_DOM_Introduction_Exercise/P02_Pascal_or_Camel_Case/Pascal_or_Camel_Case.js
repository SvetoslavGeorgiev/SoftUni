function solve() {

  let text = document.getElementById("text").value;
  let currentCase = document.getElementById("naming-convention").value;
  let result = document.getElementById("result");

  let resultString = '';

  if (currentCase === "Camel Case") {

    for (let index = 0; index < text.length; index++) {
      const element = text[index];

      if (element === ' ') {
        resultString += text[index + 1].toUpperCase();
        index++
      } else {
        resultString += element.toLowerCase();
      }
    }

  } else if (currentCase === "Pascal Case") {

    resultString += text[0].toUpperCase();

    for (let index = 1; index < text.length; index++) {
      const element = text[index];

      if (element === ' ') {
        resultString += text[index + 1].toUpperCase();
        index++
      } else {
        resultString += element.toLowerCase();
      }
    }
  } else {

    resultString = 'Error!';

  }

  result.textContent = resultString;


}