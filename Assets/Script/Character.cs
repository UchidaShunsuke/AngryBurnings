using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // 開始位置
    private Vector2 _StartPosition;

    // 引っ張る最大距離
    public float MaxPullDistance = 1;

    // 飛ばす力
    public float FlyForce = 10;

    // 飛んだかどうか
    private bool _IsFly = false;

    // ドットPrefab
    public GameObject DotPrefab;

    // ドット描画間隔
    public float DotTimeInterval = 0.05f;

    // ドットオブジェクトリスト
    private GameObject[] _DotObjects = new GameObject[20];

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().isKinematic = true;
        _StartPosition = transform.position;

        for(int i = 0; i < _DotObjects.Length; i++)
        {
            _DotObjects[i] = Instantiate(DotPrefab);
            _DotObjects[i].transform.localScale = _DotObjects[i].transform.localScale * (1 - 0.03f * i);
            _DotObjects[i].transform.parent = transform;
            _DotObjects[i].SetActive(false);
        }
    }

    // マウスドラッグイベント
    public void OnMouseDrag()
    {
        if (_IsFly) return;

        Vector2 Position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Vector2.Distance(_StartPosition, Position) > MaxPullDistance)
            Position = (Position - _StartPosition).normalized * MaxPullDistance + _StartPosition;

        /* プレイヤーが右半分に行かない
        if (Position.x > _StartPosition.x )
            Position.x = _StartPosition.x;
        */

        transform.position = Position;

        UpdateDotObjects();
    }

    // マウスを離した時
    private void OnMouseUp()
    {
        if (_IsFly) return;

        var Force = (_StartPosition - (Vector2)transform.position) * FlyForce;

        var Rigidbody2D = GetComponent<Rigidbody2D>();
        Rigidbody2D.isKinematic = false;
        Rigidbody2D.AddForce(Force, ForceMode2D.Impulse);

        Invoke(nameof(NextCharacter), 1);

        for (int i = 0; i < _DotObjects.Length; i++)
            _DotObjects[i].SetActive(false);

        _IsFly = true;

        GetComponent<AudioSource>().Play();
    }

    // 衝突イベント
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject, 8);
        GetComponent<AudioSource>().Stop();
    }

    // 次のキャラを生成
    private void NextCharacter()
    {
        LevelManager.Instance.NextCharacter();
    }

    //ドットの処理
    private void UpdateDotObjects()
    {
        var Force = (_StartPosition - (Vector2)transform.position) * FlyForce;
        var CurrentTime = DotTimeInterval;
        for(int i = 0; i < _DotObjects.Length; i++)
        {
            _DotObjects[i].SetActive(true);
            var Position = new Vector3();
            Position.x = (transform.position.x + Force.x * CurrentTime);
            Position.y = (transform.position.y + Force.y * CurrentTime) - (Physics2D.gravity.magnitude * CurrentTime * CurrentTime) / 2;

            Position.z = -1; // 必要に応じてZ座標を明示的に設定

            // 画面中央にドットを仮置き
            //var Position = new Vector2(0, 0);

            // ドットの場所確認
            //Debug.Log($"Dot {i} Position: {Position}");

            _DotObjects[i].transform.position = Position;
            CurrentTime += DotTimeInterval;
        }
    }
}
