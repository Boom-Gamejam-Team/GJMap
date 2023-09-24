using System.Collections.Generic;
using System.Linq;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Turn : MonoBehaviour
{
    private static Turn Ins_Turn;
    public static Turn This_Turn
    {
        get
        {
            return Ins_Turn;
        }
    }
    //数据
    static public List<Character> GameTurn = new List<Character>();
    bool Inthisturn = false;
    static public GameObject TargetOBJ;
    int ChooseNum = 0;
    public Image UIChoose;
    static public Camera MainCamera;
    static Vector3 Center = new Vector3(Screen.width / 2, Screen.height / 2, 0);
    public GameObject Test;
    public Character ThisTurn;
    public Button ItemButton;
    bool Initial = false;
    // Start is called before the first frame update
    void Start()
    {
        MainCamera = FindObjectOfType<Camera>();
        Center = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ins_Turn = this;
    }
    private void Awake()
    {

    }
    void Initialize()
    {
        //显示战斗UI

        //卡牌初始化
        FightCardManager.instance.FightInit();
        //藏品初始化

        //敌人玩家位置初始化
        TurnInitial();

        Initial = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Gamemanager.IsFighting)
        {            
            if(!Initial)
            {
                Initialize();
            }
            //以下为战斗进行的代码
            if (!Inthisturn)
            {              
                TurnIn();
            }
            if (!Character.PlayerAction)
            {
                Turning();
            }
            if (Character.PlayerAction)
            {
                if (Character.ImChoosingEnemy)//选择
                    ChooseTarget();
                else UIChoose.gameObject.SetActive(false);
            }
        }
    }
    public void Turning()
    {
        ThisTurn = TurnChoose();
        if (ThisTurn == null) ;
        else
        {
            if (ThisTurn.tag == "Player")
            {
                Character.PlayerAction = true;
                ThisTurn.ImAction = true;
            }
            GameObject ThisObj = ThisTurn.gameObject;
            Debug.Log(ThisTurn.Attribute.Name);
        }
    }
    public void TurnIn()//用于给回合初始化
    {
        GetData(Gamemanager.PlayerTeam, GameTurn);
        GetData(Gamemanager.EnemyTeam, GameTurn);
        GameTurn.Sort();
        GameTurn.Reverse();
        int a = GameTurn.Count();
        Debug.Log(a);
        Inthisturn = true;
    }
    public Character TurnChoose()//用于进行回合
    {
        if (GameTurn.Count == 0)
        {
            Inthisturn = false;
            return null;
        }
        else
        {
            Character ThisTurn = GameTurn[0];
            GameTurn.Remove(ThisTurn);
            Debug.Log(ThisTurn.name);
            return ThisTurn;
        }
    }
    static public void GetData(List<GameObject> Obj, List<Character> Data)//用于得到Obj的属性
    {

        foreach (GameObject Temp in Obj)
        {
            Character player = Temp.GetComponent<Character>();
            Data.Add(player);
        }
    }
    void ChooseTarget()
    {
        UIChoose.gameObject.SetActive(true);
        if (Character.PlayerAction)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                ChooseNum = (ChooseNum + 1) % Gamemanager.EnemyTeam.Count;
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                ChooseNum = (ChooseNum + Gamemanager.EnemyTeam.Count - 1) % Gamemanager.EnemyTeam.Count;
            }
            TargetOBJ = Gamemanager.EnemyTeam[ChooseNum];
            Vector3 UITransform = MainCamera.WorldToScreenPoint(TargetOBJ.transform.position);
            Vector3 NewUITransform = new Vector3(UITransform.x, UITransform.y, UITransform.z) + Vector3.left * 100F;
            UIChoose.transform.position = NewUITransform;
        }
    }
    void TurnInitial()
    {
        int temp = 0;
        foreach (GameObject o in Gamemanager.PlayerTeam)
        {
            temp++;
            Ray ray = MainCamera.ScreenPointToRay(Center + new Vector3(Screen.width * 0.1f, Screen.height * -0.1f, 0f) * temp);
            RaycastHit Hit;
            var Size = o.transform.GetComponent<MeshFilter>().mesh.bounds.size;

            if (Physics.Raycast(ray, out Hit))
            {
                o.transform.position = Hit.point + new Vector3(0, Size.y * 0.5f, 0);
            }
        }
        ThisTurn = null;
    }

}
