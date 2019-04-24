using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Rotate))]
public class RotateEditor : Editor
{
    private SerializedObject obj;
    private Rotate rot;
    private SerializedProperty mode;
    private SerializedProperty rotateAxis;
    private SerializedProperty rotateSpeed;
    private SerializedProperty maxAngle;
    private SerializedProperty minAngle;
    private SerializedProperty delay;

    void OnEnable()
    {
        obj = new SerializedObject(target);
        mode = obj.FindProperty("mode");
        rotateAxis = obj.FindProperty("rotateAxis");
        rotateSpeed = obj.FindProperty("rotateSpeed");
        maxAngle = obj.FindProperty("maxAngle");
        minAngle = obj.FindProperty("minAngle");
        delay = obj.FindProperty("delay");
    }
    public override void OnInspectorGUI()
    {
        rot = (Rotate)target;
        //rot.mode = (Rotate.Mode)EditorGUILayout.EnumPopup("Mode", rot.mode);
        EditorGUILayout.PropertyField(mode);
        EditorGUILayout.PropertyField(rotateAxis);
        EditorGUILayout.PropertyField(rotateSpeed);
        EditorGUILayout.PropertyField(delay);
        if (mode.enumValueIndex == 1)
        {
            EditorGUILayout.PropertyField(maxAngle);
            EditorGUILayout.PropertyField(minAngle);
        }
        obj.ApplyModifiedProperties();
    }
}
