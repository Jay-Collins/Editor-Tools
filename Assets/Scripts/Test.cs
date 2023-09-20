using Scriptable_Object_Scripts;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private Tool _tool;
    private SpriteRenderer _spriteRenderer;
    
    private void OnEnable()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _spriteRenderer.sprite = _tool.toolIconRank1;
    }
}
