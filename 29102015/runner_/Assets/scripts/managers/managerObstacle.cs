using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class managerObstacle : MonoBehaviour {

	// Use this for initialization
	[SerializeField]
	int [] positionMakeObstacle;
	[SerializeField]
	GameObject [] objectsObstacle;
	[SerializeField]
	List<GameObject> activeObstacle;

	void Start () {
		CreateObstacleMass ();
		InvokeRepeating ("MakeRandomObstacle",5f,3f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void CreateObstacleMass()
	{
		for (int i = 0; i< objectsObstacle.Length; i++) {
			GameObject go = Instantiate(objectsObstacle[i],transform.position,transform.rotation) as GameObject;
			activeObstacle.Add(go);
			go.SetActive(false);

		}
	}

	void MakeRandomObstacle()
	{
		int randObstacle = Random.Range (0,objectsObstacle.Length);

		GameObject go_2 =  Instantiate (activeObstacle[randObstacle], new Vector3(0,0,200),Quaternion.identity)as GameObject;
		go_2.SetActive (true);

	}

}
