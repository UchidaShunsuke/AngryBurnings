using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToTitle : MonoBehaviour
{
    public void GoToTitle()
    {
        // タイトルシーンの名前を指定して、シーンをロードします
        SceneManager.LoadScene("Title");
    }
}
