using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YesOrNoButton : MonoBehaviour
{
    public Button yesButton;
    public Button noButton;

    public int yesOrNo = 0;


    public void choseYes()
    {
        yesOrNo = 1;
    }
    public void choseNo()
    {
        yesOrNo = 2;
    }


}
