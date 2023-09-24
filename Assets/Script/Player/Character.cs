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
            if (!ImAction)//�����ﲻ�ڻغ���
            {
                Initialpos = this.transform.position;
                if (!isinitialed)
                {
                    isinitialed = true;
                }
            }
            if (PlayerAction && ImAction)//����غ��� 
            {
                ACTIONSTART();
                //ACTIONSKI(ACTION_SKILL);
                if (ImChoosingEnemy)//���Լ��غ�ʱѡ������
                {
                    TargetOBJE = Turn.TargetOBJ;
                }
                Timing(Timetop);
            }
        }
    }
    public int CompareTo(Character cHaracter)//�����ȽϺ���
    {
        return (Attribute.currentSpeed + TempSpeed).CompareTo(cHaracter.Attribute.currentSpeed + cHaracter.TempSpeed);
    }
    public int Compare(Character Obj1, Character Obj2)//�����ȽϺ���
    {
        return (Obj1.Attribute.currentSpeed + Obj1.TempSpeed).CompareTo(Obj2.Attribute.currentSpeed + Obj2.TempSpeed);
    }
    public void WantMove(Vector3 TargetPosition, bool WanttoDO, float StayTime, bool WanttoBack, Vector3 BackPosition)//����һ��λ�ã����壬�Ƿ�Ҫ��ʲô���飨д��CharacterAction����, ���������ʱ�� ���Ƿ񷵻أ����ص�λ��,��Ŀ����Զ��ͣ��
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
            this.transform.position = Initialpos;//���Ӧ�����ƶ�������
            ACTIONOVER();
        }
    }
    public void Timing(float Timed)// ��֪��ʲôʱ���õ���
    {
        if (Timed > 0)
        {
            if (StartTimed)
            {
                Timer.StartTimer();
                StartTimed = false;
                isTiming = true;
                Timeover = false;
                Debug.Log("��ʼ��ʱ");
            }
            if (isTiming && !Timeover)
            {
                Timer.timeElapsed += Time.deltaTime;
                Debug.Log("���ڼ�ʱ");
            }
            if (Timer.timeElapsed >= Timed)
            {
                Timer.StopTimer();
                Timer.ResetTimer();
                Timeover = true;
                isTiming = false;
                StartTimed = true;
                Debug.Log("��ʱ���");
                Timetop = -1F;
            }
        }
    }
   /* private void ACTIONSKI(int ACTION_SKIL)//���е��ж��������� 
    {
        switch (ACTION_SKIL)
        {
            case 0://����
                if (WantMoved)
                    WantMove(TargetOBJE.transform.position, true, 3f, true, Initialpos);
                break;
            case 1://����
                break;
            case 2://��Ʒ
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
            case 3://����
                break;
            case 4://����           
                ACTIONOVER();
                break;
            case -1://Ĭ��״̬
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
    private void ACTIONSTART()//�غϿ�ʼʱ��Ҫ��
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

