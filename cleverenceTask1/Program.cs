using cleverenceTask1;

//Клиенты считывают запись
var tasks = new Task[9];

for (var i = 0; i < 10; i++)
{  
    Task.Run(() =>
    {
        Thread.Sleep(100);
        new Client().Read();
    });
    Task.Run(() =>
    {
        Thread.Sleep(100);
        new Client().Write(new Random().Next(3, 7));
    });
}

Thread.Sleep(20000);
Console.WriteLine("Все всё сделали");