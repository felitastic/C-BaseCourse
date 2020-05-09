using System;
using System.Reflection;

namespace SerialisationAufgabe
{
    class Program
    {
        static void Main(string[] args)
        {
            var myObj = new MyClass();
            myObj.Name = "test2";
            myObj.Value = 32;

            Console.WriteLine("Look at me go! :D");

            Serialize(new
            {
                Prop = "text",
                Val = 34,
                Props = new String[] { "s1", "s2", "s3" },
                Obj = new MyClass(),
                Obj2 = myObj
            });
                       
        }
        
        private static void Serialize(object p)
        {
            Type type = p.GetType();

            foreach(PropertyInfo property in type.GetProperties())
            {
                if (property.CanRead)
                {
                    //Console.WriteLine("{0}: {1}", property.Name, property.GetValue(p));
                    var value = property.GetValue(p);
                    Type valueType = value.GetType();
                
                    if (valueType.IsPrimitive || value is string)
                    {
                        Console.WriteLine("{1} {0}: {2}", property.Name, valueType, value);                               
                    }
                    else if (valueType.IsArray)
                    {
                        Array newArray = value as Array;
                        Console.WriteLine("{0} is an array, containing: ", value);

                        foreach (var item in newArray)
                        {
                            Console.WriteLine("{0}: {1}", item.GetType(), item);  
                        }  
                    }
                    else
                    {
                        Serialize(value);
                        Console.WriteLine("{0} is a class", value);    
                    }                
                }
            }            
        }
    }
}
