using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillSpriteOverTime : MonoBehaviour
{
    [SerializeField]
    private float fillTime = 1;
    private Image fillImage;

    private void OnEnable()
    {
        if (!fillImage)
            fillImage = GetComponent<Image>();

        fillImage.fillAmount = 1;
    }

    private void Update()
    {
        fillImage.fillAmount -= 1.0f / fillTime * Time.deltaTime;
    }
}
