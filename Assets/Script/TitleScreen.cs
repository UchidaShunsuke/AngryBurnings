using UnityEngine;
using UnityEngine.SceneManagement;  // シーン管理用

public class TitleScreen : MonoBehaviour
{
    // スタートボタンを押したときに呼び出されるメソッド
    public void StartGame()
    {
        SceneManager.LoadScene("Play");  // ゲームシーンに遷移
    }

    // 終了ボタンを押したときに呼び出されるメソッド
    public void ExitGame()
    {
        Application.Quit();  // ゲームを終了
    }
}
