using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARUIScript : MonoBehaviour
{
    public GameObject ARLookButton;
    public GameObject AR;
    public void OnClickChangeLook()
    {
        Text text = ARLookButton.GetComponent<Text>();
        if (text.text == "Look at Field")
        {
            text.text = "Look at Hand";
            AR.GetComponent<ImageDetectionScript>().SetHandLook();
        }
        else
        {
            text.text = "Look at Field";
            AR.GetComponent<ImageDetectionScript>().SetFieldLook();
        }
    }
}
