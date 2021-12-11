using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject timerTextParent;
    [SerializeField] internal float moveSpeed;
    [SerializeField] ParticleSystem particleSystem;

    internal static bool left = false;
    internal static bool right = false;

    private float firstSpeed;
    private bool startTimer = true;
    private float timer = 5;

    // Start is called before the first frame update
    void Start()
    {
        firstSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

        if (left && transform.position.x > -1.5)
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime * .5f);
        }else if (right && transform.position.x < 1.5)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime * .5f);
        }

        if (startTimer)
        {
            timer -= Time.deltaTime;
            timerTextParent.transform.GetChild(0).gameObject.GetComponent<Text>().text = ((int) timer).ToString();
        }
        if(timer <= 0)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            moveSpeed = 0;
            startTimer = false;
            if(particleSystem)
                particleSystem.Play();
            particleSystem = null;

            Invoke("GameoverPanel", 1.5f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Enemy")
        {
            // Gameover
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            if(particleSystem)
                particleSystem.Play();
            particleSystem = null;
            moveSpeed = 0;
            startTimer = false;

            Invoke("GameoverPanel", 1.5f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.transform.tag == "Wall")
        {
            startTimer = true;
            timer = 5;
            timerTextParent.SetActive(true);
        }

    }

    public void GameoverPanel()
    {
        SceneManager.LoadScene(2);
    }
}
