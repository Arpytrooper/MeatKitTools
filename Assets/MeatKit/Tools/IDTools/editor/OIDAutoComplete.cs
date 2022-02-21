using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using FistVR;


[CreateAssetMenu(fileName = "OIDAutoComplete", menuName = "Object IDs/AutoComplete", order = 1)]
public class OIDAutoComplete : ScriptableObject
{

    public FVRObject.ObjectCategory Category;
    public AppendType typeOfAppend = OIDAutoComplete.AppendType.No_Custom_String;
    public string customAppend;
    [Header("Tags")]
    public FVRObject.OTagEra Era;
    public FVRObject.OTagSet Set;
    public FVRObject.OTagFirearmSize FirearmSize;
    public FVRObject.OTagFirearmAction FirearmAction;
    public FVRObject.OTagFirearmRoundPower RoundPower;
    public FVRObject.OTagFirearmCountryOfOrigin CountryOfOrigin;
    public int FirstYear;
    public List<FVRObject.OTagFirearmFiringMode> firingMode;
    public List<FVRObject.OTagFirearmFeedOption> FeedOptions;
    public List<FVRObject.OTagFirearmMount> FirearmMounts;
    public FVRObject.OTagFirearmMount AttachmentMounts;
    public FVRObject.OTagAttachmentFeature AttachmentFeature;
    public List<GameObject> ObjectsToID;
    [Header("The path Starts with Assets/ and ends with / after the folder location you want the assets to export into")]
    public string ExportLocation;
    [Tooltip("If this bool is checked it will create an FVRObjectID in the folder of the gameobject")]
    // public bool CreateAtObjectLocation;
    public bool WillSpawnInTakeAndHold = true;
    //[Tooltip("This is the path that the FVRObjectID will be created at if you do not have 'CreateAtObjectLocation' checked")]
   
    [ContextMenu("AutoFillItemIDs")]
    public void AutoFillItemIDs()
    {
        Debug.Log("pressed");
        char lastCharOfExportLocation;
        bool isExportLocationValid = false;
        lastCharOfExportLocation = ExportLocation[ExportLocation.Length - 1];               
        if (lastCharOfExportLocation == '/')
        {
            isExportLocationValid = true;
        } else
        {
            isExportLocationValid = false;
            Debug.Log("You need to end your file path with a /");
        }
        if (ExportLocation != null && isExportLocationValid)
        {
            foreach (GameObject fillOut in ObjectsToID)
            {
                string assetPath = AssetDatabase.GetAssetPath(fillOut);

                //string Path = AssetDatabase.GetAssetPath(fillOut) + "OID " + fillOut.name;
                string Path = ExportLocation + "OID " + fillOut.name + ".asset";
                // if (!CreateAtObjectLocation)
                // {
                //      Path = ExportLocation + "OID " + fillOut.name;
                //  }
                FVRObject IDObject = ScriptableObject.CreateInstance<FVRObject>();
                AssetDatabase.CreateAsset(IDObject, Path);
                string itemID = fillOut.name;
                if (typeOfAppend == AppendType.Suffix)
                {
                    itemID = fillOut.name + "." + customAppend;
                }
                else if (typeOfAppend == AppendType.Prefix)
                {
                    itemID = customAppend + "." + fillOut.name;
                }

                IDObject.m_anvilPrefab.AssetName = assetPath;
                IDObject.Category = Category;
                IDObject.ItemID = itemID;
                IDObject.SpawnedFromId = itemID;
                IDObject.DisplayName = fillOut.name;
                IDObject.TagEra = Era;
                IDObject.TagSet = Set; /*
            IDObject.TagFirearmSize = FirearmSize;
            IDObject.TagFirearmAction = FirearmAction;
            IDObject.TagFirearmRoundPower = RoundPower;
            IDObject.TagFirearmFirstYear = FirstYear;
            IDObject.TagFirearmFiringModes = firingMode;
            IDObject.TagFirearmFeedOption = FeedOptions;
            IDObject.TagFirearmMounts = FirearmMounts; */
                IDObject.TagAttachmentMount = AttachmentMounts;
                IDObject.TagAttachmentFeature = AttachmentFeature;
                /* IDObject.TagMeleeStyle =
                   IDObject.TagPowerupType =
                   IDObject.TagThrownType =
                   IDObject.TagThrownDamageType = 
                   IDObject.RoundType = */
                if (WillSpawnInTakeAndHold)
                {
                    IDObject.OSple = true;
                }
                else
                {
                    IDObject.OSple = false;
                }
            }


        }
    }

    public enum AppendType
    {
        Suffix = 0,
        Prefix = 1,
        No_Custom_String = 2
    }
}
