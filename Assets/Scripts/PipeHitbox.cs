using UnityEngine;

// 파이프 본체에서 위/아래 히트박스(BoxCollider2D)를 숫자로 바로 조절하게 해주는 스크립트.
// 인스펙터에서 값을 바꾸면 에디터에서도 바로 적용된다 (OnValidate).
public class PipeHitbox : MonoBehaviour
{
    [Header("위쪽 파이프 히트박스")]
    public Vector2 upSize = new Vector2(0.28f, 1.62f);   //크기 (x=가로, y=세로)
    public Vector2 upOffset = Vector2.zero;              //위치 보정

    [Header("아래쪽 파이프 히트박스")]
    public Vector2 downSize = new Vector2(0.28f, 1.62f);
    public Vector2 downOffset = Vector2.zero;

    [Header("연결 (자동으로 들어가 있음)")]
    public BoxCollider2D upCollider;    //pipeUp의 콜라이더
    public BoxCollider2D downCollider;  //pipeDn의 콜라이더

    void Awake()
    {
        Apply();
    }

    // 인스펙터에서 값이 바뀔 때마다 에디터에서 바로 반영
    void OnValidate()
    {
        Apply();
    }

    void Apply()
    {
        if (upCollider != null)
        {
            upCollider.size = upSize;
            upCollider.offset = upOffset;
        }
        if (downCollider != null)
        {
            downCollider.size = downSize;
            downCollider.offset = downOffset;
        }
    }
}
