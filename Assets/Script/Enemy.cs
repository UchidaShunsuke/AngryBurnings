using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // 死ぬ速度
    public float DieVelocity = 5;

    // Start is called before the first frame update
    void Start()
    {
        LevelManager.Instance.EnemyCountAdd();
    }

    // 衝突イベント
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.relativeVelocity.sqrMagnitude);

        if (collision.relativeVelocity.sqrMagnitude > DieVelocity)
        {
            Destroy(gameObject);
            LevelManager.Instance.EnemyDie();
        }
    }
}
