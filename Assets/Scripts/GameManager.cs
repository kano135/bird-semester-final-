using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //변수
    public float pipeTime = 2f;     //생성 간격(2초)
    public float pipeMin = -1;      //파이프 최소 생성높이
    public float pipeMax = 1;       //파이프 최대 생성높이
    public GameObject pipePrefab;   //파이프프리펩 등록

    static public int score = 0;    //ScoreUpdateDetect에서 직접적으로 점수를 올려줌
    static public int bestScore = 0;
    public Text ScoreText;  //게임의 Score라고 이름을 바꾼 Text UI를 연동해줄것임
    
    //static public bool playerDie = false;
    static public bool playerDie = true;

    public GameObject startPanel;
    public GameObject player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       // StartCoroutine(PipeStart());
    }

    public void startBtn()
    {
        playerDie = false;
        StartCoroutine(PipeStart());
        startPanel.SetActive(false);
        player.GetComponent<Rigidbody2D>().simulated = true; //중력 작동시켜주는 부분
        player.SetActive(true);   //시작하면시 플레이어를 활성화시킨다.
    }
    private void Update()
    {
        ScoreText.text = score.ToString();
    }

    IEnumerator PipeStart()
    {
        while(!playerDie)
        {
            Instantiate(pipePrefab,     //무엇을 만들것인가?
                new Vector3(3.5f, Random.Range(pipeMin, pipeMax), 0),   //어디에 만들것인가? 
                Quaternion.Euler(new Vector3(0,0,0)));  //회전값은 없다

            yield return new WaitForSeconds(pipeTime);  //pipeTime 만큼 쉬었다가 다음 반복문으로 넘어간다.
        }
    }
}
