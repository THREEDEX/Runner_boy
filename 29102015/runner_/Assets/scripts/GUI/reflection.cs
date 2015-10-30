using UnityEngine;
using System.Collections;

public class reflection : MonoBehaviour {

	// Use this for initialization
    [SerializeField]
    Vector3 scale;
    [SerializeField]
    float speedScale;
    [SerializeField]
    float speedLast;
    [SerializeField]
    bool scale_;
    Vector3 myScale;
    [SerializeField]
    float timer;
    float tmpTimer;
    [SerializeField]
    float stopTimer;
	void Start () {
        myScale = transform.localScale;
        tmpTimer = timer;
	}
	
	// Update is called once per frame
	void Update () {
        if(scale_)
        Reflection();
	}
    void Reflection()
    {
        timer -= Time.deltaTime;
        if (timer > 0)
        {
            if (scale_)
            {
                transform.localScale = Vector3.MoveTowards(transform.localScale, scale, Time.deltaTime * speedScale);
            }
        }
        else if(timer<0 && timer> stopTimer)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, myScale, Time.deltaTime * speedLast);
        }
        else if (timer < stopTimer)
        {
            scale_ = false;
            timer = tmpTimer;
        }
    }
    public void ReflectionActive()
    {
        scale_ = true;
    }
}
