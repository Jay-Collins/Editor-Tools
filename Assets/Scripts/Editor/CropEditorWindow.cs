using Scriptable_Object_Scripts;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class CropEditorWindow : EditorWindow
    {
        private Crop _crop;
        private bool _loaded;

        [MenuItem("Tools/Crop Editor")]
        private static void ShowCropEditorWindow()
        {
            GetWindow<CropEditorWindow>("Crop Editor");
        }

        private void OnEnable()
        {
            // loads the settings data when the window is enabled
            _crop = CreateInstance<Crop>();
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Edit Existing Crop ScriptableObject"))
            {
                _loaded = true;
                LoadExistingCropScriptableObject();
            }

            if (GUILayout.Button("Reset Fields"))
            {
                _loaded = false;
                _crop = CreateInstance<Crop>();
            }
            EditorGUILayout.Separator();
            
            GUILayout.BeginHorizontal();
            GUILayout.Label("Crop Name", GUILayout.Width(80f));
            _crop.cropName = EditorGUILayout.TextField(_crop.cropName);
            GUILayout.EndHorizontal();
            EditorGUILayout.Separator();
            
            GUILayout.BeginHorizontal();
            GUILayout.Label("Item SO", GUILayout.Width(80f));
            _crop.itemScriptableObject = (Crop)EditorGUILayout.ObjectField(_crop.itemScriptableObject, typeof(Crop), false);
            GUILayout.EndHorizontal();
            EditorGUILayout.Separator();
            
            GUILayout.BeginHorizontal();
            GUILayout.Label("Item Yield", GUILayout.Width(80f));
            _crop.itemYield = Mathf.Max(1,EditorGUILayout.IntField(_crop.itemYield, GUILayout.Width(40f)));
            GUILayout.EndHorizontal();
            EditorGUILayout.Separator();
            
            GUILayout.BeginHorizontal();
            GUILayout.Label("Harvests", GUILayout.Width(80f));
            _crop.numberOfHarvests = Mathf.Max(1,EditorGUILayout.IntField(_crop.numberOfHarvests, GUILayout.Width(40f)));
            GUILayout.EndHorizontal();
            EditorGUILayout.Separator();
            
            GUILayout.BeginHorizontal();
            GUILayout.Label("Seed Days", GUILayout.Width(90f));
            _crop.seedDays = Mathf.Max(1,EditorGUILayout.IntField(_crop.seedDays, GUILayout.Width(40f)));
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Stage 1 Sprite", GUILayout.Width(90f));
            _crop.cropStage1Sprite = (Sprite)EditorGUILayout.ObjectField(_crop.cropStage1Sprite, typeof(Sprite), false, GUILayout.Width(40f), GUILayout.Height(40f));
            if (_crop.cropStage1Sprite != null)
            {
                _crop.cropStage1Rect = _crop.cropStage1Sprite.rect;
                _crop.cropStage1PixelsPerUnit = _crop.cropStage1Sprite.pixelsPerUnit;
                _crop.cropStage1Texture2D = _crop.cropStage1Sprite.texture;
            }
            GUILayout.EndHorizontal();
            EditorGUILayout.Separator();
            
            GUILayout.BeginHorizontal();
            GUILayout.Label("Stage 1 Days", GUILayout.Width(90f));
            _crop.stage1Days = Mathf.Max(1,EditorGUILayout.IntField(_crop.stage1Days, GUILayout.Width(40f)));
            GUILayout.EndHorizontal();
            
            GUILayout.BeginHorizontal();
            GUILayout.Label("Stage 2 Sprite", GUILayout.Width(90f));
            _crop.cropStage2Sprite = (Sprite)EditorGUILayout.ObjectField(_crop.cropStage2Sprite, typeof(Sprite), false, GUILayout.Width(40f), GUILayout.Height(40f));
            if (_crop.cropStage2Sprite != null)
            {
                _crop.cropStage2Rect = _crop.cropStage2Sprite.rect;
                _crop.cropStage2PixelsPerUnit = _crop.cropStage2Sprite.pixelsPerUnit;
                _crop.cropStage2Texture2D = _crop.cropStage2Sprite.texture;
            }
            GUILayout.EndHorizontal();
            EditorGUILayout.Separator();
            
            GUILayout.BeginHorizontal();
            GUILayout.Label("Stage 2 Days", GUILayout.Width(90f));
            _crop.stage2Days = Mathf.Max(1,EditorGUILayout.IntField(_crop.stage2Days, GUILayout.Width(40f)));
            GUILayout.EndHorizontal();
            
            GUILayout.BeginHorizontal();
            GUILayout.Label("Stage 3 Sprite", GUILayout.Width(90f));
            _crop.cropStage3Sprite = (Sprite)EditorGUILayout.ObjectField(_crop.cropStage3Sprite, typeof(Sprite), false, GUILayout.Width(40f), GUILayout.Height(40f));
            if (_crop.cropStage3Sprite != null)
            {
                _crop.cropStage3Rect = _crop.cropStage3Sprite.rect;
                _crop.cropStage3PixelsPerUnit = _crop.cropStage3Sprite.pixelsPerUnit;
                _crop.cropStage3Texture2D = _crop.cropStage3Sprite.texture;
            }
            GUILayout.EndHorizontal();
            EditorGUILayout.Separator();
            
            GUILayout.BeginHorizontal();
            GUILayout.Label("Stage 3 Days", GUILayout.Width(90f));
            _crop.stage3Days = Mathf.Max(1,EditorGUILayout.IntField(_crop.stage3Days, GUILayout.Width(40f)));
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Stage 4 Sprite", GUILayout.Width(90f));
            _crop.cropStage4Sprite = (Sprite)EditorGUILayout.ObjectField(_crop.cropStage4Sprite, typeof(Sprite), false, GUILayout.Width(40f), GUILayout.Height(40f));
            if (_crop.cropStage4Sprite != null)
            {
                _crop.cropStage4Rect = _crop.cropStage4Sprite.rect;
                _crop.cropStage4PixelsPerUnit = _crop.cropStage4Sprite.pixelsPerUnit;
                _crop.cropStage4Texture2D = _crop.cropStage4Sprite.texture;
            }
            GUILayout.EndHorizontal();
            EditorGUILayout.Separator();
            
            if (!_loaded)
            {
                if (GUILayout.Button("Save as new Crop"))
                {
                    SaveAsNewCropScriptableObject();
                }
            }
            else
            {
                if (GUILayout.Button("Save Existing Crop"))
                {
                    SaveLoadedScriptableObject();
                }
                
                if (GUILayout.Button("Save as new Crop"))
                {
                    SaveAsNewCropScriptableObject();
                }
            }
            
        }

        private void LoadExistingCropScriptableObject()
        {
            string path = EditorUtility.OpenFilePanelWithFilters("Select Crop", "Assets/Scriptable Objects/Crops", new[] { "Crop", "asset" });
            
            if (!string.IsNullOrEmpty(path) && path.StartsWith(Application.dataPath))
            {
                path = "Assets" + path.Substring(Application.dataPath.Length);
                Crop loadedCrop = AssetDatabase.LoadAssetAtPath<Crop>(path);
                
                if (loadedCrop == null)
                {
                    Debug.LogError("Failed to load Crop ScriptableObject from path: " + path);
                }

                if (_crop == null)
                {
                    _crop = CreateInstance<Crop>();
                }

                _crop = Instantiate(loadedCrop);
                
                Debug.Log("Loaded existing Crop ScriptableObject: " + _crop.cropName);
            }
        }

        private void SaveAsNewCropScriptableObject()
        {
            string path = EditorUtility.SaveFilePanelInProject("Save Settings", _crop.cropName + "Crop", "asset", "Save settings as new Crop");

            if (!string.IsNullOrEmpty(path))
            {
                AssetDatabase.CreateAsset(_crop, path);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
                
                Debug.Log("Saved settings as new Crop ScriptableObject in: " + path);
            }
        }

        private void SaveLoadedScriptableObject()
        {
            EditorUtility.SetDirty(_crop);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            
            Debug.Log("Saved " + _crop.cropName + " settings");
        }
    }
}
