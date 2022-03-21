using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using FistVR;
using OtherLoader;


[CreateAssetMenu(fileName = "OIDAutoComplete", menuName = "Object IDs/AutoComplete", order = 1)]
public class OIDAutoComplete : ScriptableObject
{

    public List<GameObject> ObjectsToID;
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
    [Header("The path Starts with Assets/ and ends with / after the folder location you want the assets to export into")]
    public string ExportLocation;
    [Tooltip("If this bool is checked it will create an FVRObjectID in the folder of the gameobject")]
    // public bool CreateAtObjectLocation;
    public bool WillSpawnInTakeAndHold = true;
    //[Tooltip("This is the path that the FVRObjectID will be created at if you do not have 'CreateAtObjectLocation' checked")]
    [Header("Spawner Entry Stuff")]
    public bool UsesCustomPath = false;
    public string CustomPath;
    public ItemSpawnerV2.PageMode MainCategory;
    public ItemSpawnerID.ESubCategory SubCategory;
    public bool IsDisplayedInMainEntry = true;
    public List<string> ModTags;
    public List<string> TutorialBlockIds;
    public bool UsesLargeSpawnPad = false;
    public bool IsReward = false;
    [Header("Prefab Camera Setup stuff")]
    public bool setsSprites = false;
    [Header("This is the path you put in the Icon Camera")]
    public string PathtoImage;

    // public Camera IconCamera;
    //[HideInInspector]
    //public static IconCamera Camera;
    // public bool TakeIconImages = false;    
    // public Transform prefabLocation;
    [ContextMenu("AutoFillItemIDs")]
    public void AutoFillItemIDs()
    {
        //Debug.Log("pressed");
        char lastCharOfExportLocation;
        bool isExportLocationValid = false;
        lastCharOfExportLocation = ExportLocation[ExportLocation.Length - 1];
        if (lastCharOfExportLocation == '/')
        {
            isExportLocationValid = true;
        }
        else
        {
            isExportLocationValid = false;
            Debug.Log("You need to end your file path with a /");
        }
        if (ExportLocation != null && isExportLocationValid)
        {
            foreach (GameObject fillOut in ObjectsToID)
            {
                fillOutTheID(fillOut);
                /*string assetPath = AssetDatabase.GetAssetPath(fillOut);

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
                IDObject.TagSet = Set;
                IDObject.TagFirearmSize = FirearmSize;
                IDObject.TagFirearmAction = FirearmAction;
                IDObject.TagFirearmRoundPower = RoundPower;
                IDObject.TagFirearmCountryOfOrigin = CountryOfOrigin;
                IDObject.TagFirearmFirstYear = FirstYear;
                IDObject.TagFirearmFiringModes = firingMode;
                IDObject.TagFirearmFeedOption = FeedOptions;
                IDObject.TagFirearmMounts = FirearmMounts;
                IDObject.TagAttachmentMount = AttachmentMounts;
                IDObject.TagAttachmentFeature = AttachmentFeature; /*
                IDObject.TagMeleeStyle = MeleeStyle;
                IDObject.TagPowerupType = PowerupType;
                IDObject.TagThrownType = ThrownType;
                IDObject.TagThrownDamageType = ThrownDamageType;
                IDObject.RoundType = RoundType; 
                if (WillSpawnInTakeAndHold)
                {
                    IDObject.OSple = true;
                }
                else
                {
                    IDObject.OSple = false;
                }
                 FVRPhysicalObject WrappableObject = fillOut.GetComponent(typeof(FVRPhysicalObject))as FVRPhysicalObject;
                if (WrappableObject != null)
                {
                    WrappableObject.ObjectWrapper = IDObject;
                }*/

            }


        }
        AssetDatabase.SaveAssets();

    }
    [ContextMenu("FillIDsANDEntries")]
    public void FillIDsANDEntries()
    {
        //Debug.Log("pressed");
        char lastCharOfExportLocation;
        bool isExportLocationValid = false;
        lastCharOfExportLocation = ExportLocation[ExportLocation.Length - 1];
        if (lastCharOfExportLocation == '/')
        {
            isExportLocationValid = true;
        }
        else
        {
            isExportLocationValid = false;
            Debug.Log("You need to end your file path with a /");
        }
        if (ExportLocation != null && isExportLocationValid)
        {
            //Camera prefabcam = Instantiate(IconCamera, new Vector3(200, 200, 200), Quaternion.identity);
            foreach (GameObject fillOut in ObjectsToID)//OID Stuff starts here
            {

                FVRObject IDObject = fillOutTheID(fillOut);
                /* string assetPath = AssetDatabase.GetAssetPath(fillOut);

                 //string Path = AssetDatabase.GetAssetPath(fillOut) + "OID " + fillOut.name;
                 string Path = ExportLocation + "OID " + fillOut.name + ".asset";
                 string EntryPath = ExportLocation + "ISE " + fillOut.name + ".asset";
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
                 IDObject.TagSet = Set;a
                 IDObject.TagFirearmSize = FirearmSize;
                 IDObject.TagFirearmAction = FirearmAction;
                 IDObject.TagFirearmRoundPower = RoundPower;
                 IDObject.TagFirearmCountryOfOrigin = CountryOfOrigin;
                 IDObject.TagFirearmFirstYear = FirstYear;
                 IDObject.TagFirearmFiringModes = firingMode;
                 IDObject.TagFirearmFeedOption = FeedOptions;
                 IDObject.TagFirearmMounts = FirearmMounts;
                 IDObject.TagAttachmentMount = AttachmentMounts;
                 IDObject.TagAttachmentFeature = AttachmentFeature;
                 /* IDObject.TagMeleeStyle = MeleeStyle;
                    IDObject.TagPowerupType = PowerupType;
                    IDObject.TagThrownType = ThrownType;
                    IDObject.TagThrownDamageType = 
                    IDObject.RoundType = 
                 if (WillSpawnInTakeAndHold)
                 {
                     IDObject.OSple = true;
                 }
                 else
                 {
                     IDObject.OSple = false;
                 }*/
                string Path = ExportLocation + "OID " + fillOut.name + ".asset";
                string EntryPath = ExportLocation + "ISE " + fillOut.name + ".asset";
                ItemSpawnerEntry EntryObject = ScriptableObject.CreateInstance<ItemSpawnerEntry>();//ISID stuff begins here

                AssetDatabase.CreateAsset(EntryObject, EntryPath);
                EditorUtility.SetDirty(EntryObject);
                EntryObject.MainObjectID = IDObject.ItemID;
                if (UsesCustomPath)
                {
                    EntryObject.EntryPath = CustomPath + IDObject.ItemID;
                    EntryObject.Page = MainCategory;
                    EntryObject.SubCategory = ItemSpawnerID.ESubCategory.None;
                }
                else
                {
                    EntryObject.Page = MainCategory;
                    EntryObject.SubCategory = SubCategory;
                }
                EntryObject.DisplayName = fillOut.name;
                EntryObject.ModTags = ModTags;
                EntryObject.TutorialBlockIDs = TutorialBlockIds;
                EntryObject.UsesLargeSpawnPad = UsesLargeSpawnPad;
                EntryObject.IsReward = IsReward;
                EntryObject.IsDisplayedInMainEntry = IsDisplayedInMainEntry;
                string IconPath = "Assets/" + PathtoImage + '/' + fillOut.name + "_icon" + ".png";
                EntryObject.EntryIcon = (Sprite)AssetDatabase.LoadAssetAtPath(IconPath, typeof(Sprite));
                //icon camera stuff begins here
                /*if (setsSprites)
                 {                   
                     EntryObject.EntryIcon = (Sprite)AssetDatabase.LoadAssetAtPath(IconPath, typeof(Sprite));
                 }*/

            }
            //Destroy(prefabcam);

        }
        AssetDatabase.SaveAssets();

    }

    public enum AppendType
    {
        Suffix = 0,
        Prefix = 1,
        No_Custom_String = 2
    }
    public FVRObject fillOutTheID(GameObject fillOut)
    {
        string assetPath = AssetDatabase.GetAssetPath(fillOut);

        string Path = ExportLocation + "OID " + fillOut.name + ".asset";

        FVRObject IDObject = ScriptableObject.CreateInstance<FVRObject>();
        AssetDatabase.CreateAsset(IDObject, Path);
        EditorUtility.SetDirty(IDObject);

        //EditorUtility.SetDirty(IDObject);

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
        IDObject.TagSet = Set;
        IDObject.TagFirearmSize = FirearmSize;
        IDObject.TagFirearmAction = FirearmAction;
        IDObject.TagFirearmRoundPower = RoundPower;
        IDObject.TagFirearmCountryOfOrigin = CountryOfOrigin;
        IDObject.TagFirearmFirstYear = FirstYear;
        IDObject.TagFirearmFiringModes = firingMode;
        IDObject.TagFirearmFeedOption = FeedOptions;
        IDObject.TagFirearmMounts = FirearmMounts;
        IDObject.TagAttachmentMount = AttachmentMounts;
        IDObject.TagAttachmentFeature = AttachmentFeature; /*
                IDObject.TagMeleeStyle = MeleeStyle;
                IDObject.TagPowerupType = PowerupType;
                IDObject.TagThrownType = ThrownType;
                IDObject.TagThrownDamageType = ThrownDamageType;
                IDObject.RoundType = RoundType; */
        if (WillSpawnInTakeAndHold)
        {
            IDObject.OSple = true;
        }
        else
        {
            IDObject.OSple = false;
        }
        FVRPhysicalObject WrappableObject = fillOut.GetComponent(typeof(FVRPhysicalObject)) as FVRPhysicalObject;
        if (WrappableObject != null)
        {
            WrappableObject.ObjectWrapper = IDObject;
            EditorUtility.SetDirty(WrappableObject);
        }


        
        return IDObject;

    }
}
