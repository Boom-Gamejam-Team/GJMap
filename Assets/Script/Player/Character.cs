using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEditor.Progress;

public class Character : MonoBehaviour, IComparable<Character>, IComparer<Character>
{
    Vector3 Initialpos;
    public Attribute Attribute;
    static public bool PlayerAction;
    public bool ImAction = false;
    //public UnityEngine.UI.Button AtkButton, SkillButton, ObjButton, SpecialButton, SkipButton, RunButton;
    CharacterAction CharacterAction = new CharacterAction();
    bool StartMoved, WantMoved, BackMoved, StartMoving, BackMoving;
    Timer Timer = new Timer();
    bool isTiming, Timeover, StartTimed, ImSpeeding, ISInitialized;
    float Timetop = -1f;
    //public GameObject UI, Scroll_UI;
    private GameObject TargetOBJE;
    static public bool ImChoosingEnemy, ImChoosingItem;
    private float TempSpeed;
    private int ACTION_SKILL;
    public UnityEngine.UI.Button ItemButton;
    bool isinitialed = false;
    // Start is called before the first frame update
    void Start()
    {
        StartMoved = false;
        StartTimed = true;
        Timer = new Timer();
        //UI = this.transform.GetChild(0).gameObject;
        //UI.SetActive(false);
        ISInitialized = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (this.gameObject.tag == "Player")
        {
            if (!ImAction)//该人物不在回合中
            {
                Initialpos = this.transform.position;
                if (!isinitialed)
                {
                    isinitialed = true;
                }
            }
            if (PlayerAction && ImAction)//人物回合中 
            {
                ACTIONSTART();
                //ACTIONSKI(ACTION_SKILL);
                if (ImChoosingEnemy)//在自己回合时选择物体
                {
                    TargetOBJE = Turn.TargetOBJ;
                }
                Timing(Timetop);
            }
        }
    }
    public int CompareTo(Character cHaracter)//两个比较函数
    {
        return (Attribute.currentSpeed + TempSpeed).CompareTo(cHaracter.Attribute.currentSpeed + cHaracter.TempSpeed);
    }
    public int Compare(Character Obj1, Character Obj2)//两个比较函数
    {
        return (Obj1.Attribute.currentSpeed + Obj1.TempSpeed).CompareTo(Obj2.Attribute.currentSpeed + Obj2.TempSpeed);
    }
    public void WantMove(Vector3 TargetPosition, bool WanttoDO, float StayTime, bool WanttoBack, Vector3 BackPosition)//传入一个位置，物体，是否要做什么事情（写在CharacterAction）里, 在这里待的时间 ，是否返回，返回的位置,在目标点多远处停下
    {
        if (StartMoved)
        {
            //UI.SetActive(false);
            CharacterAction.isOVER = false;
            StartMoved = false;
            CharacterAction.isArrivedObj = false;
            CharacterAction.isArrivedPos = false;
            StartMoving = true;
            BackMoving = false;

        }
        if (!CharacterAction.isOVER && StartMoving && !BackMoving)
        {
            StartCoroutine(CharacterAction.MoveTo(this.gameObject, TargetPosition, WanttoDO, StayTime, 2f));
            StartMoving = !CharacterAction.isWating;
        }
        if (WanttoBack)
        {
            if (BackMoved && CharacterAction.isOVER)
            {
                BackMoving = true;
                BackMoved = false;
                CharacterAction.isOVER = false;
                CharacterAction.isArrivedObj = false;
                CharacterAction.isArrivedPos = false;
            }
            if (!CharacterAction.isOVER && !BackMoved && BackMoving)
            {
                StartCoroutine(CharacterAction.MoveTo(this.gameObject, BackPosition, false, 0f, 0f));
                BackMoving = !CharacterAction.isWating;
            }
        }
        else
        {
            BackMoved = false;
        }
        if (CharacterAction.isOVER && (CharacterAction.isArrivedObj || CharacterAction.isArrivedPos) && !StartMoving && !BackMoving)
        {
            this.transform.position = Initialpos;//这个应该用移动来返回
            ACTIONOVER();
        }
    }
    public void Timing(float Timed)// 不知道什么时候用得上
    {
        if (Timed > 0)
        {
            if (StartTimed)
            {
                Timer.StartTimer();
                StartTimed = false;
                isTiming = true;
                Timeover = false;
                Debug.Log("开始计时");
            }
            if (isTiming && !Timeover)
            {
                Timer.timeElapsed += Time.deltaTime;
                Debug.Log("正在计时");
            }
            if (Timer.timeElapsed >= Timed)
            {
                Timer.StopTimer();
                Timer.ResetTimer();
                Timeover = true;
                isTiming = false;
                StartTimed = true;
                Debug.Log("计时完毕");
                Timetop = -1F;
            }
        }
    }
   /* private void ACTIONSKI(int ACTION_SKIL)//所有的行动在这里面 
    {
        switch (ACTION_SKIL)
        {
            case 0://攻击
                if (WantMoved)
                    WantMove(TargetOBJE.transform.position, true, 3f, true, Initialpos);
                break;
            case 1://技能
                break;
            case 2://物品
                if (ImChoosingItem)
                {
                    Scroll_UI.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        ImChoosingItem = false;
                        Scroll_UI.SetActive(false);
                        ACTION_SKILL = -1;
                    }
                }
                break;
            case 3://逃跑
                break;
            case 4://跳过           
                ACTIONOVER();
                break;
            case -1://默认状态
                break;
        }
    }*/
    public void ACTIONOVER()
    {
        PlayerAction = false;
        ImAction = false;
        ACTION_SKILL = -1;
        WantMoved = false;
        Timetop = -1F;
        ImChoosingEnemy = false;
        ISInitialized = true;
        //UI.SetActive(false);
    }
    private void ACTIONSTART()//回合开始时需要做
    {
        if (ISInitialized)
        {
            //Scroll_UI.SetActive(false);
            ImChoosingEnemy = true;
            ISInitialized = false;
            //UI.SetActive(true);
            if (ImSpeeding && TempSpeed > 0)
            {
                ImSpeeding = false;
                TempSpeed = 0;
            }
            ACTION_SKILL = -1;
            WantMoved = false;
        }
    }
    public int PointCompare(int Bottom, int Top)
    {
        int Point = 0;
        System.Random rd = new System.Random();
        Point = rd.Next(Bottom, Top);
        return Point;
    }
    private void ItemInitial()
    {
        foreach (var Temp in Gamemanager.CardBag)
        {
            Debug.Log(Temp.name);
            if (!Temp.GetComponent<Card>().IsInitialed)
            {
                Temp.GetComponent<Card>().SetMark(true);
                UnityEngine.UI.Button ITEMBU = Instantiate(ItemButton);
               // ITEMBU.transform.SetParent(Scroll_UI.transform.GetChild(0).GetChild(0).transform, false);
                ITEMBU.onClick.AddListener(Temp.GetComponent<Card>().UseThis);
            }
        }
    }
}

