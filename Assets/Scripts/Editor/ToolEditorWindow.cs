using UnityEditor;
using UnityEngine;
using Tool = Scriptable_Object_Scripts.Tool;

namespace Editor
{
    public class ToolEditorWindow : EditorWindow
    {
        private Tool _tool;
        private bool _loaded;
        
        [MenuItem("Tools/Tool Editor")]
        private static void ShowToolEditorWindow()
        {
            GetWindow<ToolEditorWindow>("Tool Editor");
        }

        private void OnEnable()
        {
            // loads the settings data when the window is enabled
            _tool = CreateInstance<Tool>();
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Edit Existing Tool ScriptableObject"))
            {
                _loaded = true;
                LoadExistingToolScriptableObject();
            }

            if (GUILayout.Button("Reset Fields"))
            {
                _loaded = false;
                _tool = CreateInstance<Tool>();
            }
            EditorGUILayout.Separator();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Tool Name", GUILayout.Width(80f));
            _tool.toolName = EditorGUILayout.TextField(_tool.toolName);
            GUILayout.EndHorizontal();
            EditorGUILayout.Separator();
            
            GUILayout.BeginHorizontal();
            GUILayout.Label("Tool ID", GUILayout.Width(80f));
            _tool.toolID = EditorGUILayout.IntField(_tool.toolID, GUILayout.Width(40f));
            GUILayout.EndHorizontal();
            EditorGUILayout.Separator();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Tool Icon Rank 1", GUILayout.Width(110f));
            _tool.toolIconRank1 = (Sprite)EditorGUILayout.ObjectField(_tool.toolIconRank1, typeof(Sprite), false, GUILayout.Width(40), GUILayout.Height(40));
            if (_tool.toolIconRank1 != null)
            {
                _tool.rank1ToolIconRect = _tool.toolIconRank1.rect;
                _tool.rank1ToolIconPixelsPerUnit = _tool.toolIconRank1.pixelsPerUnit;
                _tool.rank1ToolIconTexture2D = _tool.toolIconRank1.texture;
            }
            GUILayout.EndHorizontal();
            EditorGUILayout.Separator();
            
            GUILayout.BeginHorizontal();
            GUILayout.Label("Tool Icon Rank 2", GUILayout.Width(110f));
            _tool.toolIconRank2 = (Sprite)EditorGUILayout.ObjectField(_tool.toolIconRank2, typeof(Sprite), false, GUILayout.Width(40), GUILayout.Height(40));
            if (_tool.toolIconRank2 != null)
            {
                _tool.rank2ToolIconRect = _tool.toolIconRank2.rect;
                _tool.rank2ToolIconPixelsPerUnit = _tool.toolIconRank2.pixelsPerUnit;
                _tool.rank2ToolIconTexture2D = _tool.toolIconRank2.texture;
            }
            GUILayout.EndHorizontal();
            EditorGUILayout.Separator();
            
            GUILayout.BeginHorizontal();
            GUILayout.Label("Tool Icon Rank 3", GUILayout.Width(110f));
            _tool.toolIconRank3 = (Sprite)EditorGUILayout.ObjectField(_tool.toolIconRank3, typeof(Sprite), false, GUILayout.Width(40), GUILayout.Height(40));
            if (_tool.toolIconRank3 != null)
            {
                _tool.rank3ToolIconRect = _tool.toolIconRank3.rect;
                _tool.rank3ToolIconPixelsPerUnit = _tool.toolIconRank3.pixelsPerUnit;
                _tool.rank3ToolIconTexture2D = _tool.toolIconRank3.texture;
            }
            GUILayout.EndHorizontal();
            EditorGUILayout.Separator();
            
            GUILayout.BeginHorizontal();
            GUILayout.Label("Tool Icon Rank 4", GUILayout.Width(110f));
            _tool.toolIconRank4 = (Sprite)EditorGUILayout.ObjectField(_tool.toolIconRank4, typeof(Sprite), false, GUILayout.Width(40), GUILayout.Height(40));
            if (_tool.toolIconRank4 != null)
            {
                _tool.rank4ToolIconRect = _tool.toolIconRank4.rect;
                _tool.rank4ToolIconPixelsPerUnit = _tool.toolIconRank4.pixelsPerUnit;
                _tool.rank4ToolIconTexture2D = _tool.toolIconRank4.texture;
            }
            GUILayout.EndHorizontal();
            EditorGUILayout.Separator();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Has Field Pattern", GUILayout.Width(110f));
            _tool.hasFieldPattern = EditorGUILayout.Toggle(_tool.hasFieldPattern, GUILayout.Width(25f));
            EditorGUILayout.HelpBox("The Tool Is Used On Field Tiles", MessageType.Info);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.Separator();

            // field patterns
            if (_tool.hasFieldPattern)
            {
                GUILayout.BeginHorizontal();
                GUILayout.Label("Disjointed Pattern", GUILayout.Width(110f));
                _tool.disjointedPattern = EditorGUILayout.Toggle(_tool.disjointedPattern, GUILayout.Width(25f));
                EditorGUILayout.HelpBox("Offset Pattern In Front Of Player", MessageType.Info);
                GUILayout.EndHorizontal();
                EditorGUILayout.Separator();
                
                GUILayout.Label("Tool Use Grid Pattern", EditorStyles.boldLabel);
                EditorGUILayout.Separator();
    
                // Rank 1
                GUILayout.Label("Rank 1");
                GUILayout.BeginHorizontal();
                GUILayout.Label("X", GUILayout.Width(20f));
                _tool.rank1Pattern.x = Mathf.Max(1, EditorGUILayout.IntField((int) _tool.rank1Pattern.x, GUILayout.Width(40f)));
                
                GUILayout.Label("Y", GUILayout.Width(20f));
                _tool.rank1Pattern.y = Mathf.Max(1,EditorGUILayout.IntField((int) _tool.rank1Pattern.y, GUILayout.Width(40f)));

                if (_tool.rank1Pattern.x % 2 == 0)
                {
                    EditorGUILayout.HelpBox("X Must Be Odd", MessageType.Warning);
                }
                GUILayout.EndHorizontal();
                DrawArrayPattern((int)_tool.rank1Pattern.x, (int)_tool.rank1Pattern.y);
                EditorGUILayout.Separator();

                // Rank 2
                GUILayout.Label("Rank 2");
                GUILayout.BeginHorizontal();
                GUILayout.Label("X", GUILayout.Width(20f));
                _tool.rank2Pattern.x = Mathf.Max(1,EditorGUILayout.IntField((int) _tool.rank2Pattern.x, GUILayout.Width(40f)));
                
                GUILayout.Label("Y", GUILayout.Width(20f));
                _tool.rank2Pattern.y = Mathf.Max(1,EditorGUILayout.IntField((int) _tool.rank2Pattern.y, GUILayout.Width(40f)));

                if (_tool.rank2Pattern.x % 2 == 0)
                {
                    EditorGUILayout.HelpBox("X Must Be Odd", MessageType.Warning);
                }
                GUILayout.EndHorizontal();
                DrawArrayPattern((int)_tool.rank2Pattern.x, (int)_tool.rank2Pattern.y);
                EditorGUILayout.Separator();
                
                // Rank 3
                GUILayout.Label("Rank 3");
                GUILayout.BeginHorizontal();
                GUILayout.Label("X", GUILayout.Width(20f));
                _tool.rank3Pattern.x = Mathf.Max(1,EditorGUILayout.IntField((int) _tool.rank3Pattern.x, GUILayout.Width(40f)));
                
                GUILayout.Label("Y", GUILayout.Width(20f));
                _tool.rank3Pattern.y = Mathf.Max(1,EditorGUILayout.IntField((int) _tool.rank3Pattern.y, GUILayout.Width(40f)));

                if (_tool.rank3Pattern.x % 2 == 0)
                {
                    EditorGUILayout.HelpBox("X Must Be Odd", MessageType.Warning);
                }
                GUILayout.EndHorizontal();
                DrawArrayPattern((int)_tool.rank3Pattern.x, (int)_tool.rank3Pattern.y);
                EditorGUILayout.Separator();
                
                // Rank 4
                GUILayout.Label("Rank 4");
                GUILayout.BeginHorizontal();
                GUILayout.Label("X", GUILayout.Width(20f));
                _tool.rank4Pattern.x = Mathf.Max(1,EditorGUILayout.IntField((int) _tool.rank4Pattern.x, GUILayout.Width(40f)));
                
                GUILayout.Label("Y", GUILayout.Width(20f));
                _tool.rank4Pattern.y = Mathf.Max(1,EditorGUILayout.IntField((int) _tool.rank4Pattern.y, GUILayout.Width(40f)));

                if (_tool.rank4Pattern.x % 2 == 0)
                {
                    EditorGUILayout.HelpBox("X Must Be Odd", MessageType.Warning);
                }
                GUILayout.EndHorizontal();
                DrawArrayPattern((int)_tool.rank4Pattern.x, (int)_tool.rank4Pattern.y);
                EditorGUILayout.Separator();
            }

            if (!_loaded)
            {
                if (GUILayout.Button("Save as new Tool"))
                {
                    SaveAsNewToolScriptableObject();
                }
            }
            else
            {
                if (GUILayout.Button("Save Existing Tool"))
                {
                    SaveLoadedScriptableObject();
                }

                if (GUILayout.Button("Save as new Tool"))
                {
                    SaveAsNewToolScriptableObject();
                }
            }
        }

        private void LoadExistingToolScriptableObject()
        {
            string path = EditorUtility.OpenFilePanelWithFilters("Select Tool", "Assets/Scriptable Objects/Tools",
                new[] { "Tool", "asset" });
            
            if (!string.IsNullOrEmpty(path) && path.StartsWith(Application.dataPath))
            {
                path = "Assets" + path.Substring(Application.dataPath.Length);
                Tool loadedTool = AssetDatabase.LoadAssetAtPath<Tool>(path);
                
                if (loadedTool == null)
                    Debug.Log("Failed to load Tool ScriptableObject from path: " + path);
                if (_tool == null)
                    _tool = CreateInstance<Tool>();
                _tool = Instantiate(loadedTool);
                
                Debug.Log("Loaded existing Tool ScriptableObject: " + _tool.toolName);
            }
        }

        private void SaveAsNewToolScriptableObject()
        {
            string path = EditorUtility.SaveFilePanelInProject("Save Settings", _tool.toolName + "Tool", 
                "asset", "Save settings as a new Tool");

            // null check needed in case user closes save panel without saving
            if (!string.IsNullOrEmpty(path))
            {
                AssetDatabase.CreateAsset(_tool, path);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
                    
                Debug.Log("Saved settings as new Tool Scriptable Object in: " + path);
                Debug.Log(_tool.rank1Pattern);
            }
        }

        private void SaveLoadedScriptableObject()
        {
            EditorUtility.SetDirty(_tool);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            
            Debug.Log("Saved " + _tool.toolName + " settings");
        }
        
        
        private void DrawArrayPattern(int rows, int columns)
        {
            GUILayout.BeginVertical(EditorStyles.helpBox, GUILayout.Width(rows * 20), GUILayout.Height(columns * 20));
            for (int y = 0; y < columns; y++)
            {
                GUILayout.BeginHorizontal();
                for (int x = 0; x < rows; x++)
                {
                    GUILayout.Box("", GUILayout.Width(20), GUILayout.Height(20),GUILayout.ExpandWidth(false));
                }
                GUILayout.EndHorizontal();
            }
            GUILayout.EndVertical();
        }
    }
}
