using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float MoveSpeed = 3;
    [SerializeField] private float JumpPow = 100;
    [SerializeField] private Animator animator;

    RaycastHit hit;

    private CharacterController _characterController;
    private Transform _transform;
    private Vector3 _moveVelocity;

    private bool jumpFlg = false;

    [SerializeField] GameObject Bullet;
    private int shotFlame;
    private bool shotFlg;
    [SerializeField] public int cooldown;

    private Vector3 ShotPos;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();

        _transform = transform;

        shotFlame = 0;
        shotFlg = false;
    }

    // Update is called once per frame
    void Update()
    {
        _moveVelocity.x = Input.GetAxis("Horizontal") * MoveSpeed;
        _moveVelocity.z = Input.GetAxis("Vertical") * MoveSpeed;

        //jumpAction();
        fryAction();

        //_characterController.Move(_moveVelocity * Time.deltaTime);

        animator.SetFloat("MoveSpeed", new Vector3(_moveVelocity.x, 0, _moveVelocity.z).magnitude);
        animator.SetBool("jumpFlg", jumpFlg);

        ShotBullet();
    }

    void FixedUpdate()
    {
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        
        Vector3 moveForward = cameraForward * Input.GetAxis("Vertical") + Camera.main.transform.right * Input.GetAxis("Horizontal");
        
        _characterController.Move(moveForward * MoveSpeed + new Vector3(0,_moveVelocity.y , 0));
        
        if(moveForward != Vector3.zero)
        {
           transform.rotation = Quaternion.LookRotation(cameraForward);
        }
    }

    void ShotBullet()
    {
        ShotPos = transform.position;
        ShotPos.x += 3;
        ShotPos.y += 10;

        shotFlame--;
        if (shotFlame <= 0)
        {
            shotFlg = false;
            shotFlame = 0;
        }
        else { shotFlg = true; }

        if (!shotFlg)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(Bullet, ShotPos, transform.rotation);
                shotFlame += cooldown;
                shotFlg = true;
            }
        }
    }

    void jumpAction()
    {
        if (IsGrounded)
        {
            jumpFlg = false;
            Debug.Log("’nã‚È‚¤");
            if (Input.GetButtonDown("Jump"))
            {
                Debug.Log("ƒWƒƒƒ“ƒv");
                _moveVelocity.y = JumpPow;
            }
        }
        else
        {
            Debug.Log("—Ž‰º‚È‚¤");
            _moveVelocity.y += (Physics.gravity.y / 3) * Time.deltaTime;
            jumpFlg = true;
        }
    }

    void fryAction()
    {
        if (Input.GetButton("Jump"))
        {

            Debug.Log("ã¸‚È‚¤");
            _moveVelocity.y += JumpPow / 240;
            jumpFlg = true;
        }
        else if (!IsGrounded)
        {
            Debug.Log("‰º~‚È‚¤");
            _moveVelocity.y += (Physics.gravity.y / 2) * Time.deltaTime;
        }
        else
        {
            _moveVelocity.y = 0;
            jumpFlg = false;
        }

    }


    private bool IsGrounded
    {
        get
        {
            var ray = new Ray(_transform.position + new Vector3(0, 0.1f), Vector3.down);
            var raycastHits = new RaycastHit[1];
            var hitCount = Physics.RaycastNonAlloc(ray, raycastHits, 0.2f);
            return hitCount >= 1;
        }
    }
}
