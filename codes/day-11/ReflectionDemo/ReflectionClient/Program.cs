using System.Collections;
using System.Reflection;

try
{
    //loading the library assembly dynamically 
    Assembly loadedAssembly = Assembly.LoadFile(@"E:\trainings\G7CR-DOTENET-3RD-MARCH\codes\day-11\ReflectionDemo\SampleLibrary\bin\Debug\net9.0\SampleLibrary.dll");

    Console.WriteLine($"name: {loadedAssembly.FullName}");

    //extracting all type information from the loaded assembly
    Type[] allTypes = loadedAssembly.GetTypes();
    Console.WriteLine("\n types from the assembly\n");
    foreach (var type in allTypes)
    {
        Console.WriteLine($"name: {type.FullName}");
        Console.WriteLine($"Is Class: {type.IsClass}");
        Console.WriteLine($"Is interface: {type.IsInterface}");
        Console.WriteLine($"Is value types: {type.IsValueType}");
    }

    //extracting particular type information
    Type? opsClsType = loadedAssembly.GetType("SampleLibrary.Operations");

    //dynamically creating instance from metadata (type info)
    if (opsClsType != null)
    {
        //this line expects the class has the default ctor, as it is going to call that ctor
        object? obj = Activator.CreateInstance(opsClsType);
        Console.WriteLine(obj?.GetType().Name);

        Console.WriteLine($"\n all methods of {obj?.GetType().Name}");
        //extracting all method info from the clas type info
        MethodInfo[] allMethods = opsClsType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Default | BindingFlags.Static | BindingFlags.Instance | BindingFlags.IgnoreCase);
        foreach (var method in allMethods)
        {
            Console.WriteLine($"name: {method.Name}");
            Console.WriteLine($"return type: {method.ReturnType}");
        }

        //extracting Add method info from type info
        MethodInfo? addInfo = opsClsType.GetMethod("Add");
        //extracting parameters of add method from add method info
        if (addInfo != null)
        {
            ParameterInfo[] allParams = addInfo.GetParameters();
            if (allParams.Length > 0)
            {
                Console.WriteLine("\nparameters of add method\n");
                foreach (var param in allParams)
                {
                    Console.WriteLine($"name: {param.Name}");
                    Console.WriteLine($"pos: {param.Position}");
                    Console.WriteLine($"data type: {param.ParameterType}");
                }

                //dynamically invoking add method using its metadata
                addInfo.Invoke(obj, [12, 13]);
                addInfo.Invoke(obj, [2, 4]);
                addInfo.Invoke(obj, [100, 200]);
            }
        }

        //extracting property info
        PropertyInfo? opsPropInfo = opsClsType.GetProperty("OperationResults");

        if (opsPropInfo != null)
        {
            //invoking getter 
            object? result = opsPropInfo.GetValue(obj);
            //opsPropInfo?.SetValue(obj, []);
            //if(opsPropInfo.PropertyType == typeof(IEnumerable))
            //{
            //    var list = result as System.Collections.IEnumerable;
            //    if (list != null)
            //        foreach (var item in list)
            //        {
            //            Console.WriteLine(item);
            //        }
            //}
            if (result != null)
            {
                //var resultType = result.GetType();
                //var interfaceType = resultType.GetInterface("System.Collections.IEnumerable");
                //if (interfaceType != null)
                //{
                //    var list = result as System.Collections.IEnumerable;
                //    if (list != null)
                //        foreach (var item in list)
                //        {
                //            Console.WriteLine(item);
                //        }
                //}
                if (result is IEnumerable list)
                {
                    if (list != null)
                        foreach (var item in list)
                        {
                            Console.WriteLine(item);
                        }
                }
            }
        }
    }
}
catch (FileNotFoundException e)
{
    Console.WriteLine(e);
}
catch (IOException e)
{
    Console.WriteLine(e);
}
catch (Exception e)
{
    Console.WriteLine(e);
}

LogicDel<int> isEven = new LogicDel<int>(num => num % 2 == 0);
isEven.Invoke(12);

delegate bool LogicDel<T>(T data);
/*
class LogicDel<T>//:MulticastDelegate:Delegate:Object
{
    private MethodInfo _method;
    private object? _target;

    public LogicDel(MethodInfo method, Object? target)
    {
        _method = method;
        _target = target;
    }

    public bool Invoke(T data)
    {
        if (_target != null)
            return (bool)_method.Invoke(_target, [data]);
        else
            return (bool)_method.Invoke(null, [data]);
    }

    public MethodInfo Method { get => _method; }
    public object? Target { get => _target; }
}
*/