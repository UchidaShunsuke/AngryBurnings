using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void QuitGame()
    {
        // �G�f�B�^�[���ł͂��̋@�\�͓��삵�Ȃ����A�r���h��̃Q�[���œ��삷��
        Application.Quit();

        // �f�o�b�O�p�i�G�f�B�^�[�ŃQ�[���I�����V�~�����[�V�����j
        Debug.Log("Game is Exit...");
    }
}
