using UnityEngine;
using System.Collections;

public class moveTurnOff : MonoBehaviour {


	[SerializeField]
	ManagerPoolPresent poolManager;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.tag.Contains("Environmen"))
		{

			poolManager.SetActivePlatform(other.gameObject);
			poolManager.AddListEnvironment(other.gameObject);
			//other.gameObject.SetActive(false);


		}
		if(other.tag.Contains("obstacle"))
		{
			other.gameObject.SetActive(false);
		}
	}
}
