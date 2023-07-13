using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    BackgroundMove backgrSc;
    // Start is called before the first frame update
    void Start()
    {
        backgrSc = GameObject.Find("Manager").GetComponent<BackgroundMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if(backgrSc.gameOn)
        {
            transform.Translate(-backgrSc.moveSpeed * Vector3.right * Time.deltaTime);
        }
        if (transform.position.x < -44)
        {
            Destroy(gameObject);
        }
    }
}
