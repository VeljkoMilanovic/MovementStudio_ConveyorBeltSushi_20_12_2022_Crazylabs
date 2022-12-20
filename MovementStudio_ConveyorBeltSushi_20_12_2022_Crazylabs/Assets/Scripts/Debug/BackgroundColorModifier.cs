using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundColorModifier : MonoBehaviour
{
    public Camera firstCamera;
    public Camera secondCamera;
    public Slider hue;
    public Slider saturation;
    public Slider value;
    // Start is called before the first frame update
    public void OnEdit()
    {
        Color color1;
        Color color2;

        color1 = Color.HSVToRGB(hue.value, saturation.value, value.value);
        color2 = Color.HSVToRGB(hue.value, saturation.value, value.value);

        firstCamera.backgroundColor = color1;
        secondCamera.backgroundColor = color2;
    }
}
