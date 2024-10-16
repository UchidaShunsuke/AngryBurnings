using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void QuitGame()
    {
        // エディター内ではこの機能は動作しないが、ビルド後のゲームで動作する
        Application.Quit();

        // デバッグ用（エディターでゲーム終了をシミュレーション）
        Debug.Log("Game is Exit...");
    }
}
