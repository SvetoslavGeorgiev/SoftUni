function solve() {
  let sections = document.querySelectorAll('section');
  let resultElement = document.querySelector('#results li h1');
  let correctAnswers = ['onclick', 'JSON.stringify()', 'A programming API for HTML and XML documents'];
  let totalCorrectAnswers = 0;

  for (let i = 0; i < sections.length; i++) {
    let answers = sections[i].querySelectorAll('p');
    for (let option of answers) {
      option.addEventListener('click', onClickHandler)
    };

    function onClickHandler(e) {
      if (e.target.textContent == correctAnswers[i]) {
        totalCorrectAnswers += 1;
        if (i < 2) {
          sections[i].style.display = 'none';
          sections[i + 1].style.display = 'block';
        }
      } else if(i < 2){
        sections[i].style.display = 'none';
        sections[i + 1].style.display = 'block';
      }

      if (i == 2) {
        totalCorrectAnswers == 3
          ? resultElement.textContent = 'You are recognized as top JavaScript fan!'
          : resultElement.textContent = `You have ${totalCorrectAnswers} right answers`;

        sections[i].style.display = 'none';
        resultElement.parentNode.parentNode.style.display = 'block';
      }
    }
  }
}
