using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GlobalManager : MonoBehaviour {

	//.................. Events....................
    public static event EventManager.AnimationPlayer AnimationJump; //jump
    public static event EventManager.AnimationPlayer AnimationDeath;// Death
    public static event EventManager.Reflection reflect;            // impuls
    
    
    
    
    //...................liks......................
    [SerializeField]
    public Text Cost;
    public Text xSpeed;


    //.............values............................
	public bool _throw = false;
    [SerializeField]
    bool death;
    Vector3 fingerStart;
    Vector3 fingerEnd;
    [SerializeField]
    float tolerance;
    int positionSwipe = 0;
    bool all = true;
    bool tmp_all = false;
	public bool pause = true;// пауза в игре
    [SerializeField]
    Transform boyTransform = null;
    [SerializeField]
    Vector3 positionXShift;
    [SerializeField]
    float timerShiftRoad;
    float tmpTimerShiftRoad;
    [SerializeField]
    float speedXShift;
    [SerializeField]
    int count = 0;
    bool change;
    [SerializeField]
    bool reflection;
    [SerializeField]
    Transform cameraPos;
    [SerializeField]
    bool ShiftCamera;
    [SerializeField]
    float timerRotationCam;
    float tmpRotationCam;
    private float valuePosX = 0;
    public int CostInt = 0;
	[SerializeField]
	public AnimationCurve trPosFishks;//  перемещение  фишки по  параболе
	[SerializeField]
	public AnimationCurve rotPosFishks;//поворот.
	void Start () {
        tmpTimerShiftRoad = timerShiftRoad;
        tmpRotationCam = timerRotationCam;
        
	}
	void Update () {
        
        Death();
        Swipe_();
        if (change)
        {
            ShiftX(count);
        }
        if (reflection)
        {
            reflection = false;
            reflect();
        } //RotationCam();
        
	}
    
    void Death()//tmp
    {
        if (death)
        {
            death = false;
            AnimationDeath();
        }
    }
    public void Swipe_()
    {
        if (Input.GetMouseButtonDown(0))
        {
            fingerStart = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            fingerEnd = Input.mousePosition;
        }
        if (Input.GetMouseButtonDown(0))
        {
            fingerStart = Input.mousePosition;
            fingerEnd = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            fingerEnd = Input.mousePosition;
            if (Mathf.Abs(fingerEnd.x - fingerStart.x) > tolerance ||
               Mathf.Abs(fingerEnd.y - fingerStart.y) > tolerance)
            {
                if (Mathf.Abs(fingerStart.x - fingerEnd.x) > Mathf.Abs(fingerStart.y - fingerEnd.y))
                {
                    //Right Swipe
                    if ((fingerEnd.x - fingerStart.x) > 0)
                    {
                        if (positionSwipe >= 0 || positionSwipe < 2.2f)
                        {
                            if (all != tmp_all)
                            {
                                if (count < 1)
                                {
                                   
                                    change = true;
                                    count++;
                                    ShiftCamera = true;
                                }
                                all = tmp_all;
                            }
                            transform.position = new Vector3(positionSwipe, transform.position.y, transform.position.z);
                        }

                    }
                    //Left Swipe
                    else
                    {
                        if (positionSwipe <= 0 || positionSwipe > -2.2f)
                        {
                            if (all != tmp_all)
                            {
                                if (count > -1)
                                {
                                    count--;
                                    change = true;
                                    ShiftCamera = true;
                                }
                                all = tmp_all;
                            }
                        }
                    }

                }
                else
                {
                    //Upward Swipe
                    if ((fingerEnd.y - fingerStart.y) > 0)
                    {
                        if (all != tmp_all)
                        {
                            AnimationJump();
                            all = tmp_all;
                        }
                    }
                    //Downward Swipe
                    else
                        Debug.Log("4444444");
                }
                fingerStart = fingerEnd;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            fingerStart = Vector2.zero;
            fingerEnd = Vector2.zero;
            all = true;

        }
    }
    void ShiftX(int countShift)
    {
        timerShiftRoad -= Time.deltaTime;
        if (timerShiftRoad >= 0)
        {
            switch (countShift)
            {
                case -1:
                    boyTransform.position = Vector3.MoveTowards(boyTransform.position, new Vector3(positionXShift.x,boyTransform.position.y,boyTransform.position.z),Time.deltaTime * speedXShift);
                    break;
                case 1:
                    boyTransform.position = Vector3.MoveTowards(boyTransform.position, new Vector3(positionXShift.z, boyTransform.position.y, boyTransform.position.z), Time.deltaTime * speedXShift);
                    break;
                case 0:
                    boyTransform.position = Vector3.MoveTowards(boyTransform.position, new Vector3(positionXShift.y, boyTransform.position.y, boyTransform.position.z), Time.deltaTime * speedXShift);
                    break;
            }
        }
        else {
            timerShiftRoad = tmpTimerShiftRoad;
            change = false;
        }
        
    }
    void RotationCam()
    {
        if (ShiftCamera)
        {
            timerRotationCam -= Time.deltaTime;
            if (timerRotationCam >= 0)
            {
                if (count == 1)
                {
                    valuePosX -= Time.deltaTime * 4;
                    if (valuePosX <= -1.2)
                        ShiftCamera = false;
                }
                else if (count == -1)
                {
                    valuePosX += Time.deltaTime * 4;
                    if (valuePosX >= 1)
                        ShiftCamera = false;
                }
                if (count == 0)
                    valuePosX = Mathf.Lerp(valuePosX, 0, Time.deltaTime * 4);
              
//                    cameraPos.localPosition = new Vector3(valuePosX, cameraPos.localPosition.y, curveRotat.Evaluate(cameraPos.localPosition.x));
//                    cameraPos.eulerAngles = new Vector3(cameraPos.localRotation.x, curveLookAt.Evaluate(cameraPos.localPosition.x * 14));
                
               
            }
            else {
                ShiftCamera = false;
                timerRotationCam = tmpRotationCam;
            }
        }
        
    }
 
}
