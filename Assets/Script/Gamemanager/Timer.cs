using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Timer
{
    public float TimeTOP;
    public float timeElapsed = 0f;
    public bool isRunning = false;

    void Update()
    {
        if (isRunning)
        {
            timeElapsed += Time.deltaTime;
            Debug.Log("���ڼ�ʱ");
        }
    }

    public void StartTimer()
    {
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public void ResetTimer()
    {
        timeElapsed = 0f;
    }
    public IEnumerator TimeFunc(float TimeCount)
    {

        yield return new WaitForSeconds(TimeCount);//��ÿ֡update֮����еȴ�һ��
        yield return true;
        yield break;
    }
}

