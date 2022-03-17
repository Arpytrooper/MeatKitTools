using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ImageTaker))]
[CanEditMultipleObjects]
public class ImageTakerEditor : Editor
{

	public override void OnInspectorGUI()
    {
        serializedObject.Update();

        var property = serializedObject.GetIterator();
        if (!property.NextVisible(true)) return;
        do EditorGUILayout.PropertyField(property, true);
        while (property.NextVisible(false));
        serializedObject.ApplyModifiedProperties();

        ImageTaker imagetaker = serializedObject.targetObject as ImageTaker;
        if (GUILayout.Button("Only Take Images"))
        {
            imagetaker.takeImages();
        }
        if (GUILayout.Button("Take Images and fillout IDs"))
        {
            imagetaker.TakeImagesAndFilloutIDs();
        }
    }
}
