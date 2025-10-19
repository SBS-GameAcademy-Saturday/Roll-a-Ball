using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private TextMeshProUGUI countText;
    [SerializeField] private TextMeshProUGUI winTextObject;

    // Field => 변수
    // Rigidbody => class
    private Rigidbody rb;
    private Vector3 movement;
    private int count;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.gameObject.SetActive(false);
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movement = new Vector3(movementVector.x, 0.0f, movementVector.y).normalized;
        //movement.Normalize();
        rb.AddForce(movement * speed);
    }

    private void FixedUpdate()
    {
        rb.AddForce(movement * speed);
    }


    // 충돌이 발생하는 순간에 1번 호출되는 이벤트 메서드
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Destroy the current object
            Destroy(gameObject);
            // Update the winText to display "You Lose!"
            winTextObject.gameObject.SetActive(true);
            winTextObject.text = "You Lose!";
        }
    }

    // 기존에 충돌이 발생하다가 충돌이 미발생하는 순간에 1번 호출되는 이벤트 메서드
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("OnCollisionExit");
    }

    // 충돌이 발생하는 동안에 계속 호출되는 이벤트 메서드
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("OnCollisionStay");
    }

    // 겹침이 발생하는 순간에 1번 호출되는 이벤트 메서드
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();

        }
    }

    // 기존에 겹침이 발생하다가 겹침이 미발생하는 순간에 1번 호출되는 이벤트 메서드
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit");
    }

    // 겹칩이 발생하는 동안에 계속 호출되는 이벤트 메서드
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("OnTriggerStay");
    }

    private void SetCountText()
    {
        countText.text = "Count: " + count;
        if (count >= 10)
        {
            winTextObject.gameObject.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }
}
