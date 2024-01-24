
DelEventHandler d = USA;
d += India;
d += England;
//add += new DelEventHandler(USA);
//add += new DelEventHandler(India);
//add += new DelEventHandler(England);
add += d;
add.Invoke();
Console.ReadLine();
public static event DelEventHandler add;
public delegate void DelEventHandler();

static void USA()
{
    Console.WriteLine("USA");
}

static void India()
{
    Console.WriteLine("India");
}

static void England()
{
    Console.WriteLine("England");
}

