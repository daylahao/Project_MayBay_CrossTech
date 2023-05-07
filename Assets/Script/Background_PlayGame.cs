using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_PlayGame : MonoBehaviour
{
    public float speed=5f;
    private Vector3 Start_Pos;
    // Start is called before the first frame update
    void Start()
    {
        Start_Pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10.64f)
        {
            transform.position = Start_Pos;
        }
        transform.position += new Vector3(0,-1f, 0) * speed * Time.deltaTime;
    }
}
