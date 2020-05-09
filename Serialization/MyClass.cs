using System;

public class MyClass
{
    private int value = 42;
    public string Name { get; set; } = "test";
    public bool Bool => true;
    public int Value { set { this.value = value; } }
}



