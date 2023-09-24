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
    static public List<GameObject> CardBag = new List<GameObject>();//卡牌用gameobject存放

    // Start is called before the first frame update
    private void Awake()
    {
        //DontDestroyOnLoad(this);      
    }
    void Start()
    {
        Debug.Log("查找");
        //GameObject[] ITEMs = GameObject.FindGameObjectsWithTag("ITEM");
        GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");
        GameObject[] Enemys = GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log("查找2");
        if (Players.Length == 0)
        {
            Debug.Log("没找到");
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

    //[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]//初始化 
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
