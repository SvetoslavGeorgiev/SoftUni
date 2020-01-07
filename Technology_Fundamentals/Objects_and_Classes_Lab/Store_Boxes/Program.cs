using System;
using System.Collections.Generic;
using System.Linq;

namespace Store_Boxes
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<Item> items = new List<Item>();
            List<Box> boxes = new List<Box>();
            var command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                var data = command.Split();

                var serialNumber = data[0];
                var itemName = data[1];
                var itemQuantity = int.Parse(data[2]);
                var itemPrice = double.Parse(data[3]);
                var boxPrice = itemPrice * itemQuantity;

                //Item item = new Item();
                Box box = new Box();
                box.Item.Name = itemName;
                box.Item.Price = itemPrice;

                //items.Add(item);  // we are going to see if we will need that later!!
                // It is not!!!

                
                //box.Item = item;
                box.ItemQuantity = itemQuantity;
                box.BoxPrice = boxPrice;
                box.SerialNumber = serialNumber;

                boxes.Add(box);

            }


            boxes.Sort((x,y) => x.BoxPrice.CompareTo(y.BoxPrice));
            boxes.Reverse();



            foreach (Box box in boxes)
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:F2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.BoxPrice:F2}");
            }
        }

        class Item
        {
            public string Name { get; set; }
            public double Price { get; set; }

        }

        class Box
        {
            public Box()
            {
                Item = new Item();
            }
            public string SerialNumber { get; set; }
            public Item Item { get; set; }
            public int ItemQuantity { get; set; }
            public double BoxPrice { get; set; }

        }
    }
}
