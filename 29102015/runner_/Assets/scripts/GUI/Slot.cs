using UnityEngine;
using System.Collections;

public class Slot : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		DistanceObj (DragIcon.objDrag);
	}
	void DistanceObj(Transform obj)
	{

		if (obj != null) {
			var dist = Vector3.Distance(transform.position, obj.position);
			if(dist <= 30 && obj == null)
			{
				//ПАРЕНТ К ЯЧЕЙКЕ

			}
		}

	}
}
