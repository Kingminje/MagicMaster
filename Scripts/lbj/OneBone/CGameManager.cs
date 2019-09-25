using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CGameManager : MonoBehaviour
{

    // 리모트 컨트롤러 연결 여부 프로퍼티
    public bool ControllerIsConnected
    {
        get
        {
            // 왼쪽 또는 오른쪽 컨트롤러가 존재하고 연결되어 있다면 True 리턴
            OVRInput.Controller controller = OVRInput.GetConnectedControllers() & (OVRInput.Controller.LTrackedRemote | OVRInput.Controller.RTrackedRemote);

            return controller == OVRInput.Controller.LTrackedRemote ||
                controller == OVRInput.Controller.RTrackedRemote;
        }
    }

    //public Button _fireButton; 미사용.
    //public Image[] _castingButton;
    //public Image _defaultIMG; 미사용.

    public Image[] _runeButton;
    
    private int i;
    //private static int r;
    //private int[] _d = new int[] {111,111,111};

    public GameObject _magic;
    public GameObject _magic2;
    public Transform _handPos;
    public Transform _camera;

    public GameObject _aim; // 발사 버튼 파티클

    public GameObject _buttonEffectPrefab;
    public Transform[] _buttonTr;

    private static bool KeyCodeTrigger = false; // 캐스팅 룬이 쿨다임동안 쉬도록 하는 불타입.
    private bool Fire = false; // 룬 3개 캐스팅 됬을 시 발동하도록 하는 트리거

    public MagicBook _indexs; // 매직북 스크립트 참조

    int[] index = new int[2];// 첫번째 룬의 int값을 index1이 두번째는 index2, index3이 몇번 마법인지 정함

    public Animator _anim; // 플레이어 애니메이터 참조 (웅쓰)

    //public bool GameManagerTrigger = false; // GVR베이직에 사용

    //public TranslateMovement _translateMoveent;

    private void Start()
    {        
        i = 0;

        // _runeButton[0].color = new Color(_runeButton[0].color.r, _runeButton[0].color.g, _runeButton[0].color.b, 1f);
        //_fireButton.GetComponent<Button>().enabled = false; 발사 버튼 기능 미사용.

    }

    private void Update()
    {
        InputButton();
    }

    /*
     
    public void RuneSelect(int r)
    {
        if (i == 3) return;
        
        
        if (i < 3)
        {
            _castingButton[i].sprite = _runeButton[r].sprite;
            StartCoroutine(ButtonCooltimeCoroutine(r));
            OnButtonClickEffect(r);

            if (i==2)
            {
                _aim.SetActive(true);
                // _fireButton.color = new Color(_fireButton.color.r, _fireButton.color.g, _fireButton.color.b, 0f);

                _runeButton[r].GetComponent<Button>().enabled = false;
                             
                _fireButton.GetComponent<Button>().enabled = true;
            }            
            i++;            
        }       

    }*///버튼 사용할려면 이거 활성화

    public void RuneKeyCodeButtonDown(int runeValue)
    {
        if (i == 1) return;

        if (i == 0) Fire = true;

        index[i] = runeValue;
           
        StartCoroutine(ImgCooltimeCoroutine(runeValue));
        
        i++;

        // _castingButton[i].sprite = _runeButton[runeValue].sprite;
        //OnButtonClickEffect(r);
        /*
         if (i == 1)
        {
            _aim.SetActive(true);
            // _fireButton.color = new Color(_fireButton.color.r, _fireButton.color.g, _fireButton.color.b, 0f);
            //_runeButton[r].GetComponent<Button>().enabled = false;
            //_fireButton.GetComponent<Button>().enabled = true;
        } */

    }

    /*
    public void RuneKeyCodeButtonDown(int r)
    {
        if (i == 3) return;        

        if (i < 3)
        {
            StartCoroutine(ButtonCooltimeCoroutine(r));
            _castingButton[i].sprite = _runeButton[r].sprite;

            OnButtonClickEffect(r);

            if (i < 2)
            {

                if (i == 0)
                {
                    //MagicValue.x = r;
                    index1 = r;
                    Debug.Log("첫번째 : " + index1);
                }
                else if (i == 1)
                {
                    //MagicValue.y = r;
                    index2 = r;
                    Debug.Log("두번째 : " + index2);
                }
                else
                {

                    //MagicValue.z = r;
                    //Debug.Log(MagicValue);
                }
            }

            if (i == 2)
            {
                _aim.SetActive(true);
                // _fireButton.color = new Color(_fireButton.color.r, _fireButton.color.g, _fireButton.color.b, 0f);

                _runeButton[r].GetComponent<Button>().enabled = false;

                _fireButton.GetComponent<Button>().enabled = true;

            }     

            i++;
            if (i == 3)
            {
                Debug.Log("첫번째 : " + index1

                        + "두번째 : " + index2);
                Fire = true;
            }
        }

    }
    */ //기존 룬 선택 


    /*
    // 상단 캐스팅 클릭시 이미지 디폴트
    public void CastingCancle(int c)
    {

        if (_castingButton[c].sprite == _defaultIMG.sprite)
        {
            return;
        }

        for (int j = c; j <= 2; j++)
        {

            if (j == 2)
            {
                _castingButton[j].sprite = _defaultIMG.sprite;
                //_d[j] = 111;
            }
            else
            {
                _castingButton[j].sprite = _castingButton[j + 1].sprite;
                //_d[j] = _d[j + 1];

            }
            //_fireButton.color = new Color(_fireButton.color.r, _fireButton.color.g, _fireButton.color.b, 0f);

            _fireButton.GetComponent<Button>().enabled = false;
            _aim.SetActive(false);
        }
        i--;
    }
    */ // 캐스팅 캔슬 기능. 현재 미사용.

    // 중앙 마법 발사버튼 클릭 시 버튼 디폴트 및 발사.

    public void FireMagic()
    {

        if (KeyCodeTrigger) return;

        _indexs.MagicToRow(index[0]);

        i = 0;

       /*
       _castingButton[0].sprite = _defaultIMG.sprite;
       _castingButton[1].sprite = _defaultIMG.sprite; // 사용안함
       if (_castingButton[0].sprite == _runeButton[0].sprite)
       {
           _anim.SetTrigger("Fire"); // 발싸 애니메이션 재생 (웅쓰)

           StartCoroutine(AnimPlay()); // 애니메이션 재생 후 0.5초 대기 (웅쓰)

           Instantiate(_magic, _handPos.position, _camera.rotation);
       }
       else
       {
           MagicRaycast();
       }
        _fireButton.color = new Color(_fireButton.color.r, _fireButton.color.g, _fireButton.color.b, 0f);        
        _aim.SetActive(false);
        _fireButton.GetComponent<Button>().enabled = false;
        //발사버튼 관련 주석처리 LBJ
        */
    }

    private IEnumerator AnimPlay() // 0.5초 대기 코루틴 (웅쓰)
    {
        yield return new WaitForSeconds(0.5f);

        Instantiate(_magic, _handPos.position, _camera.rotation);
    }

    /*
    // 하단 룬버튼 쿨타임 코루틴 
    IEnumerator ButtonCooltimeCoroutine(int a)
    {
        KeyCodeTrigger = true;

        float buttoncoolTime = (a + 1);

        float waitTime = (a + 1);


        foreach(Image i in _runeButton)
        {
            i.GetComponent<Button>().enabled = false;
        }

        
        //_runButton[a].GetComponent<Button>().enabled = false;

        while (waitTime > 0)
        {
           
            waitTime -= Time.deltaTime;
           
            if (waitTime < 0)
            {
                waitTime = 0;
            }

            float filling = 1 - (waitTime / buttoncoolTime);

            foreach (Image i in _runeButton)
            {
                i.fillAmount = filling;
            }           
                   //_runButton[a].fillAmount = filling;
            
            yield return new WaitForSeconds(0.001f);

        }


        foreach (Image i in _runeButton)
        {
            i.GetComponent<Button>().enabled = true;
        }
        KeyCodeTrigger = false;
        yield break;
        
    }*/ //이전에 사용하던 코루틴 주석처리 LBJ

    IEnumerator ImgCooltimeCoroutine(int runeValue) // 새로 작성한 코루틴 (3/27) LBJ
    {
        KeyCodeTrigger = true;

        float buttoncoolTime = (runeValue + 1);

        float waitTime = (runeValue + 1);

        _runeButton[runeValue].color = new Color(_runeButton[runeValue].color.r, _runeButton[runeValue].color.g, _runeButton[runeValue].color.b, 1f);

        while (waitTime > 0)
        {
            waitTime -= Time.deltaTime;
            Debug.Log(waitTime);
            if (waitTime < 0)
            {
                waitTime = 0;
            }

            float filling = 1 - (waitTime / buttoncoolTime);

            _runeButton[runeValue].fillAmount = filling;

            yield return new WaitForSeconds(0.001f);

        }
        _runeButton[runeValue].color = new Color(_runeButton[runeValue].color.r, _runeButton[runeValue].color.g, _runeButton[runeValue].color.b, 0);
        KeyCodeTrigger = false;

    }

    /*
    //버튼 클릭 파티클.
    public void OnButtonClickEffect(int i)
    {
        Vector3 buttonPos = new Vector3(_buttonTr[i].transform.position.x, _buttonTr[i].transform.position.y, _buttonTr[i].transform.position.z);

        Instantiate(_buttonEffectPrefab, buttonPos, Quaternion.identity);
    }
    */


    // 장소 지정하는 마법 발동.
    /*
    public void MagicRaycast() // 두번째 마법
    {
        RaycastHit _hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out _hit, Mathf.Infinity))
        {
            Vector3 _magicPoint = _hit.point;
            Instantiate(_magic2, _hit.point, _camera.rotation);
        }
    }*/

    // GearVR 컨트롤러 입력부분
    
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
            Fire = false;
            Debug.Log("Trigger버튼 입력");
        }
        else if (OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad))
        {
            
        }

        }
    }

    //else if (OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad))
    //{
    //    _translateMoveent.
    //}

    //public void InputButton(int value) // GearVRInputBasic 으로 가능
    //{
    //    if (value == 0)
    //    {
    //        RuneKeyCodeButtonDown(0);
    //        Debug.Log("A버튼 입력");

    //    }
    //    else if (value == 1)
    //    {
    //        RuneKeyCodeButtonDown(1);
    //        Debug.Log("B버튼 입력");
    //    }
    //    else if (value == 2)
    //    {
    //        RuneKeyCodeButtonDown(2);
    //        Debug.Log("X버튼 입력");
    //    }
    //    else if (value == 3)
    //    {
    //        RuneKeyCodeButtonDown(3);
    //        Debug.Log("Y버튼 입력");
    //    }
    //    else if (Input.GetKeyDown(KeyCode.Joystick1Button4))
    //    {
    //        if (Fire == true)
    //        {
    //            FireMagic();
    //            _indexs.MagicToRow(index1, index2);
    //            Fire = false;
    //        }

    //        Debug.Log("X-Axis버튼 입력");
    //    }
    //Xbox 컨트롤러로 작동하도록 업데이트에서 호출하도록함
    /*
    private void InputButton()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button0) && i < 2 && KeyCodeTrigger == false)
        {
            RuneKeyCodeButtonDown(0);
            Debug.Log("A버튼 입력");
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button1) && i < 2 && KeyCodeTrigger == false)
        {
            RuneKeyCodeButtonDown(1);
            Debug.Log("B버튼 입력");
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button2) && i < 2 && KeyCodeTrigger == false)
        {
            RuneKeyCodeButtonDown(2);
            Debug.Log("X버튼 입력");
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button3) && i < 2 && KeyCodeTrigger == false)
        {
            RuneKeyCodeButtonDown(3);
            Debug.Log("Y버튼 입력");
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button4) && Fire == true && i == 2)
        {
            
                FireMagic();
                Fire = false;
            
            //Debug.Log("X-Axis버튼 입력");
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button5))
        {
           // Debug.Log("Y-Axis버튼 입력");

        }

    
    }*/




