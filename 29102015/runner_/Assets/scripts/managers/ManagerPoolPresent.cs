using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ManagerPoolPresent : MonoBehaviour {




	// Use this for initialization
	[SerializeField]
	public List<GameObject> AddListGOPlatform; 
    [SerializeField]
    Library library;
    [SerializeField]
    List<GameObject> levelEnvir;
    [SerializeField]
    List<GameObject> monets;
	[SerializeField]
	List<GameObject> conus;
    [SerializeField]
    List<GameObject> obstacle;
    [SerializeField]
    List<GameObject> monetsDefault;
	[SerializeField]
	GameObject monet;
	[SerializeField]
	int countMonets;
	
	int countPositionMonets = 0;// позиция   копейки относительно друг друга, растояние между ними
	[SerializeField]
	int [] randomPositionMonets;
    [SerializeField]
    int countPoolObjectEnvironmen = 2;
	int randomPositionMonet;
	[SerializeField]
	float timeMakeLoopMOnets;
    
    [SerializeField]
    int loopCountObstacle;
    [SerializeField]
    GameObject parentPoolObj; // переменная  для   парента пул обьектов окружения
	[SerializeField]
	GameObject parentzPoolObjConus;
	[SerializeField]
	int loopCountMakePlatform;
	private int loopCount = 40;
	[SerializeField]
	GameObject spawnPoint;
	public int RandomMonetPosition{
		get{return randomPositionMonet;}
	}
	public List<GameObject> MonetsDefault
	{
		get{return monetsDefault;}
	}

	void Start () {
        MakeEnvironmanPool();
        for (int i = 0; i < countMonets; i++)
        {
            GameObject go = Instantiate(monet, transform.position, transform.rotation) as GameObject;
            go.transform.SetParent(GameObject.Find("#monets").transform);
            go.SetActive(false);
            go.transform.rotation = Quaternion.Euler(0, 0, 90);
            monets.Add(go);
        }
        MakeStartScenobstacle();
		InvokeRepeating ("GenericMonets",0,timeMakeLoopMOnets);
        InvokeRepeating("GenericObstacle", 0, 1);
	}
	void Update () {
	
	}
    private void MakeStartScenobstacle()
    {
        for (int i = 0; i < library.LibreryObstacl.Length; i++) //library.libraryObjects.Length
        {
            for (int j = 0; j < loopCountObstacle; j++)
            {
                GameObject go = GameObject.Instantiate(library.LibreryObstacl[i].prefab);
				if(!go.name.Contains("monets"))
                	go.transform.SetParent(GameObject.Find("#obstacls").transform);
				else if(go.name.Contains("monets"))
					go.transform.SetParent(GameObject.Find("#monets").transform);

                obstacle.Add(go);
                go.SetActive(false);
            }




        }
		for (int j = 0; j< library.LibreryObstacl[1].muchCount; j++) // пулл конус
		{
			GameObject inst = GameObject.Instantiate(library.LibreryObstacl[1].prefab);
			conus.Add(inst);
			inst.transform.SetParent(parentzPoolObjConus.transform);
			inst.SetActive(false);
		}
    }
	void GenericMonets()
	{
		countPositionMonets = 0;
		int randomMakeNumberMonets = Random.Range (0, (monets.Count -1)/2);
	    randomPositionMonet = Random.Range (0,randomPositionMonets.Length);
		randomPositionMonet = randomPositionMonets [randomPositionMonet];
		for (int i = 0; i<randomMakeNumberMonets; i++) {
			if(monets[i].activeInHierarchy == false){
				countPositionMonets += 3;
				monets[i].transform.position = new Vector3(randomPositionMonet,2,spawnPoint.transform.position.z - countPositionMonets);
				monets[i].SetActive(true);

		}
		}
		GenericConus();

	}
	 void GenericConus()
	{
		countPositionMonets = 0;
		int randomMakeNumberConus = Random.Range (0, (conus.Count -1)/2);
		randomPositionMonet = Random.Range (0,randomPositionMonets.Length);
		randomPositionMonet = randomPositionMonets [randomPositionMonet];
		for (int i = 0; i<randomMakeNumberConus; i++) {
			if(conus[i].activeInHierarchy == false){
				countPositionMonets += 3;
				conus[i].transform.position = new Vector3(randomPositionMonet,0,spawnPoint.transform.position.z - countPositionMonets);
				conus[i].SetActive(true);
				
			}
		}
	}
    void GenericObstacle()
    {
        int tmpRandom = -1;
        for (int i = 0; i < 2; i++)
        {
            int randomPosition = Random.Range(0, randomPositionMonets.Length);
            randomPosition = randomPositionMonets[randomPosition];
            int randomObstacle = Random.Range(0, obstacle.Count);// доработать с длиной массива и   перспектива  рандомного  сздания  обьекта.
            if (!obstacle[randomObstacle].activeInHierarchy && randomPosition != tmpRandom)
            {  
                tmpRandom = randomPosition;
                obstacle[randomObstacle].transform.position = new Vector3(randomPosition,0,spawnPoint.transform.position.z);
                obstacle[randomObstacle].SetActive(true);
            }

        }
    }
    void MakeEnvironmanPool()//  в старте  создаю пул  окружения для первого левела
    {
        for (int i = 0; i < library._environmen[0].Enum.Length; i++)
        {
            for (int j = 0; j < countPoolObjectEnvironmen;j++)
            {
                GameObject go = (GameObject)Instantiate( library._environmen[0].Enum[i].prefab);
                go.transform.SetParent(parentPoolObj.transform);
                levelEnvir.Add(go);
				AddListGOPlatform.Add(go);
                go.SetActive(false);

            }
        }
    }
	public void AddListEnvironment(GameObject go)
	{
		//go.transform.tag = nameTagOfline;
		//AddListGOPlatform = GameObject.FindGameObjectsWithTag(nameTagOfline);
		AddListGOPlatform.Add (go);
		go.SetActive(false);


	}
	public void SetActivePlatform(GameObject go)
	{

		int rand = Random.Range(0,AddListGOPlatform.Count);
		AddListGOPlatform[rand].transform.position =  new Vector3( 0,0,loopCountMakePlatform);
		AddListGOPlatform[rand].gameObject.SetActive(true);
		AddListGOPlatform.Remove(AddListGOPlatform[rand]);
		loopCountMakePlatform+= loopCount;
//		for(int i = 0; i< AddListGOPlatform.Count; i++)
//		{
//			if(AddListGOPlatform[i].activeInHierarchy)
//			{
//				AddListGOPlatform.Remove(AddListGOPlatform[i]);
//			}
//		}
	}

}


