using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {

	///..........delegats .................
    public delegate void AnimationPlayer();
    public delegate void Reflection();


    //...........links.....................
    [SerializeField]
    animations anim;
    [SerializeField]
    reflection reflect;
	[SerializeField]
	ManagerPoolPresent poolObj;

    void Awake()
    {
        GlobalManager.AnimationJump += anim.Jump;
        GlobalManager.AnimationDeath += anim.Death;
        GlobalManager.reflect += reflect.ReflectionActive;
		GlobalManager.RunAnimation += anim.Run;
		player.ReflectImp += reflect.ReflectionActive;

		//moveTurnOff.makePlatform += poolObj.SetActivePlatform;
    }

    void HandleRunAnimation ()
    {
    	
    }
}
