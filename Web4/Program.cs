using System;
using System.Reflection;

public class MyClass
{
    private int _privateField;
    public string PublicField;
    protected double ProtectedField;
    internal bool InternalField;
    static readonly int StaticReadonlyField = 42;

    public MyClass(int privateValue, string publicValue)
    {
        _privateField = privateValue;
        PublicField = publicValue;
    }

    public void PublicMethod()
    {
        Console.WriteLine("This is a public method..");
    }

    private void PrivateMethod()
    {
        Console.WriteLine("This is a private method..");
    }

    public string GetDetails()
    {
        return $"PrivateField: {_privateField}, PublicField: {PublicField}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        MyClass myObject = new MyClass(100, "Hello Reflection!");

        Type type = typeof(MyClass);
        Console.WriteLine($"Class type: {type.Name}");
        Console.WriteLine("All class members:");
        foreach (var member in type.GetMembers())
        {
            Console.WriteLine($"- {member.Name} ({member.MemberType})");
        }

        Console.WriteLine("\nWorking with MemberInfo:");
        MemberInfo[] members = type.GetMembers();
        foreach (var member in members)
        {
            Console.WriteLine($"{member.MemberType}: {member.Name}");
        }

        Console.WriteLine("\nWorking with FieldInfo:");
        FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
        foreach (var field in fields)
        {
            Console.WriteLine($"Field: {field.Name}, Тип: {field.FieldType}");
        }

        Console.WriteLine("\nWorking with MethodInfo:");
        MethodInfo methodInfo = type.GetMethod("PublicMethod");
        Console.WriteLine($"Calling the method: {methodInfo.Name}");
        methodInfo.Invoke(myObject, null);

        MethodInfo privateMethod = type.GetMethod("PrivateMethod", BindingFlags.NonPublic | BindingFlags.Instance);
        Console.WriteLine("\nCalling a private method:");
        privateMethod.Invoke(myObject, null);

        Console.ReadLine();
    }
}

