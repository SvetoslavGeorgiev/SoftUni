function solve() {

   let boughetedItems = [];
   let boughetedItemsPrices = [];
   let totalPrice = 0;

   let addProductElements = Array.from(document.getElementsByClassName('add-product'));
   let checkoutElement = document.getElementsByClassName('checkout')[0];
   let outputTextElement = document.getElementsByTagName('textarea')[0];
   outputTextElement.textContent = '';

   let onCLickAdd = function (e) {

      let product = e.currentTarget.parentNode.parentNode.getElementsByClassName('product-title')[0];
      let price = e.currentTarget.parentNode.parentNode.getElementsByClassName('product-line-price')[0];
      if (!boughetedItems.includes(product.textContent)) {
         boughetedItems.push(product.textContent);
      }
      boughetedItemsPrices.push(Number(price.textContent));

      let addItemText = `Added ${product.textContent} for ${price.textContent} to the cart.\n`

      outputTextElement.textContent += addItemText;


   }

   let checkoutClick = function (e) {

      totalPrice = boughetedItemsPrices.reduce(function (accumulator, currentValue) {
         return accumulator + currentValue;
       }, totalPrice);

      let addCheckoutText = `You bought ${boughetedItems.join(', ')} for ${totalPrice.toFixed(2)}.`

      outputTextElement.textContent += addCheckoutText;

      for (const button of addProductElements) {
         button.disabled = true;
      }

      checkoutElement.disabled = true;

   }

   for (const button of addProductElements) {
      button.addEventListener('click', onCLickAdd);
   }

   checkoutElement.addEventListener('click', checkoutClick);
}