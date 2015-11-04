using UnityEngine;
using System.Collections;

public class CameraLookAtPlayer : MonoBehaviour {


    public Transform player;
    [SerializeField]
    float speed = 1f;
    void Update()
    {

        LookAt();
    }
    void LookAt()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(player.position.x,player.position.y+10,player.position.z-10),Time.deltaTime * speed);
    }
}
