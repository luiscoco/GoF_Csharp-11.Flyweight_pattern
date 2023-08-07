using System;
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
