using UnityEngine;
using System.Collections;

public class Monets :  MonoBehaviour {

	// Use this for initialization
	ManagerPoolPresent manager;
   // managerPlatform platform;
	public GlobalManager managerG;
	int positionX;
    [SerializeField]
    bool monet;
    [SerializeField]
    bool obstacle;
    [SerializeField]
    bool bonus;
    [SerializeField]
	bool counter;
    AnimationCurve curve;
	bool _throw;
	Vector2 tmpSetupThrow = new Vector2(0,-1);
    void Start(){
		managerG = GameObject.Find("GlobalManager").GetComponent <GlobalManager>();
    }
	// Update is called once per frame
	void Update () {
        if(monet)
        RotationMonets();
		if(_throw)
		{
			Throw();
		}
	}
	void RotationMonets()
	{
		transform.Rotate (Vector3.right * Time.deltaTime * 100);
	}
	float t =0;
	void Throw()
	{
		if(tmpSetupThrow.x!= tmpSetupThrow.y)
		{
			tmpSetupThrow.x = tmpSetupThrow.y;
			t= 0;
		}
		if(t>-7){
			t-= Time.deltaTime*20;
			transform.position =  new Vector3(t, managerG.trPosFishks.Evaluate(transform.position.x), transform.position.z);
			transform.eulerAngles = new Vector3(managerG.rotPosFishks.Evaluate(transform.position.x),transform.rotation.y,transform.rotation.z);
		}
		else {
			_throw= false;
			tmpSetupThrow.x = 0;

		}
	
	}
	void OnTriggerEnter(Collider other)
	{
		if(counter)
		if (other.name.Contains("Player"))
		{
			_throw = true;
		}

	}
}
