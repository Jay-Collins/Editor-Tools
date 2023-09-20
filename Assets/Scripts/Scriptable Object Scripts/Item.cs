using UnityEngine;

namespace Scriptable_Object_Scripts
{
    public class Item : ScriptableObject
    {
        public string itemName;
        public string description;
        public int itemID;
        public int buyValue;
        public int sellValue;
        public int energyRestored;
        
        public Sprite itemIcon;
        
        public Texture2D itemIconTexture2D;
        public float itemIconPixelsPerUnit;
        public Rect itemIconRect;
        
        private void OnEnable()
        {
            itemIcon = CreateSprite(itemIconRect, itemIconPixelsPerUnit, itemIconTexture2D);
        }
        
        private Sprite CreateSprite(Rect rect, float pixelsPerUnit, Texture2D spriteTexture2D)
        {
            return Sprite.Create(spriteTexture2D, rect, new Vector2(0.5f, 0.5f), pixelsPerUnit);
        }
    }
}
