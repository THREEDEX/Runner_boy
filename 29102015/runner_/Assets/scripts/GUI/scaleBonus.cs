using UnityEngine;
using System.Collections;

public class scaleBonus : MonoBehaviour {

	// Use this for initialization
    [SerializeField]
    float timer = 0;
    [SerializeField]
    float timerStandart = 0;
    [SerializeField]
    bool reflect;
    [SerializeField]
    bool standScale;
    [SerializeField]
    Vector2 standartScale;
    [SerializeField]
    float speedScale;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        ScaleToStandart();
        Reflection();

	}
    void Reflection()
    {
        if (reflect)
        {
            timer += Time.deltaTime;
            transform.localScale = new Vector2(2* (Mathf.PingPong(timer, 0.5f) + 0.5f), 0.8f * (Mathf.PingPong(timer, 0.5f) + 0.5f));
            if (timer > 1f)
            {
                reflect = false;
                timer = 0;
            }
        }
    }
    void ScaleToStandart()
    {
        if (standScale)
        {
            transform.localScale = Vector2.Lerp(transform.localScale, standartScale, Time.deltaTime * speedScale);
            timerStandart += Time.deltaTime;
            if (timerStandart > 0.4f)
            {
                standScale = false;
                reflect = true;
                timerStandart = 0;
            }

        }
    }
    void ScaleFromStandart()
    {

    }
}
