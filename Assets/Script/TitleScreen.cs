using UnityEngine;
using UnityEngine.SceneManagement;  // �V�[���Ǘ��p

public class TitleScreen : MonoBehaviour
{
    // �X�^�[�g�{�^�����������Ƃ��ɌĂяo����郁�\�b�h
    public void StartGame()
    {
        SceneManager.LoadScene("Play");  // �Q�[���V�[���ɑJ��
    }

    // �I���{�^�����������Ƃ��ɌĂяo����郁�\�b�h
    public void ExitGame()
    {
        Application.Quit();  // �Q�[�����I��
    }
}
