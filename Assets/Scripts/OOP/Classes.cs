using UnityEngine;

public class Human
{
    private string name;
    protected int age;

    public static int population = 0;

    // Constructor
    public Human()
    {
        Debug.Log("Human constructor");

        name = "John Doe";
        age = 0;

        population++;
    }
    
    public Human(string name, int age)
    {
        Debug.Log("Human constructor");

        this.name = name;
        this.age  = age;

        population++;
    }

    // Destructor
    ~Human()
    {
        Debug.LogFormat("Object destroyed");

        population--;
    }


    // Public Functions

    public string GetName()
    {
        return name;
    }

    /// <summary>
    /// Returns the current age of this human in days.
    /// </summary>
    /// <returns>The age in days.</returns>
    public int GetAgeInDays()
    {
        return age;
    }

    /// <summary>
    /// Returns the current age of this human in years.
    /// </summary>
    /// <returns>The age in years.</returns>
    public int GetAgeInYears()
    {
        return age / 365;
    }


    public void Print()
    {
        Debug.LogFormat("My name is {0}. I am {1} years old.",
            this.GetName(),
            this.GetAgeInYears());
    }

    public virtual void Age()
    {
        age++;
    }
}

public class MetaHuman : Human
{
    public MetaHuman() : base()
    {
        Debug.Log("MetaHuman constructor");
    }

    public MetaHuman(string name, int age) : base(name, age)
    {
        Debug.Log("MetaHuman constructor");
    }


    public override void Age()
    {
        // base.Age();  calls Age() in Base Class

        age *= 2;
    }

    public void Rejuvenate(int amount)
    {
        age -= amount;
    }
}

public class Table
{
    private string modelName;
    private float width, height, length;
    private int legCount;

    public Table()
    {
        modelName   = "undefined";
        width       = 2.0f;
        height      = 1.5f;
        length      = 1.0f;
        legCount    = 4;
    }

    public Table(string modelName, float width, float height, float length)
    {
        this.modelName  = modelName;
        this.width      = width;
        this.height     = height;
        this.length     = length;
        legCount        = 4;
    }

    public Table(string modelName, float width, float height, float length, int legCount)
    {
        this.modelName  = modelName;
        this.width      = width;
        this.height     = height;
        this.length     = length;
        this.legCount   = legCount;
    }


    public string GetModelName()
    {
        if (!string.IsNullOrEmpty(modelName))
        {
            return modelName;
        }

        return "?";
    }


    public void Print()
    {
        Debug.LogFormat("Ouput...{0}", GetModelName());
    }

}

