using System;

namespace csharpreferencetypevaluetype;

struct MyStruct
{
    public int Num { get; set; }
    public MyStruct()
    {
        Num = 0;
    }
}

internal class MyClass
{
    public MyClass()
    {
    }
    public int Num { get; set; }
}

class Program
{
    static void Main()
    {
        var myClassObj = new MyClass();
        var myStructObj = new MyStruct();

        MethodA(myClassObj.Num);
        MethodB(myStructObj);
        MethodC(myClassObj);
        MethodD(myClassObj);

        Console.WriteLine(myClassObj.Num);
        Console.WriteLine(myStructObj.Num);
    }

    private static void MethodA(int num)
    {
        num = num + 1;
    }

    private static void MethodB(MyStruct myStruct)
    {
        myStruct.Num += 1;
    }

    private static void MethodC(MyClass myClass)
    {
        myClass.Num += 1;
    }

    private static void MethodD(MyClass myClass)
    {
        myClass = new MyClass
        {
            Num = myClass.Num * 2
        };
    }
}