using Problem03.Queue;
using System;

var queue = new Queue<int>();

queue.Enqueue(5);
queue.Enqueue(3);
queue.Enqueue(7);
queue.Enqueue(1);

Console.WriteLine(string.Join(", ", queue));

queue.Dequeue();

Console.WriteLine(string.Join(", ", queue));
Console.WriteLine(queue.Peek());
queue.Dequeue();
queue.Enqueue(5);
Console.WriteLine(string.Join(", ", queue));