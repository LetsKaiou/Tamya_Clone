using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int BulletDamage;
    public static Bullet instance;
    public Quaternion firstRotation;
    public float speedY = 100;
    private float deleteTime = 5.0f;
    private Rigidbody rb;
    public float MoveSpeed = 2.0f;

    public GameObject BulletObj;

    private GameObject Player;
    private GameObject Enemy;

    public Player playersc;
    public Enemy enemysc;
    public FriendShipSelect friendsc;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        firstRotation = transform.rotation;
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        Vector3 movementSpeed = new Vector3(0, speedY, 0);
        movementSpeed = firstRotation * movementSpeed;
        rigidbody.AddForce(movementSpeed);

      

    }

    void Update()
    {
        // �e�̈ړ�
        rb.velocity = transform.forward * MoveSpeed;

        Destroy(gameObject, deleteTime);
    }

    // �e�̐ڐG���菈��
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Enemy = GameObject.Find("Enemy");
            enemysc = Enemy.GetComponent<Enemy>();
            enemysc.hp = enemysc.hp - BulletDamage;
        }

        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("�q�b�g");
            Player = GameObject.Find("Player");
            playersc = Player.GetComponent<Player>();
            playersc.hp = playersc.hp - BulletDamage;
            //Debug.Log(BulletDamage + "�_���[�W");
            //Debug.Log("���݂�HP" + playersc.hp);
        }
    }

    private void OnTriggerEnter(Collision collision)
    {
        if (collision.gameObject.name == "Child1")
        {
            friendsc.HP[0] = friendsc.HP[0] - BulletDamage;
        }
    }

}
