using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // シングルトンインスタンス
   public static LevelManager Instance { get; private set; }

    // キャラクターPrefab
    public GameObject CharacterPrefab;

    // クリアダイアログ
    public GameObject ClearDialog;

    //　敵の数
    public int EnemyCount { get; private set; } = 0;

    private void Awake()
    {
        Instance = this;
        Instantiate(CharacterPrefab, transform.position, Quaternion.identity);
    }

    // 次のキャラを生成
    public void NextCharacter()
    {
        Instantiate(CharacterPrefab, transform.position, Quaternion.identity);
    }

    // 敵の数を追加
    public void EnemyCountAdd()
    {
        EnemyCount++;
    }

    // 敵を倒した
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
