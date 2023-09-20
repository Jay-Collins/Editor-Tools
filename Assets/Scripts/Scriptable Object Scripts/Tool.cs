using UnityEngine;

namespace Scriptable_Object_Scripts
{
    public class Tool : ScriptableObject
    {
        public string toolName;
        public int toolID;
        public int rank = 1;
        public bool hasFieldPattern;
        public bool disjointedPattern;
        
        public Sprite toolIconRank1;
        public Sprite toolIconRank2;
        public Sprite toolIconRank3;
        public Sprite toolIconRank4;
        
        public Texture2D rank1ToolIconTexture2D;
        public float rank1ToolIconPixelsPerUnit;
        public Rect rank1ToolIconRect;
        
        public Texture2D rank2ToolIconTexture2D;
        public float rank2ToolIconPixelsPerUnit;
        public Rect rank2ToolIconRect;
        
        public Texture2D rank3ToolIconTexture2D;
        public float rank3ToolIconPixelsPerUnit;
        public Rect rank3ToolIconRect;
        
        public Texture2D rank4ToolIconTexture2D;
        public float rank4ToolIconPixelsPerUnit;
        public Rect rank4ToolIconRect;
        
        public Vector2 rank1Pattern;
        public Vector2 rank2Pattern;
        public Vector2 rank3Pattern;
        public Vector2 rank4Pattern;
        
        private void OnEnable()
        {
            toolIconRank1 = CreateSprite(rank1ToolIconRect, rank1ToolIconPixelsPerUnit, rank1ToolIconTexture2D);
            toolIconRank2 = CreateSprite(rank2ToolIconRect, rank2ToolIconPixelsPerUnit, rank2ToolIconTexture2D);
            toolIconRank3 = CreateSprite(rank3ToolIconRect, rank3ToolIconPixelsPerUnit, rank3ToolIconTexture2D);
            toolIconRank4 = CreateSprite(rank4ToolIconRect, rank4ToolIconPixelsPerUnit, rank4ToolIconTexture2D);
        }
        
        private Sprite CreateSprite(Rect rect, float pixelsPerUnit, Texture2D spriteTexture2D)
        {
            return Sprite.Create(spriteTexture2D, rect, new Vector2(0.5f, 0.5f), pixelsPerUnit);
        }
    }
}
