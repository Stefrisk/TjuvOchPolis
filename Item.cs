using System;

public class Item
{
    public string Namn { get; set; }

    public Item(string namn)
    {
        Namn = namn;
    }
}

public class Klocka: Item
{
    public Klocka(string namn) : base(namn)
    {
        
    }
}

public class Pengar : Item
{
    public Pengar(string namn) : base(namn)
    {
        
    }
}

public class Mobil : Item
{
    public Mobil(string namn) : base(namn)
    {
        
    }
}
public class Nycklar : Item
{
    public Nycklar(string namn) : base(namn)
    {
        
    }
}

