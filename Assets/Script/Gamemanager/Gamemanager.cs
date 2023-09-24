using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Gamemanager : MonoBehaviour
{
    static public bool IsFighting = true;
    const string GameManagerKey = "GameManager";
    static public List<GameObject> PlayerTeam = new List<GameObject>();
    static public List<GameObject> EnemyTeam = new List<GameObject>();
    static public List<GameObject> CardBag = new List<GameObject>();//������gameobject���

    // Start is called before the first frame update
    private void Awake()
    {
        //DontDestroyOnLoad(this);      
    }
    void Start()
    {
        Debug.Log("����");
        //GameObject[] ITEMs = GameObject.FindGameObjectsWithTag("ITEM");
        GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");
        GameObject[] Enemys = GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log("����2");
        if (Players.Length == 0)
        {
            Debug.Log("û�ҵ�");
        }
        foreach (GameObject p in Players)
        {
            PlayerTeam.Add(p);
        }
        /*foreach (GameObject p in ITEMs)
        {
            ItemBag.Add(p);
            Debug.Log("NMSL");
        }*/
        foreach (GameObject e in Enemys)
            EnemyTeam.Add(e);
    }

    //[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]//��ʼ�� 
    static void InstantiateGameManager()
    {
        Addressables.InstantiateAsync(GameManagerKey).Completed += operationHandle =>
        {
            //DontDestroyOnLoad(operationHandle.Result);
        };
    }
    void Update()
    {

    }
}
