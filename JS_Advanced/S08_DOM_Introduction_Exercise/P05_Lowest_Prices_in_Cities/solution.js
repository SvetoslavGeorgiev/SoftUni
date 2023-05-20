function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);
   let searchText = document.getElementById('searchField');
   let table = document.querySelectorAll('tbody tr');

   function onClick() {

      for (const row of table) {
         if (row.textContent.includes(searchText.value) && searchText.value !== '') {
            row.className = 'select';
         }else{
            row.classList.remove('select')
         }
      }

      searchText.value = '';

   }
}