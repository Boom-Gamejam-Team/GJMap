using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TylValue : MonoBehaviour
{
    public Slider slider;

    //��Űֵ��ʼ
    public void SetCurrentTValue(float currentTValue)
    {
        GeneralData.instance.generalData.tValue= currentTValue;
        slider.value = currentTValue;
    }
    //��Űֵ���
    public void SetMaxTValue(float maxTValue)
    {
        slider.maxValue= maxTValue;
    }
}
