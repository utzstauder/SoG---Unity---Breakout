using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemyScriptableObject))]
public class EnemyScriptableObjectInspector : Editor {

    public override void OnInspectorGUI()
    {
        EnemyScriptableObject script = (EnemyScriptableObject)target;

        // base.OnInspectorGUI();


        // draw custom inspector
        script.name = EditorGUILayout.TextField("Name", script.name);
        script.attackPower = EditorGUILayout.IntField("Atk Power", script.attackPower);

        //if (script.attackPower > 0)
        //{
        //    script.attackType = (EnemyScriptableObject.AttackType)EditorGUILayout.EnumPopup("Atk Type", (EnemyScriptableObject.AttackType)script.attackType);
        //}

        EditorGUI.BeginDisabledGroup(script.attackPower <= 0);
        script.attackType = (EnemyScriptableObject.AttackType)EditorGUILayout.EnumPopup("Atk Type", (EnemyScriptableObject.AttackType)script.attackType);
        EditorGUI.EndDisabledGroup();


        if (GUILayout.Button("Randomize stats")){
            script.attackPower = Random.Range(0, 100);
            Debug.Log("Stats randomized!");
        }
    }

}
