using UnityEngine;
using System.Collections;

public class Slot : MonoBehaviour {

	// Use this for initialization
	public GameObject childIcon;
	GameObject tmpChildIcon;
	[SerializeField]
	bool actParent;
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
			//print(dist);
			if(dist <= 30 )
			{
				//ПАРЕНТ К ЯЧЕЙКЕ
				print(dist);
				actParent = true;
				tmpChildIcon = DragIcon.objDrag.gameObject;
			}
			else if(dist > 30)
			{
				actParent = false;

			}

		}
		if (obj == null) {
			if(tmpChildIcon!= childIcon)
				childIcon = null;
			if(actParent &&  childIcon == null)
			{
				actParent = false;
				tmpChildIcon.transform.SetParent(transform);
				childIcon = tmpChildIcon;
				tmpChildIcon = null;
			}
		}

	}
}
