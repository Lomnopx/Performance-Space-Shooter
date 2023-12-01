using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetResulution : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int Resulutionx= 640, Resulutiony= 480;
    void Start()
    {
        // Switch to 640 x 480 full-screen at 60 hz
        Screen.SetResolution(Resulutionx, Resulutiony, FullScreenMode.ExclusiveFullScreen, new RefreshRate() { numerator = 60, denominator = 1 });
    }
}
