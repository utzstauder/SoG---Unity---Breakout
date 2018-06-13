using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PrefabSpawnerWindow : EditorWindow {

    #region Private Fields

    GameObject prefab;
    Transform parentTransform;
    bool keepPrefabLink = true;
    int amount;
    Vector3 offset;
    Vector3 rotationOffset;
    bool relativeRotation;

    #endregion


    #region Window Functions

    [MenuItem("Tools/Prefab Spawner", false, 1000)]
    static void Init()
    {
        PrefabSpawnerWindow window = GetWindow<PrefabSpawnerWindow>();
        window.Show();
    }

    private void OnGUI()
    {
        if (prefab == null)
        {
            EditorGUILayout.HelpBox("Please assign a prefab reference.", MessageType.Info);
            // GUILayout.Label("Please assign a prefab reference.", GUI.tooltip);
        }
        prefab = EditorGUILayout.ObjectField("Prefab", prefab, typeof(GameObject), false) as GameObject;
        keepPrefabLink = EditorGUILayout.Toggle("Keep Prefab Link", keepPrefabLink);

        parentTransform = EditorGUILayout.ObjectField(new GUIContent("Parent Transform", "All prefabs instances will be parented to this."), parentTransform, typeof(Transform), true) as Transform;

        amount = EditorGUILayout.IntField("Amount", amount);
        if (amount < 1)
        {
            amount = 1;
        }

        offset = EditorGUILayout.Vector3Field("Position Offset", offset);
        rotationOffset = EditorGUILayout.Vector3Field("Rotation Offset", rotationOffset);
        relativeRotation = EditorGUILayout.Toggle("Relative Rotation", relativeRotation);

        EditorGUILayout.BeginHorizontal();
        {
            EditorGUI.BeginDisabledGroup(prefab == null || parentTransform == null);
            {
                if (GUILayout.Button("Instatiate Prefabs"))
                {
                    InstantiatePrefabs(
                        prefab,
                        amount,
                        offset,
                        rotationOffset,
                        relativeRotation,
                        parentTransform,
                        keepPrefabLink);
                }
            }
            EditorGUI.EndDisabledGroup();

            EditorGUI.BeginDisabledGroup(parentTransform == null);
            {
                if (GUILayout.Button("Clean Children"))
                {
                    CleanHierarchy(parentTransform);
                }
            }
            EditorGUI.EndDisabledGroup();
        }
        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Open File"))
        {
            string path = EditorUtility.OpenFilePanel("Open file", "", "xml");
            Debug.Log(path);
        }

        if (GUILayout.Button("Save File"))
        {
            string path = EditorUtility.SaveFilePanel("Save File", "", "settings", "xml");
            Debug.Log(path);
        }
    }

    #endregion


    #region Static Functions

    public static void InstantiatePrefabs(GameObject prefab,
        int amount,
        Vector3 offset,
        Vector3 rotationOffset,
        bool relativeRotation = false,
        Transform parentTransform = null,
        bool keepPrefabLink = true)
    {
        if (amount <= 0 || prefab == null) return;

        Vector3 pos     = Vector3.zero;
        Quaternion rot  = Quaternion.identity;

        for (int i = 0; i < amount; i++)
        {
            rot = Quaternion.Euler(rotationOffset * i);

            if (relativeRotation)
            {
                pos = pos + (rot * offset);
            } else
            {
                pos = offset * i;
            }

            GameObject newObject;

            if (keepPrefabLink)
            {
                newObject = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
            }
            else
            {
                newObject = Instantiate(prefab);
            }

            newObject.transform.parent = parentTransform;
            newObject.transform.localPosition = pos;
            newObject.transform.localRotation = rot;

            Undo.RegisterCreatedObjectUndo(newObject, "Instantiate Prefabs");
        }

        
    }

    public static void CleanHierarchy(Transform parent)
    {
        if (parent == null)
        {
            EditorUtility.DisplayDialog("Prefab Spawner",
                                        "parentTransform not set!",
                                        "Got it!");
            // Debug.LogWarningFormat("parentTransform not set!");
        }
        else
        {
            for (int i = parent.childCount - 1; i >= 0; i--)
            {
                // DestroyImmediate(parent.GetChild(i).gameObject);
                Undo.DestroyObjectImmediate(parent.GetChild(i).gameObject);
            }
        }
    }

    #endregion
}
