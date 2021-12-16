class Cave
{
    public Cave(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
    public List<Cave> Caves { get; } = new List<Cave>();

    public override string ToString() => Name;

    public bool IsSmall => Order == 1 && Name == Name.ToLowerInvariant();
    public int Order
    {
        get
        {
            switch (Name)
            {
                case "start":
                    return 0;
                case "end":
                    return 2;
                default:
                    return 1;
            }
        }
    }
}