using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour
{


    public void PlayButton()
    {
        Application.LoadLevel("StartTest");
    }

    public void OptionsButton()
    {

    }

    public void BackButton()
    {
        Application.LoadLevel("MenuTest");
    }

    public void ExitButton()
    {
        
    }

}
