using UnityEditor;

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(MeshSaver))]
public class MeshSaverEditor : Editor {

	bool makeNewInstance = true;
	bool optimizeMesh = false;

	public override void OnInspectorGUI ()
	{
		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.Space();
		optimizeMesh = EditorGUILayout.ToggleLeft("Optimize Mesh", optimizeMesh);
		EditorGUILayout.Space();
		EditorGUILayout.EndHorizontal();

		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.Space();
		makeNewInstance = EditorGUILayout.ToggleLeft("Save as new Instance", makeNewInstance);
		EditorGUILayout.Space();
		EditorGUILayout.EndHorizontal();

		// Save CurrentMesh button
		//
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();

		if ( GUILayout.Button("Save Mesh Asset", GUILayout.MaxWidth(200f), GUILayout.MinWidth(150f)) ) {
			MeshSaver ms = target as MeshSaver;
			Mesh mesh = ms.GetComponent<MeshFilter>().sharedMesh;
			SaveMesh(mesh, mesh.name, makeNewInstance, optimizeMesh);
		}

		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
	}

	public static void SaveMesh(Mesh mesh, string name, bool makeNewInstance, bool optimizeMesh) {
		string path = EditorUtility.SaveFilePanel("Save Separate Mesh Asset", "Assets/", name, "asset");
		if(string.IsNullOrEmpty(path)) return;
		path = FileUtil.GetProjectRelativePath(path);

		Mesh meshToSave = (makeNewInstance) ? Instantiate(mesh) as Mesh : mesh;
		if(optimizeMesh) meshToSave.Optimize();
		AssetDatabase.CreateAsset(meshToSave, path);
		AssetDatabase.SaveAssets();
	}
	
}
