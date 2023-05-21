function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick () {
      
      let input = JSON.parse(document.querySelector('#inputs textarea').value);

      let avgSalary = 0;
      let totalSalary = 0;
      let currentAvgSalary = 0;
      let bestRestaurant = '';
      let output = {};


      for (const line of input) {

         let restaurantName = line.split(" - ").shift();
         let workers = line.split(" - ")[1].split(', ');

         for (const worker of workers) {
            let [name, salary] = worker.split(' ');
            if (!output.hasOwnProperty(restaurantName)) {

               output[restaurantName] = {};
               output[restaurantName][name] = salary;
               
            }else{
               output[restaurantName][name] = salary;
            }
         }
      }

      let listOfRestaurans = Object.entries(output)

      for (let resraurant of listOfRestaurans) {

         let currRestaurantName = resraurant[0];
         let workers = Object.entries(resraurant[1]);
         

         for (const worker of workers) {
            let [name, salary] = [worker[0], worker[1]]

            totalSalary += Number(salary);
         }

         currentAvgSalary = totalSalary / workers.length;

         if (currentAvgSalary > avgSalary) {

            avgSalary = currentAvgSalary;
            bestRestaurant = currRestaurantName;
            totalSalary = 0;
         }
      }

      let bestRestaurantText = document.querySelector('#bestRestaurant p');
      let bestRestaurantWorkers = document.querySelector('#workers p');
      let printWorkers = '';


      let result = Object.entries(output[bestRestaurant]).sort((a, b) => b[1] - a[1]);

      result.forEach(w => printWorkers += `Name: ${w[0]} With Salary: ${w[1]} `);

      bestRestaurantText.textContent = `Name: ${bestRestaurant} Average Salary: ${avgSalary.toFixed(2)} Best Salary: ${(Number(result[0][1])).toFixed(2)}`
      bestRestaurantWorkers.textContent = printWorkers;
      
   }
}