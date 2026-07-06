using System;
using System.Collections.Generic;

[Serializable]
public class Root
{
    public PlayerRecord record;
    public Metadata metadata;
}

[Serializable]
public class PlayerRecord
{
    public string playerName;
    public int level;
    public float health;
    public Position position;
    public List<InventoryItem> inventory;
}

[Serializable]
public class Position
{
    public float x;
    public float y;
    public float z;
}

[Serializable]
public class InventoryItem
{
    public string itemName;
    public int quantity;
    public float weight;
}

[Serializable]
public class Metadata
{
    public string id;
    public bool @private;
    public string createdAt;
    public string name;
}