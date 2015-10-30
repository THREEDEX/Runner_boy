using UnityEngine;
using System.Collections;

[System.Serializable]
public class infoObstacle {
    public string name;
    public bool wall;
    public bool bonus;
	public bool muchObject;
	public int muchCount = -1;
    public GameObject prefab;
	
}
[System.Serializable]
public class Environmen
{
    public string nameLevel;
    public LevelEnvironmen[] Enum;
   

}
[System.Serializable]
public class LevelEnvironmen
{
    public string name;
    public int priorityLevelMakes; // приорите создания   плаатформы в ззависемости от прохождения 
    public int priorityRandom;
    public GameObject prefab;
}
