function create(words) {

   let contentDivElement = document.getElementById('content');

   let onClick = function(e) {
      e.currentTarget.children[0].style.display = 'block';
   }

   for (const word of words) {

      let divElement = document.createElement('div');
      let pElemet = document.createElement('p');
      pElemet.textContent = word;
      pElemet.style.display = "none";
      divElement.appendChild(pElemet)
      divElement.addEventListener('click', onClick)

      contentDivElement.appendChild(divElement);
      
   }
}