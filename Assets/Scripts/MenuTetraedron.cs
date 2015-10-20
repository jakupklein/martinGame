using UnityEngine;
using System.Collections;
using UnityEditor;

public class MenuTetraedron   {
    [MenuItem("GameObject/Create Other/Create Tetraedron...")]
    static void CreateMaterial()
    {
        // Create a simple material asset
        var material = new Material(Shader.Find("Specular"));
        AssetDatabase.CreateAsset(material, "Assets/MyMaterial.mat");

        // Print the path of the created asset
        Debug.Log(AssetDatabase.GetAssetPath(material));
    }

}
