# GoF_Csharp_Flyweight_pattern

The Flyweight Pattern is a design pattern that is used to minimize memory usage by sharing instances of lightweight objects. It is particularly useful when dealing with a large number of objects that have shared intrinsic state. The intrinsic state is the part of the object's state that can be shared among multiple objects, while the extrinsic state is the part that varies and cannot be shared.

In the context of C#, let's consider an example where we have a game that needs to render a large number of trees. Each tree has a position (extrinsic state) and a shared sprite image (intrinsic state). Instead of creating a separate sprite for each tree, we can share the sprite object among multiple trees, reducing memory usage.

Here's a simplified C# implementation of the Flyweight Pattern for the tree example:

```csharp
﻿using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        TreeFactory treeFactory = new TreeFactory();

        // Create trees with shared sprites.
        TreeSprite oakSprite = treeFactory.GetTreeSprite("oak.png");
        Tree tree1 = new Tree(10, 20, oakSprite);
        Tree tree2 = new Tree(30, 40, oakSprite);

        TreeSprite pineSprite = treeFactory.GetTreeSprite("pine.png");
        Tree tree3 = new Tree(50, 60, pineSprite);
        Tree tree4 = new Tree(70, 80, pineSprite);

        // Draw the trees.
        tree1.Draw(); // Uses the shared oak sprite.
        tree2.Draw(); // Uses the shared oak sprite.
        tree3.Draw(); // Uses the shared pine sprite.
        tree4.Draw(); // Uses the shared pine sprite.
    }
}

// TreeSprite represents the shared intrinsic state (sprite) of the trees.
class TreeSprite
{
    public string ImagePath { get; private set; }

    public TreeSprite(string imagePath)
    {
        ImagePath = imagePath;
    }

    public void Draw(int x, int y)
    {
        Console.WriteLine($"Drawing tree at position ({x}, {y}) with image '{ImagePath}'.");
    }
}

// Tree represents the extrinsic state (position) of a tree.
class Tree
{
    private int x;
    private int y;
    private TreeSprite sprite; // Reference to the shared TreeSprite.

    public Tree(int x, int y, TreeSprite sprite)
    {
        this.x = x;
        this.y = y;
        this.sprite = sprite;
    }

    public void Draw()
    {
        sprite.Draw(x, y);
    }
}

// TreeFactory manages the creation and sharing of TreeSprite objects.
class TreeFactory
{
    private Dictionary<string, TreeSprite> treeSprites = new Dictionary<string, TreeSprite>();

    public TreeSprite GetTreeSprite(string imagePath)
    {
        if (!treeSprites.TryGetValue(imagePath, out TreeSprite sprite))
        {
            sprite = new TreeSprite(imagePath);
            treeSprites.Add(imagePath, sprite);
        }
        return sprite;
    }
}
```

## How to setup Github actions

![Csharp Github actions](https://github.com/luiscoco/GoF_Csharp-11.Flyweight_pattern/assets/32194879/cc368481-9bf1-4a27-82fd-4413be3402d4)

