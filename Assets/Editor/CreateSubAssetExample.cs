// 放在 Editor 文件夹下，例如 Assets/Editor/CreateSubAssetExample.cs
using UnityEditor;
using UnityEngine;

public class CreateSubAssetExample
{
    [MenuItem("Tools/SubAsset/Create Example")]
    private static void Create()
    {
        var main = ScriptableObject.CreateInstance<MainAsset>();
        AssetDatabase.CreateAsset(main, "Assets/SubAssetMain.asset");

        var sub1 = ScriptableObject.CreateInstance<SubAsset>();
        sub1.name = "SubA";
        var sub2 = ScriptableObject.CreateInstance<SubAsset>();
        sub2.name = "SubB";

        AssetDatabase.AddObjectToAsset(sub1, main);
        AssetDatabase.AddObjectToAsset(sub2, main);

        EditorUtility.SetDirty(main);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Selection.activeObject = main;
    }
    
}