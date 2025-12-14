using System;

class TreeType
{
    public string Name { get; set; }
    public string Color { get; set; }
    
    public TreeType(string name,string color)
    {
        Name = name;
        Color = color;
    }
    
    public void Draw(int x,int y)
    {
        Console.WriteLine($"Draw {Name} tree with color {Color} at ({x}, {y})");
    }
}

class TreeFactory
{
    private static Dictionary<string, TreeType> treeTypes = new Dictionary<string, TreeType>();
    
    public static TreeType GetTreeType(string name, string color)
    {
        string key = name + "_" + color;
        if (!treeTypes.ContainsKey(key))
        {
            treeTypes[key] = new TreeType(name, color);
            Console.WriteLine($"Created new TreeType: {key}");
        }
        else
        {
            Console.WriteLine($"Reusing existing TreeType: {key}");
        }
        return treeTypes[key];
    }
}

class Tree
{
    private int x, y;
    private TreeType type;
    
    public Tree(int x, int y, TreeType type)
    {
        this.x = x;
        this.y = y;
        this.type = type;
    }
    
    public void Draw()
    {
        type.Draw(x, y);
    }
}

class Forest
{
    private List<Tree> trees = new List<Tree>();
    
    public void PlantTree(int x, int y, string name, string color)
    {
        var type = TreeFactory.GetTreeType(name, color);
        trees.Add(new Tree(x, y, type));
    }
    
    public void Draw()
    {
        foreach (var tree in trees) tree.Draw();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Forest forest = new Forest();
        forest.PlantTree(10, 20, "Oak", "Green");
        forest.PlantTree(23, 5, "Oak", "Green");
        forest.PlantTree(40, 30, "Oak", "DarkGreen");
        Console.WriteLine();
        forest.Draw();
    }
}
