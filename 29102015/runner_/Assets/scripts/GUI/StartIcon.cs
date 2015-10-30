using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class StartIcon : MonoBehaviour {


	// Use this for initialization
	[SerializeField]
	float timerStart;
	float tmp_timerStart;
	[SerializeField]
	GlobalManager manager;
	[SerializeField]
	Image icon;
	[SerializeField]
	Text text;
	bool _time = true;
	void Start () {
		tmp_timerStart = timerStart;
		text.text = timerStart.ToString();
	
	}
	
	// Update is called once per frame
	void Update () {
		if(manager.pause)
		StartIconAlfa();
	
	}
	void StartIconAlfa()
	{
		if(timerStart> 1)
		{
			int tmp = (int)timerStart;
			text.text = tmp.ToString();
		}
		if(timerStart <1)
		{
			//timerStart = tmp_timerStart;

			text.text = "Go";
			if(timerStart<0)
			{
				timerStart = tmp_timerStart;
				manager.pause = false;
				text.text = "";
				icon.enabled = false;
			}

		}
		timerStart -= Time.deltaTime;

	}
}
