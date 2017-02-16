using System;
using System.Reflection;

class Program
{
    int x { get; set; }
    public int y { get; set; }

    public Program(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public int Sum()
    {
        return x + y;
    }

    public void set(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    static void Ref()
    {
        Assembly asm = Assembly.LoadFrom("反射和特性.exe");
        Type t = asm.GetType("Program");

        Console.WriteLine("反射 ：" + t.Name);

        Console.WriteLine("\n属性:");
        foreach (PropertyInfo p in t.GetProperties())
        {
            Console.WriteLine(" " + p.PropertyType.Name + " " + p.Name);
        }

        Console.WriteLine("\n方法:");
        foreach (MethodInfo m in t.GetMethods())
        {
            Console.Write(" " + m.ReflectedType.Name + " " + m.Name + "(");
            ParameterInfo[] pi = m.GetParameters();
            for (int i = 0; i < pi.Length; i++)
            {
                Console.Write(pi[i].ParameterType.Name + " " + pi[i].Name);
                if (i + 1 < pi.Length)
                    Console.Write(", ");
            }
            Console.WriteLine(")");
        }

        Console.Write("\n调用方法:\n ");
        foreach (MethodInfo m in t.GetMethods())
        {
            if (m.Name == "Sum")
                Console.WriteLine(m.Invoke(new Program(10, 110), null));
        }
    }

    static void Main(string[] args)
    {
        Ref();
        new UseAttri().test();
    }
}

// 创建特性
[AttributeUsage(AttributeTargets.All)]
public class RemarkAttribute : Attribute
{
    public string Comment { get; }

    public RemarkAttribute(string comment)
    {
        Comment = comment;
    }
}

[RemarkAttribute("This class uses an attribute.")]
class UseAttri
{
    public void test()
    {
        RemarkAttribute ra = (RemarkAttribute)Attribute.GetCustomAttribute(GetType(), typeof(RemarkAttribute));
        Console.WriteLine("使用特性：" + ra.Comment);
    }
}