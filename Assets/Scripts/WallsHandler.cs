using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsHandler : MonoBehaviour
{
    [SerializeField] GameObject[] walls;
    [SerializeField] GameObject player;

    int currentPos = 0;


    // Update is called once per frame
    void Update()
    {        
        if (((int)player.transform.position.y) %4 == 0 && currentPos != (int)(player.transform.position.y))
        {
            currentPos = (int)player.transform.position.y;
            GameObject x = Instantiate(walls[Random.Range(0,2)],
                new Vector3(transform.position.x, gameObject.transform.GetChild(transform.childCount-1).gameObject.transform.position.y + 4, 0),
                Quaternion.identity);
            x.transform.parent = gameObject.transform;
            gameObject.transform.GetChild(0).gameObject.AddComponent<Rigidbody>();
            //gameObject.transform.GetChild(0).gameObject.transform.parent = null;
            Destroy(gameObject.transform.GetChild(0).gameObject, .7f);
        }
    }
}
