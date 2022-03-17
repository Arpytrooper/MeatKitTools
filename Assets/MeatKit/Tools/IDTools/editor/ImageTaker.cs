using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//[ExecuteInEditMode]
public class ImageTaker : MonoBehaviour
{
    //public List<GameObject> ObjectsToImage;
    public Camera theCamera;
    public OIDAutoComplete ObjectsList;
    public IconCamera iconcamera;
    public Transform prefabLocation;
   // [HideInInspector]
   public bool hasRendered = false;

    
    

    [ContextMenu("takeImages")]
    public void takeImages()
    {
        ObjectsList.PathtoImage = iconcamera.path;

        if (ObjectsList.ObjectsToID != null)
        {
            foreach (GameObject fillOut in ObjectsList.ObjectsToID)
            {
                

                hasRendered = false;
                GameObject TempPrefab = Instantiate(fillOut, prefabLocation.position, prefabLocation.rotation, prefabLocation);
                
                //Rigidbody quick = TempPrefab.GetComponent(typeof(Rigidbody)) as Rigidbody;
               // quick.isKinematic = true;
                TempPrefab.transform.localScale = new Vector3(1, 1, 1);
                iconcamera.iconName = fillOut.name + "Sprite";
                //Bounds b = GetBounds(TempPrefab);
                //PositionInView(TempPrefab, theCamera);
                theCamera.Render();
                OnPostRender();
                //this.iconcamera.Capture();

                //DestroyImmediate(TempPrefab);         uncomment this       
                //StartCoroutine(TakePhoto(fillOut));
                
                
                Debug.Log("Deleted the prefab");
                
            }
            
        }
        else
        {
            Debug.Log("Fill out your lists");
        }

    }
    [ContextMenu("TakeImagesAndFilloutIDs")]
    public void TakeImagesAndFilloutIDs()
    {
        takeImages();
        ObjectsList.FillIDsANDEntries();
    }
    /*IEnumerator TakePhoto(GameObject fillOut)
    {
        GameObject TempPrefab = Instantiate(fillOut, prefabLocation.position, prefabLocation.rotation, prefabLocation);
        Rigidbody quick = TempPrefab.GetComponent(typeof(Rigidbody)) as Rigidbody;
        quick.isKinematic = true;
        TempPrefab.transform.localScale = new Vector3(1, 1, 1);
        this.iconcamera.iconName = fillOut.name + "Sprite";
        while (!hasRendered) { };
        this.iconcamera.Capture();
        
        DestroyImmediate(TempPrefab);
        hasRendered = false;
        yield return null;
    }*/
    void OnPostRender()
    {
        
        if (!hasRendered)
        this.iconcamera.Capture();
        hasRendered = true;
       
    }
   /* public Bounds GetBounds(GameObject gameObject)
    {
        // Create a new bounds which uses the position of the root game object as a zero
        var center = gameObject.transform.position;
        var bounds = new Bounds(center, Vector3.zero);

        // For each renderer in the object, grow the bounds to include the bounds of that renderer
        foreach (var r in gameObject.GetComponentsInChildren<MeshFilter>())
            bounds.Encapsulate(r.mesh.bounds);

        // Return the bounds
        return bounds;
    }
    public void PositionInView(GameObject TempPrefab, Camera cam)
    {
        const float DISTANCE_FROM_CAM = 50;
        Vector2 padding = new Vector2(0.1f, 0.1f); //Distance we want to keep from the viewport borders.

        Bounds bounds = GetBounds(TempPrefab);    //Get the bounds of the model - these are in local space of the model, axis aligned.
                                                                   //Calculate the max width the object is allowed to have in world space, based on the padding we decided.
        float maxWidth = Vector3.Distance(cam.ViewportToWorldPoint(new Vector3(padding.x, 0.5f, DISTANCE_FROM_CAM)),
            cam.ViewportToWorldPoint(new Vector3(1f - padding.x, 0.5f, DISTANCE_FROM_CAM)));
        //Calculate the scale based on width only - you will have to check if the model is tall instead of wide and check against the aspect of the camera, and act accordingly.
        float scale = (maxWidth / bounds.size.x);
        //Apply the scale to the model.
        TempPrefab.transform.localScale = Vector3.one * scale;

        //Position the model at the desired distance.
        Vector3 desiredPosition = DISTANCE_FROM_CAM * Camera.main.transform.forward + Camera.main.transform.position;
        //The max width we calculated is for the entirety of the model in the viewport, so we need to position it so the front of the model is at the desired distance, not the center.
        //You will also have to keep rotation of the camera and the model in mind.
        TempPrefab.transform.position = desiredPosition + new Vector3(0, 0, bounds.extents.z * scale);
    }*/
}