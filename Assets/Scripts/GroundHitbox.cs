using UnityEngine;

// 바닥(ground)의 히트박스(BoxCollider2D)를 인스펙터 숫자로 바로 조절하게 해주는 스크립트.
// 인스펙터에서 값을 바꾸면 에디터에서도 바로 적용된다 (OnValidate).
// 콜라이더는 같은 오브젝트에 붙어 있는 걸 자동으로 잡으므로 따로 연결 안 해도 됨.
[RequireComponent(typeof(BoxCollider2D))]
public class GroundHitbox : MonoBehaviour
{
    [Header("바닥 히트박스")]
    public Vector2 size = new Vector2(1.7f, 0.57f);   //크기 (x=가로, y=세로)
    public Vector2 offset = Vector2.zero;             //위치 보정

    [Header("연결 (자동으로 들어가 있음)")]
    public BoxCollider2D groundCollider;   //바닥의 콜라이더 (비어 있으면 자동으로 잡음)

    void Awake()
    {
        Apply();
    }

    // 컴포넌트를 처음 붙였을 때 현재 콜라이더 값을 그대로 가져온다 (에디터)
    void Reset()
    {
        groundCollider = GetComponent<BoxCollider2D>();
        if (groundCollider != null)
        {
            size = groundCollider.size;
            offset = groundCollider.offset;
        }
    }

    // 인스펙터에서 값이 바뀔 때마다 에디터에서 바로 반영
    void OnValidate()
    {
        Apply();
    }

    void Apply()
    {
        if (groundCollider == null) groundCollider = GetComponent<BoxCollider2D>();
        if (groundCollider != null)
        {
            groundCollider.size = size;
            groundCollider.offset = offset;
        }
    }
}
