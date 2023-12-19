var tasks = new List<Task>();
Func<Task> function1 = async () =>
{
    await Task.Delay(2000);
    Console.WriteLine("After some time");
    throw new Exception(message: "Task Exception1");
};
Func<Task> function2 = async () =>
{
    await Task.Delay(2000);
    Console.WriteLine("After some time");
    throw new Exception(message: "Task Exception2");
};
dynamic oneTask = await Task.Factory.StartNew(function1);
oneTask = "3";
var TwoTask = await Task.Factory.StartNew(function2);

tasks.Add(oneTask);
tasks.Add(TwoTask);
try
{
    await Task.WhenAll(tasks);
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}