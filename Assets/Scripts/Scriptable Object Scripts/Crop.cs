using UnityEngine;

namespace Scriptable_Object_Scripts
{
    public class Crop : ScriptableObject
    {
        public string cropName;
        
        public Sprite cropStage1Sprite;
        public Sprite cropStage2Sprite;
        public Sprite cropStage3Sprite;
        public Sprite cropStage4Sprite;
        
        public Texture2D cropStage1Texture2D;
        public float cropStage1PixelsPerUnit;
        public Rect cropStage1Rect;
        
        public Texture2D cropStage2Texture2D;
        public float cropStage2PixelsPerUnit;
        public Rect cropStage2Rect;
        
        public Texture2D cropStage3Texture2D;
        public float cropStage3PixelsPerUnit;
        public Rect cropStage3Rect;
        
        public Texture2D cropStage4Texture2D;
        public float cropStage4PixelsPerUnit;
        public Rect cropStage4Rect;
        
        public int itemYield;
        public int seedDays;
        public int stage1Days;
        public int stage2Days;
        public int stage3Days;
        
        public int numberOfHarvests;

        public Crop itemScriptableObject;
        
        private void OnEnable()
        {
            cropStage1Sprite = CreateSprite(cropStage1Rect, cropStage1PixelsPerUnit, cropStage1Texture2D);
            cropStage2Sprite = CreateSprite(cropStage2Rect, cropStage2PixelsPerUnit, cropStage2Texture2D);
            cropStage3Sprite = CreateSprite(cropStage3Rect, cropStage3PixelsPerUnit, cropStage3Texture2D);
            cropStage4Sprite = CreateSprite(cropStage4Rect, cropStage4PixelsPerUnit, cropStage4Texture2D);
        }

        private Sprite CreateSprite(Rect rect, float pixelsPerUnit, Texture2D spriteTexture2D)
        {
            return Sprite.Create(spriteTexture2D, rect, new Vector2(0.5f, 0.5f), pixelsPerUnit);
        }
    }
}
