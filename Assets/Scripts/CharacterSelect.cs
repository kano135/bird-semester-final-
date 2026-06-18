using UnityEngine;
using UnityEngine.UI;   //시작화면 미리보기 Image를 바꾸기 위해

// 시작 화면의 좌/우 버튼(Tab_L / Tab_R)을 눌러 캐릭터를 바꾼다.
// 캐릭터는 "그림 여러 장"으로 이뤄지며, 여러 장이면 번갈아 보여서 움직이는 것처럼 된다.
// → 애니메이터/컨트롤러 안 만들어도 되고, 캐릭터마다 그림만 끼우면 끝.
public class CharacterSelect : MonoBehaviour
{
    [System.Serializable]
    public class Character
    {
        public string name;       //메모용 (안 적어도 됨)
        public Sprite[] frames;   //이 캐릭터의 그림들 — 2장 이상이면 번갈아 움직임, 1장이면 가만히
    }

    [Header("연결 (자동으로 들어가 있음)")]
    public SpriteRenderer playerRenderer;   //실제 플레이어(Bird)의 그림 — 인게임에 나오는 캐릭터
    public Image previewImage;              //시작 화면(Startpanel)에 보이는 미리보기 그림
    public Animator playerAnimator;         //원래 새 애니메이터 — 이 스크립트가 직접 그림을 바꾸므로 꺼준다

    [Header("캐릭터 목록 — 여기에 그림만 넣으면 됨")]
    public Character[] characters;
    public float frameRate = 12f;           //그림 바뀌는 속도(초당 장수)

    int index = 0;   //지금 캐릭터
    int frame = 0;   //지금 그림(프레임)
    float timer = 0f;

    void Start()
    {
        if (playerAnimator != null) playerAnimator.enabled = false; //애니메이터 끄고 직접 제어
        frame = 0;
        ShowFrame();
    }

    void Update()
    {
        PlayAnimation();   //캐릭터 그림 번갈아 보여주기(움직임)
    }

    //오른쪽 버튼(Tap_R)에 연결 → 다음 캐릭터
    public void Next()
    {
        if (characters == null || characters.Length == 0) return;
        index = (index + 1) % characters.Length;
        ResetFrame();
    }

    //왼쪽 버튼(Tap_L)에 연결 → 이전 캐릭터
    public void Prev()
    {
        if (characters == null || characters.Length == 0) return;
        index = (index - 1 + characters.Length) % characters.Length;
        ResetFrame();
    }

    void ResetFrame()
    {
        frame = 0;
        timer = 0f;
        ShowFrame();
    }

    void PlayAnimation()
    {
        Character c = Current();
        if (c == null || c.frames == null || c.frames.Length <= 1) return; //그림이 1장 이하면 안 움직임

        timer += Time.deltaTime;
        if (timer >= 1f / Mathf.Max(1f, frameRate))
        {
            timer = 0f;
            frame = (frame + 1) % c.frames.Length;
            ShowFrame();
        }
    }

    Character Current()
    {
        if (characters == null || characters.Length == 0) return null;
        return characters[index];
    }

    void ShowFrame()
    {
        Character c = Current();
        if (c == null || c.frames == null || c.frames.Length == 0) return;
        if (frame >= c.frames.Length) frame = 0;
        Sprite s = c.frames[frame];

        if (playerRenderer != null) playerRenderer.sprite = s;   //인게임 캐릭터
        if (previewImage != null) previewImage.sprite = s;       //시작화면 미리보기도 같이
    }
}
