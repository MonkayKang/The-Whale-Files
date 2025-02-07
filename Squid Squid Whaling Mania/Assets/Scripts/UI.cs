using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Image targetImage;  // the image
    public static float fillAmount = 0f;  // The fill amount (0 to 1)

    // Start is called before the first frame update
    void Start()
    {
        // Set the fill amount of the Image
        targetImage.fillAmount = fillAmount;
    }

    // Update is called once per frame
    void Update()
    {
        targetImage.fillAmount = fillAmount;
    }
}
