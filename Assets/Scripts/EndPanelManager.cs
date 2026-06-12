using UnityEngine;
using UnityEngine.UI;   //Text를 쓰기 위해서 추가
using UnityEngine.SceneManagement;  //Scene Load를 위해 추가

public class EndPanelManager : MonoBehaviour
{
    public Text Score;
    public Text BestScore;
    public GameObject newImages;
    public GameObject medal;
    public Sprite gold_m;
    public Sprite silver_m;
    public Sprite bronze_m;

    public void OnEnable()
    {
        Score.text = GameManager.score.ToString();
        if (GameManager.bestScore < GameManager.score)
        {
            GameManager.bestScore = GameManager.score;
            newImages.SetActive(true);
        }
        else
        {
            newImages.SetActive(false);
        }
        BestScore.text = GameManager.bestScore.ToString();
        if (GameManager.score >= 10)
        {
            medal.GetComponent<Image>().sprite = gold_m;
        }
        else if (GameManager.score >= 2)
        {
            medal.GetComponent<Image>().sprite = silver_m;
        }
        else medal.GetComponent<Image>().sprite = bronze_m;
    }

    public void okBtn()
    {
        GameManager.score = 0;
        SceneManager.LoadScene("FlappyBird");
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
