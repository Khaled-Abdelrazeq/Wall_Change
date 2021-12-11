using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObstacle : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private Transform[] spawnPoint;
    
    private float timer = 6f;

    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(3, 8);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * player.moveSpeed);
        if(timer < 0)
        {
            int rand = Random.Range(0, spawnPoint.Length);
            GameObject tmp = Instantiate(obstaclePrefab, spawnPoint[rand].position, Quaternion.identity);
            //tmp.transform.parent = spawnPoint[rand].gameObject.transform;
            timer = Random.Range(3, 8);
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
