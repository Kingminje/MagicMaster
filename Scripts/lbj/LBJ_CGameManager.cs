using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LBJ_CGameManager : MonoBehaviour
{

    public float delaytime;
    // 리모트 컨트롤러 연결 여부 프로퍼티
    public bool ControllerIsConnected
    {
        get
        {
            // 왼쪽 또는 오른쪽 컨트롤러가 존재하고 연결되어 있다면 True 리턴
            OVRInput.Controller controller = OVRInput.GetConnectedControllers() & (OVRInput.Controller.LTrackedRemote | OVRInput.Controller.RTrackedRemote);
            return controller == OVRInput.Controller.LTrackedRemote || controller == OVRInput.Controller.RTrackedRemote;
        }
    }

    public Image[] _runeButton;
    
    public int i;  

    public static bool KeyCodeTrigger = false; // 캐스팅 룬이 쿨다임동안 쉬도록 하는 불타입. 
    public bool Fire = false; // 룬 3개 캐스팅 됬을 시 발동하도록 하는 트리거 

    public Mj_MagicBook _indexs; // 매직북 스크립트 참조

    public int[] index = new int[2];// 첫번째 룬의 int값을 index1이 두번째는 index2, index3이 몇번 마법인지 정함/민J

    public Animator _anim; // 플레이어 애니메이터 참조 (웅쓰) 

    public GameObject _perfabs;
    

    
    private void Start()
    {        
        i = 0;
        
    }

    private void Update()
    {
        InputButton();
    }

    public void RuneKeyCodeButtonDown(int runeValue)
    {
        if (i == 1) return;

        if (i == 0) Fire = true;

        index[i] = runeValue;
           
        StartCoroutine(ImgCooltimeCoroutine(runeValue));
        
        i++;  
    }
    
    public void FireMagic()
    {

        if (KeyCodeTrigger) return;

        _indexs.MagicToRow(index[0]);

        _runeButton[index[0]].color = new Color(_runeButton[index[0]].color.r, _runeButton[index[0]].color.g, _runeButton[index[0]].color.b, 0);

        i = 0;
        Fire = false;
        // 애니메이션 매직북에서 재구현.
    }
    
   

    IEnumerator ImgCooltimeCoroutine(int runeValue) // 새로 작성한 코루틴 (3/27) LBJ
    {
        KeyCodeTrigger = true;

        float buttoncoolTime = (runeValue + 1);

        float waitTime = (runeValue + 1);

        _runeButton[runeValue].color = new Color(_runeButton[runeValue].color.r, _runeButton[runeValue].color.g, _runeButton[runeValue].color.b, 1f);

        while (waitTime > 0)
        {
            waitTime -= Time.deltaTime;
            
            if (waitTime < 0)
            {
                waitTime = 0;
            }

            float filling = 1 - (waitTime / buttoncoolTime);

            _runeButton[runeValue].fillAmount = filling;

            yield return new WaitForSeconds(0.001f);

        }
        
        KeyCodeTrigger = false;

    }
    
    //OVR
    private void InputButton()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.DpadUp) && i < 2 && KeyCodeTrigger == false)
        {
            RuneKeyCodeButtonDown(0);
            Debug.Log("UP버튼 입력");
        }
        else if (OVRInput.GetDown(OVRInput.RawButton.DpadLeft) && i < 2 && KeyCodeTrigger == false)
        {
            RuneKeyCodeButtonDown(1);
            Debug.Log("Left버튼 입력");
        }
        else if (OVRInput.GetDown(OVRInput.RawButton.DpadDown) && i < 2 && KeyCodeTrigger == false)
        {
            RuneKeyCodeButtonDown(2);
            Debug.Log("Down버튼 입력");
        }
        else if (OVRInput.GetDown(OVRInput.RawButton.DpadRight) && i < 2 && KeyCodeTrigger == false)
        {
            RuneKeyCodeButtonDown(3);
            Debug.Log("Right버튼 입력");
        }
        else if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) && Fire == true && i == 1)
        {
            Debug.Log("트리거 작동");
            FireMagic();            
           
        }
        else if (OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad))
        {
            
        }

    }

    public void vivebuttonup()
    {
        RuneKeyCodeButtonDown(0);
    }
    public void vivebuttondown()
    {
        RuneKeyCodeButtonDown(2);
    }
    public void vivebuttonright()
    {
        RuneKeyCodeButtonDown(3);
    }
    public void vivebuttonleft()
    {
        RuneKeyCodeButtonDown(1);
    }

    public void rebrith(GameObject players)
    {

        Instantiate(_perfabs, players.transform.position, players.transform.rotation);
    }
}
