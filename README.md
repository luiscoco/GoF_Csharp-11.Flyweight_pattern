# GoF_Csharp_Flyweight_pattern

The Flyweight Pattern is a design pattern that is used to minimize memory usage by sharing instances of lightweight objects. It is particularly useful when dealing with a large number of objects that have shared intrinsic state. The intrinsic state is the part of the object's state that can be shared among multiple objects, while the extrinsic state is the part that varies and cannot be shared.

In the context of C#, let's consider an example where we have a game that needs to render a large number of trees. Each tree has a position (extrinsic state) and a shared sprite image (intrinsic state). Instead of creating a separate sprite for each tree, we can share the sprite object among multiple trees, reducing memory usage.

Here's a simplified C# implementation of the Flyweight Pattern for the tree example:


