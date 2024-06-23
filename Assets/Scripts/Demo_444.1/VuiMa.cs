using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cysharp.Threading.Tasks;

public class DatDaiChoVui : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MoveGameObject(() =>
        {
            Debug.Log("Callback");
        });

        //demo multi thread 1
        Debug.Log("Start call count down");
        StartCoroutine(CountDown());
        Debug.Log("End call count down");

        //demo multi thread 2
        MultiThread02();
    }


    private void MultiThread02()
    {

    }

    private async UniTask TaskA(String log, int delay)
    {
        Debug.Log($"Task Start {log}");
        await UniTask.Delay(delay);
        Debug.Log($"Task Done{log}");
    }


    private IEnumerator CountDown()
    {
        Debug.Log("Start Count down");
        int countTime = 3;
        for (int i = 0; i < countTime; i++)
        {
            yield return new WaitForSeconds(1);
        }
        Debug.Log("End Count down");
    }
    // Update is called once per frame

    private void MoveGameObject(Action callback)
    {
        Debug.Log("MoveGameObject");
        callback?.Invoke();
    }

}