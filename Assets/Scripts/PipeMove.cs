using UnityEngine;

public class PipeMove : MonoBehaviour
{
    public float pipeSpeed = 4f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.playerDie)
        {
            transform.Translate(-pipeSpeed * Time.deltaTime, 0, 0);
            if (transform.position.x <= -4f)
            {
                Destroy(gameObject);
            }
        }


    }
}
