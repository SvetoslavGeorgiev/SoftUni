function solve() {
  let input = document.getElementById('input');
  let textArr = input.value.split('.').filter(s => s !== '');
  let output = document.getElementById('output');

  while (textArr.length > 0) {
    let text = textArr.splice(0, 3).join('. ') + '.';
    let p = document.createElement('p');
    p.textContent = text;
    output.appendChild(p);
  }
}