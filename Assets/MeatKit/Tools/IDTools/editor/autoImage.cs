using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine;



public class autoImage : EditorWindow
{
  /*  [SerializeField]
    public Object Camera;
    public static IconCamera iconCamera;
    [SerializeField]
    public static List<GameObject> ObjectsToImage;
    [SerializeField]
    public static Transform prefabLocation;
    [MenuItem("MeatKit/AutoIconCapture")]
    // Use this for initialization

    private static void Init()
    {
        GetWindow<autoImage>().Show();
    }

    private void OnGUI()
    {
        EditorGUILayout.BeginHorizontal();
        Camera = EditorGUILayout.ObjectField(Camera, typeof(Object), true);
        iconCamera = Camera.
        ObjectsToImage =;
        EditorGUILayout.EndHorizontal();
        // if (GUILayout.Button("Prep the Camera"))  {  }
        if (GUILayout.Button("Capture Icon Images"))
        {
            if (ObjectsToImage != null)
            {
                foreach (GameObject fillOut in ObjectsToImage)
                {
                    GameObject TempPrefab = Instantiate(fillOut, prefabLocation, prefabLocation);
                    Camera.iconName = fillOut.name + "Sprite";
                    Camera.Capture();
                    Destroy(TempPrefab);

                }
            } else
            {
                Debug.Log("Fill out your lists");
            }
        }
        
    }
  */
}
