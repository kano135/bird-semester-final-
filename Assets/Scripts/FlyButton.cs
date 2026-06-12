using UnityEngine;

public class FlyButton : MonoBehaviour
{
    public float birdJump = 8f;
    public float rotate = -0.1f;

    public GameObject EndPanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.playerDie)
        {    
            if (Input.GetMouseButtonDown(0))
            {
                //GetComponent<Rigidbody2D>().velocity = new Vector2(0, birdJump);
                //GetComponent<Rigidbody2D>().AddForce(Vector2.up * birdJump, ForceMode2D.Impulse);
                GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, birdJump);

                transform.rotation = Quaternion.Euler(0, 0, 20);
            }
            transform.Rotate(0, 0, rotate);

        }
    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe_Ground"))
        {
            GameManager.playerDie = true;
            EndPanel.SetActive(true);
        }
    }
}
