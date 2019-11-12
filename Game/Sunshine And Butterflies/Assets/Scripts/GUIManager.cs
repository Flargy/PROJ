using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour
{


    public void PlayButton()
    {
        Application.LoadLevel("Eku_Test");
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
