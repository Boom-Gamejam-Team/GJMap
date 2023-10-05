using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TylValue : MonoBehaviour
{
    public Slider slider;

    //暴虐值初始
    public void SetCurrentTValue(float currentTValue)
    {
        GeneralData.instance.generalData.tValue= currentTValue;
        slider.value = currentTValue;
    }
    //暴虐值最大
    public void SetMaxTValue(float maxTValue)
    {
        slider.maxValue= maxTValue;
    }
}
