using System.IO;
using UnityEngine;

// P 키를 누르면 게임 화면을 스크린샷으로 저장한다.
// 씬에 직접 붙이지 않아도, 게임이 시작되면 자동으로 생성되어 어떤 씬에서든 작동한다.
public class ScreenShotSave : MonoBehaviour
{
    public string folderName = "Screenshots";   //Assets/Screenshots 에 저장

    // 게임이 시작될 때 자동으로 이 오브젝트를 만들어 붙인다 (씬에 수동으로 안 붙여도 됨)
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void AutoCreate()
    {
        GameObject go = new GameObject("ScreenShotSave (auto)");
        go.AddComponent<ScreenShotSave>();
        DontDestroyOnLoad(go);   //씬이 바뀌어도 유지
    }

    void Update()
    {
        // P 키를 누르면 스크린샷 촬영
        if (Input.GetKeyDown(KeyCode.P))
        {
            string folderPath = Path.Combine(Application.dataPath, folderName);
            if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);

            // 파일명: Screenshot_20260619_103045_123.png (시간 기반이라 덮어쓰기 안 됨)
            string stamp = System.DateTime.Now.ToString("yyyyMMdd_HHmmss_fff");
            string path = Path.Combine(folderPath, "Screenshot_" + stamp + ".png");

            ScreenCapture.CaptureScreenshot(path);
            Debug.Log("스크린샷 저장됨: " + path);
        }
    }
}
