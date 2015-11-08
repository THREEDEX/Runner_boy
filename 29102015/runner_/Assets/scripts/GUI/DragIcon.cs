using UnityEngine;
using System.Collections;

public class DragIcon : MonoBehaviour {

	public int idIcon = -1;
	int tmpId;
	[SerializeField]
	private Vector3 startPosition = Vector3.zero;
	[SerializeField]
	Vector3 endPossition;
	[SerializeField]
	public static Transform objDrag;
	[SerializeField]
	float speed = 70f;
	Vector2 v = new Vector2(1,-1);
	public static bool parentSlot = true;
	void Start()
	{
		tmpId = idIcon;


	}
	void Update()
	{

		Drag ();
	}
	void Drag()
	{
		if (objDrag != null )
			objDrag.position = Input.mousePosition;
		else if(objDrag == null)
			transform.localPosition = Vector3.Lerp(transform.localPosition,startPosition, Time.deltaTime * speed);
		 
	}
	public void Click()
	{
		objDrag = gameObject.transform;
		parentSlot = false;
	}
	public void ClickUp()
	{
		objDrag = null;
		parentSlot = true;
	}
}
