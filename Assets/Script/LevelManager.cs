using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // �V���O���g���C���X�^���X
   public static LevelManager Instance { get; private set; }

    // �L�����N�^�[Prefab
    public GameObject CharacterPrefab;

    // �N���A�_�C�A���O
    public GameObject ClearDialog;

    //�@�G�̐�
    public int EnemyCount { get; private set; } = 0;

    private void Awake()
    {
        Instance = this;
        Instantiate(CharacterPrefab, transform.position, Quaternion.identity);
    }

    // ���̃L�����𐶐�
    public void NextCharacter()
    {
        Instantiate(CharacterPrefab, transform.position, Quaternion.identity);
    }

    // �G�̐���ǉ�
    public void EnemyCountAdd()
    {
        EnemyCount++;
    }

    // �G��|����
    AudioClip myAudioClip;
    public void EnemyDie()
    {
        EnemyCount--;
        if (EnemyCount == 0)
        {
            ClearDialog.SetActive(true);
            GetComponent<AudioSource>().Play();
        }
    }
}
