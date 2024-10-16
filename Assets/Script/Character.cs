using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // �J�n�ʒu
    private Vector2 _StartPosition;

    // ��������ő勗��
    public float MaxPullDistance = 1;

    // ��΂���
    public float FlyForce = 10;

    // ��񂾂��ǂ���
    private bool _IsFly = false;

    // �h�b�gPrefab
    public GameObject DotPrefab;

    // �h�b�g�`��Ԋu
    public float DotTimeInterval = 0.05f;

    // �h�b�g�I�u�W�F�N�g���X�g
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

    // �}�E�X�h���b�O�C�x���g
    public void OnMouseDrag()
    {
        if (_IsFly) return;

        Vector2 Position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Vector2.Distance(_StartPosition, Position) > MaxPullDistance)
            Position = (Position - _StartPosition).normalized * MaxPullDistance + _StartPosition;

        /* �v���C���[���E�����ɍs���Ȃ�
        if (Position.x > _StartPosition.x )
            Position.x = _StartPosition.x;
        */

        transform.position = Position;

        UpdateDotObjects();
    }

    // �}�E�X�𗣂�����
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

    // �Փ˃C�x���g
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject, 8);
        GetComponent<AudioSource>().Stop();
    }

    // ���̃L�����𐶐�
    private void NextCharacter()
    {
        LevelManager.Instance.NextCharacter();
    }

    //�h�b�g�̏���
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

            Position.z = -1; // �K�v�ɉ�����Z���W�𖾎��I�ɐݒ�

            // ��ʒ����Ƀh�b�g�����u��
            //var Position = new Vector2(0, 0);

            // �h�b�g�̏ꏊ�m�F
            //Debug.Log($"Dot {i} Position: {Position}");

            _DotObjects[i].transform.position = Position;
            CurrentTime += DotTimeInterval;
        }
    }
}
