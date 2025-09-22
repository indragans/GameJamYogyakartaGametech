using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    

    [SerializeField]
    private PlayerHealth player;

    [SerializeField]
    private RectTransform barReact;

    [SerializeField]
    private RectMask2D mask;

    private float maxRightMask;
    private float initialRightMask;
    private void Start()
    {
        maxRightMask = barReact.rect.width - mask.padding.x - mask.padding.z;
        initialRightMask = mask.padding.z;
        
    }

    public void SetValue(float newValue)
    {
        var targetWidth = newValue * maxRightMask;
        var newRightMask = maxRightMask + initialRightMask - targetWidth;
        var padding = mask.padding;
        padding.z = newRightMask;
        mask.padding = padding;
    }

    void Update()
    {
        if (player != null)
        {
            float percent = (float)player.currentHealth / player.maxHealth;
            SetValue(percent);
        }
    }
}
