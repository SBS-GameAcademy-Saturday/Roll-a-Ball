using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private TextMeshProUGUI countText;
    [SerializeField] private TextMeshProUGUI winTextObject;

    // Field => ����
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


    // �浹�� �߻��ϴ� ������ 1�� ȣ��Ǵ� �̺�Ʈ �޼���
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

    // ������ �浹�� �߻��ϴٰ� �浹�� �̹߻��ϴ� ������ 1�� ȣ��Ǵ� �̺�Ʈ �޼���
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("OnCollisionExit");
    }

    // �浹�� �߻��ϴ� ���ȿ� ��� ȣ��Ǵ� �̺�Ʈ �޼���
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("OnCollisionStay");
    }

    // ��ħ�� �߻��ϴ� ������ 1�� ȣ��Ǵ� �̺�Ʈ �޼���
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();

        }
    }

    // ������ ��ħ�� �߻��ϴٰ� ��ħ�� �̹߻��ϴ� ������ 1�� ȣ��Ǵ� �̺�Ʈ �޼���
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit");
    }

    // ��Ĩ�� �߻��ϴ� ���ȿ� ��� ȣ��Ǵ� �̺�Ʈ �޼���
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
