using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToTitle : MonoBehaviour
{
    public void GoToTitle()
    {
        // �^�C�g���V�[���̖��O���w�肵�āA�V�[�������[�h���܂�
        SceneManager.LoadScene("Title");
    }
}
