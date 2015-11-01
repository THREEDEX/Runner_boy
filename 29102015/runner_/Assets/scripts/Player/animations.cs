using UnityEngine;
using System.Collections;

public class animations : MonoBehaviour {

	// Use this for initialization
	[SerializeField]
	Animation _animation;
	[SerializeField]
	int NumberAnimation =0;
	[SerializeField]
	float SpeedAnimation;
    [SerializeField]
    Transform myPlayer;
    [SerializeField]
    Vector3 positionsRoad;
    [SerializeField]
    float shiftSpeed;
    [SerializeField]
    bool left;



    [SerializeField]
    float timerJump;
    private float tmpTimerJump;
    [SerializeField]
    float timerShift;
    private float tmp_timerShift;
    [SerializeField]
    Rigidbody rig;
	public int numberAnimation
	{
		get{return NumberAnimation; }
	}
	void Start () {
        tmpTimerJump = timerJump;
        tmp_timerShift = timerShift;
	}
	void Update () {
		AnimationManager (NumberAnimation,SpeedAnimation);
        ShiftLeft(left);
	}
	void AnimationManager(int numberAnimation, float speedAnimation)
	{

		switch(numberAnimation)
		{
		case 0:
			_animation.CrossFade("Run00");
			_animation["Run00"].speed = speedAnimation;
			break;
			
		case 1:
            if (timerJump > 0)
            {
                _animation.CrossFade("Jump_NoDagger");

               // rig.AddForce(new Vector3(transform.position.x, 4));
              
               // _animation["Jump_NoDagger"].speed = speedAnimation;
            }
            else if (timerJump <= 0)
            {
                timerJump = tmpTimerJump;
                NumberAnimation = 0;
            }
            timerJump -= Time.deltaTime;
                

			break;
		case 2:
            _animation.CrossFade("Death");
            NumberAnimation = -1;
			break;
			
		case 3:
            
			break;
		}
	}
    public void Jump()
    {
        NumberAnimation = 1;
    }
    public void Death()
    {
        NumberAnimation = 2;
    }
    public void MoveLeft()
    {
        left = true;
    }
    private void ShiftLeft(bool move)
    {
        if (move)
        {
            if (timerShift > 0)
                myPlayer.position = Vector3.MoveTowards(myPlayer.position, new Vector3(positionsRoad.x, myPlayer.position.y, myPlayer.position.z), Time.deltaTime * shiftSpeed);
            else if (timerShift < 0)
            {
                timerShift = tmp_timerShift;
                left = false;
            }
            timerShift -= Time.deltaTime;
        }
    }
	public void Run()
	{
		NumberAnimation = 0;
	}
	public void Idle()
	{
		NumberAnimation = 3;
	}
	IEnumerator WaitAndPrint(float time)
	{
		NumberAnimation = 0;
		yield return new WaitForSeconds(time);
		NumberAnimation = 0;
	}
}
