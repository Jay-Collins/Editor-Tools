using Scriptable_Object_Scripts;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class ItemEditorWindow : EditorWindow
    {
        private bool _loaded;
        private Item _item;

        [MenuItem("Tools/Item Editor")]
        private static void ShowItemEditorWindow()
        {
            GetWindow<ItemEditorWindow>("Item Editor");
        }
        
        private void OnEnable()
        {
            _item = CreateInstance<Item>();
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Edit Existing Item ScriptableObject"))
            {
                _loaded = true;
                LoadExistingItemScriptableObject();
            }
            
            if (GUILayout.Button("Reset Fields"))
            {
                _loaded = false;
                _item = CreateInstance<Item>();
            }
            EditorGUILayout.Separator();
            
            GUILayout.BeginHorizontal();
            GUILayout.Label("Item Name", GUILayout.Width(80f));
            _item.itemName = EditorGUILayout.TextField(_item.itemName);
            GUILayout.EndHorizontal();
            EditorGUILayout.Separator();
            
            GUILayout.BeginHorizontal();
            GUILayout.Label("Item ID", GUILayout.Width(80f));
            _item.itemID = EditorGUILayout.IntField(_item.itemID, GUILayout.Width(40f));
            GUILayout.EndHorizontal();
            EditorGUILayout.Separator();
            
            GUILayout.BeginHorizontal();
            GUILayout.Label("Item Icon", GUILayout.Width(80f));
            _item.itemIcon = (Sprite)EditorGUILayout.ObjectField(_item.itemIcon, typeof(Sprite), false, GUILayout.Height(40f), GUILayout.Width(40f));
            if (_item.itemIcon != null)
            {
                _item.itemIconRect = _item.itemIcon.rect;
                _item.itemIconPixelsPerUnit = _item.itemIcon.pixelsPerUnit;
                _item.itemIconTexture2D = _item.itemIcon.texture;
            }
            GUILayout.EndHorizontal();
            EditorGUILayout.Separator();
            
            GUILayout.BeginHorizontal();
            GUILayout.Label("Buy Value", GUILayout.Width(80f));
            _item.buyValue = Mathf.Max(1,EditorGUILayout.IntField(_item.buyValue, GUILayout.Width(40f)));
            GUILayout.EndHorizontal();
            EditorGUILayout.Separator();
            
            GUILayout.BeginHorizontal();
            GUILayout.Label("Sell Value", GUILayout.Width(80f));
            _item.sellValue = Mathf.Max(1,EditorGUILayout.IntField(_item.sellValue, GUILayout.Width(40f)));
            GUILayout.EndHorizontal();
            EditorGUILayout.Separator();
            
            GUILayout.BeginHorizontal();
            GUILayout.Label("Energy", GUILayout.Width(80f));
            _item.energyRestored = EditorGUILayout.IntField(_item.energyRestored, GUILayout.Width(40f));
            EditorGUILayout.HelpBox("The amount of energy eating the item restores. A negative number will remove energy. Leaving the field 0 will make the item inedible.", MessageType.Info);
            GUILayout.EndHorizontal();
            EditorGUILayout.Separator();
            
            GUILayout.Label("Description");
            _item.description = GUILayout.TextArea(_item.description, GUILayout.Height(80f));
            EditorGUILayout.Separator();
            
            if (!_loaded)
            {
                if (GUILayout.Button("Save as new Item"))
                {
                    SaveAsNewItemScriptableObject();
                }
            }
            else
            {
                if (GUILayout.Button("Save Existing Item"))
                {
                    SaveLoadedScriptableObject();
                }

                if (GUILayout.Button("Save as new Item"))
                {
                    SaveAsNewItemScriptableObject();
                }
            }
        }
        
        private void LoadExistingItemScriptableObject()
        {
            string path = EditorUtility.OpenFilePanelWithFilters("Select Item", "Assets/Scriptable Objects/Items", new[] { "Item", "asset" });
            
            if (!string.IsNullOrEmpty(path) && path.StartsWith(Application.dataPath))
            {
                path = "Assets" + path.Substring(Application.dataPath.Length);
                Item loadedItem = AssetDatabase.LoadAssetAtPath<Item>(path);
                
                if (loadedItem == null)
                {
                    Debug.LogError("Failed to load Item ScriptableObject from path: " + path);
                }

                if (_item == null)
                {
                    _item = CreateInstance<Item>();
                }

                _item = Instantiate(loadedItem);
                
                Debug.Log("Loaded existing Item ScriptableObject: " + _item.itemName);
            }
        }

        private void SaveAsNewItemScriptableObject()
        {
            string path = EditorUtility.SaveFilePanelInProject("Save Settings", _item.itemName + "Crop", "asset", "Save settings as new Crop");

            if (!string.IsNullOrEmpty(path))
            {
                AssetDatabase.CreateAsset(_item, path);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
                
                Debug.Log("Saved settings as new Item ScriptableObject in: " + path);
            }
        }

        private void SaveLoadedScriptableObject()
        {
            EditorUtility.SetDirty(_item);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            
            Debug.Log("Saved " + _item.itemName + " settings");
        }
    }
}
