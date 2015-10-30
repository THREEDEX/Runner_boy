using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	// Use this for initialization
    public static event EventManager.Reflection ReflectImp; // 
    [SerializeField]
    GlobalManager managerG;
    [SerializeField]
    ParticleSystem particleMonets;
    [SerializeField]
    int numberMonets = 800; // число на которое делится  количество набраных монет чтобы  увеличить скорость
    int tmp = 1; //значение которое  увиличивает скрость
	[SerializeField]
	int speedPlayer;

	void Start () {
		//InvokeRepeating ();
	}
	
	// Update is called once per frame
	void Update () {
		if(!managerG.pause)
		MovePlayer ();
	
	}
     void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("monets"))
        {
            managerG.CostInt++;
            PlusSpeed(managerG.CostInt);
            managerG.Cost.text = managerG.CostInt.ToString();
            particleMonets.Play();
            other.transform.position = new Vector3(0, 0, 120);
            other.gameObject.SetActive(false);

        }
		if(other.name.Contains("Conus"))
		{
			managerG._throw = true;
		}
    }

     void PlusSpeed(int count)
     {
         int countInt = count / numberMonets;

         if (countInt == tmp)
         {
             tmp++;
             ReflectImp();
             managerG.xSpeed.text = "x" + tmp.ToString();
			speedPlayer +=5;
            // managerPlatform.speedPlatform = managerPlatform.speedPlatform * 1.2f;

         }
      
     }
	void MovePlayer()
	{
        transform.Translate(Vector3.forward * Time.deltaTime * speedPlayer);
	}
	



    
}