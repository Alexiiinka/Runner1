using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackgroundMove : MonoBehaviour
{
    [SerializeField]
    public GameObject wall1, wall2, pavement1, pavement2;
    private Vector3 wall1Start = new Vector3 (57.0150833f,8.29f,4.13874292f), wall2Start = new Vector3(163.75f,8.29f,4.13874292f);
    private Vector3 pav1Start = new Vector3 (0,0.13f,2.89f), pav2Start = new Vector3(46.85009f,0.13f,2.89f);
    public float moveSpeed = -10.3f, moveSpeedSlower = -5.11f;
    public int score = 0;
    public bool gameOn = true;
    PlayerMovement playerSc;
    [SerializeField]
    TMPro.TextMeshProUGUI scoreTxt;
    float timeStart;
    Bounds bounds; //to get pavement mesh bounds {to find out the size}
    Vector3 pavementSizeX ;

    void Awake()
    {
        timeStart = Time.time;
    }
    void Start()
    {
        //Application.targetFrameRate = 60;
        wall1.transform.position = wall1Start;
        wall2.transform.position = wall2Start;
        playerSc = GameObject.Find("Player").GetComponent<PlayerMovement>();
        StartCoroutine(time());

        // To get size x of pavement so the adding "next" pavement can be smooth
        bounds = pavement1.GetComponent<MeshFilter>().mesh.bounds;
        // it needs to be translated by multiplying with localScale
        pavementSizeX =  new Vector3 (bounds.size.x * pavement1.transform.localScale.x, 0, 0);
        // Debug.Log("Without localScale: " + bounds.size.x);
        // Debug.Log("With localScale: " + bounds.size.x * pavement1.transform.localScale.x);
    }

    void Update()
    {
        if (gameOn)
        {
            EnvironmentMove();
            scoreTxt.text = "Score: " + (Time.time - timeStart).ToString("F2");
        }
    }

    void EnvironmentMove()
    {
        wall1.transform.Translate(moveSpeedSlower * Vector3.right * Time.deltaTime);
        wall2.transform.Translate(moveSpeedSlower * Vector3.right * Time.deltaTime);
        pavement1.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        pavement2.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        if (wall1.transform.position.x <= -49.7f)
        {
            wall1.transform.position = wall2Start;
        }
        if (wall2.transform.position.x <= -49.7f)
        {
            wall2.transform.position = wall2Start;
        }

        if (pavement1.transform.position.x <= -46.03979)
        {
            pavement1.transform.position = pavement2.transform.position + pavementSizeX;
        }
        if (pavement2.transform.position.x <= -46.03979)
        {
            pavement2.transform.position = pavement1.transform.position + pavementSizeX;
        }
    }

    IEnumerator time()
    {
        while (true)
        {
            timeCount();
            yield return new WaitForSeconds(1);
        }
    }

    void timeCount()
    {
        score += 1;
        if (score % 10 == 0)
        {
            SpeedChange();
        }
    }
    void SpeedChange()
    {
        playerSc.Nanny.SetFloat("speedPlus", playerSc.Nanny.GetFloat("speedPlus") + 0.3f);
        moveSpeed *= 1.08f; 
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
