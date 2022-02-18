using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;

    public Transform camAngle;

    private float horizontal;
    private float vertical;

    public float speed = 25f;

    public float rotationSpeedSmoothness = 5f;                       //Higher the value Smoother the rotation 
    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity;

    private bool groundedPlayer;
    private Vector3 playerVelocity;
    private Vector3 moveDirection;
    public float jumpHeight = 1.0f;
    public float gravityValue = -9.81f;
    public TextMeshProUGUI cdTxt;
    PhotonView pun_View;
    public Score score;
    //bool boosted = false;
    public bool isMove = false;
    public bool canJump = false;
    public bool canBoost = false;

    public bool jumpPressed;

    Vector3 direction;

    void Start()
    {
        pun_View = GetComponent<PhotonView>();
        if (!pun_View.IsMine)
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
            GetComponentInChildren<Canvas>().gameObject.SetActive(false);
        }

        StartCoroutine(MoveEnable());
    }

    IEnumerator MoveEnable()
    {
        yield return new WaitForSeconds(1f);
        cdTxt.text = "2";
        yield return new WaitForSeconds(1f);
        cdTxt.text = "1";
        yield return new WaitForSeconds(1f);
        cdTxt.text = "Go";
        isMove = true;

        yield return new WaitForSeconds(1f);
        cdTxt.text = " ";
        cdTxt.gameObject.SetActive(false);



    }

    void Update()
    {
        if (pun_View.IsMine)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");




            MovePlayer();



        }
    }

    void MovePlayer()
    {

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }


        if (isMove)
        {
            direction = new Vector3(0, 0f, 1).normalized;

        }

        if (direction.magnitude >= 0.1f)
        {

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camAngle.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            controller.Move(moveDirection.normalized * speed * Time.deltaTime);
       

        }

         if (canJump && jumpPressed)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            canJump = false;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        moveDirection += playerVelocity;
        controller.Move(playerVelocity * Time.deltaTime);

    }


    public void JumpButton()
    {
       jumpPressed = true;
        StartCoroutine(StopJump());
    }

    IEnumerator StopJump()
    {
        yield return new WaitForSeconds(2f);
        jumpPressed = false;
    }

    public void BoostButton()
    {
        if (canBoost)
        {
            IncreaseSpeed();
        }
    }
    void IncreaseSpeed()
    {

        canBoost = false;
        speed += 20f;

        Debug.Log(speed);
        StartCoroutine(StopBoost());
    }

    IEnumerator StopBoost()
    {
        yield return new WaitForSeconds(2f);
        speed -= 20f;
    }
    public void Hit(float damage)
    {
        if (PhotonNetwork.InRoom)
        {
            pun_View.RPC("PlayerTakeDamage", RpcTarget.All, damage, pun_View.ViewID);
        }
    }
    [PunRPC]
    void PlayerTakeDamage(float damage, int viewID)
    {
        score.health -= damage;
    }
}

