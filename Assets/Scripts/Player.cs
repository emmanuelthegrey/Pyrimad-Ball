using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject sceneManager;

    public float playerSpeed = 2000;
    public float directionalSpeed = 20;
    private int score;
    public AudioClip scoreUp;
    public AudioClip damage;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
# if UNITY_EDITOR || UNITY_STANALONE || UNITY_WEBPLAYER
        float moveHorizontal = Input.GetAxis("Horizontal");
        //Debug.Log(moveHorizontal);
        transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(Mathf.Clamp(gameObject.transform.position.x + moveHorizontal, -2.5f, 2.5f), gameObject.transform.position.y, gameObject.transform.position.z), directionalSpeed * Time.deltaTime);
#endif
        GetComponent<Rigidbody>().velocity = Vector3.forward * playerSpeed * Time.deltaTime;
        //Mobile Controls
        Vector2 touch = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10f));
        if(Input.touchCount > 0)
        {
            transform.position = new Vector3(touch.x, transform.position.y, transform.position.z);
        }
        if(score > 10)
            playerSpeed = score * 100;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "scoreup")
        {
            GetComponent<AudioSource>().PlayOneShot(scoreUp, 1.0f);
            score++;
        }
        if (other.gameObject.tag == "triangle")
        {
            GetComponent<AudioSource>().PlayOneShot(damage, 1.0f);
            sceneManager.GetComponent<App_Intialize>().GameOver();
        }
    }

}
