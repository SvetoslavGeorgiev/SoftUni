function search() {

   let searchText = document.getElementById('searchText').value;
   let towns = Array.from(document.querySelectorAll('#towns li'));
   let resilt = document.getElementById('result');
   let counter = 0;

   for (const town of towns) {

      town.style.fontWeight = 'normal';
      town.style.textDecoration = 'none';


      if (town.textContent.includes(searchText) && searchText !== '') {

         town.style.fontWeight = 'bold';
         town.style.textDecoration = 'underline';
         counter++;
         
      }
      
   }

   resilt.textContent = `${counter} matches found`;
}
