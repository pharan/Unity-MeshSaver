# Unity-MeshSaver
Save your Mesh as an asset file.
This script allows you to right-click on the MeshFilter component, and save its Mesh object as a .asset file you can reuse in your project.

This is great for saving/"baking" procedurally generated meshes that may be too resource-intensive to generate at runtime.

# How to Install
Just copy the folder called MeshSaver into your project's Assets folder, or drag it into Unity's project panel.

# How to Use
Right click on a MeshFilter component's label or click on its gear icon to open up its context menu. Then select either "Save Mesh..." or "Save Mesh As New Instance...". Note that "Save Mesh..." will not work if the mesh comes from an imported 3D asset/prefab.
