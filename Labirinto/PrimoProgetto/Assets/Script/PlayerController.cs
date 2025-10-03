using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    CharacterController characterController;

    [SerializeField]
    public float speed;
    [SerializeField]
    public float gravity = -9.8f;


    [SerializeField] private float InputX;
    [SerializeField] private float InputZ;

    [SerializeField] private GameManager gameManager;

    [SerializeField] public AudioSource coinEffect; 
    
    [SerializeField] public AudioSource hitEffect; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.up * gravity + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.tag.Equals("Coin"))
        {

            collision.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            StartCoroutine(DestroyCoin(collision.gameObject));
        
  
        }

        if (collision.gameObject.tag.Equals("obstacle"))
        {
            hitEffect.Play(); 
            gameManager.UpdateHealt(); 
        }

    }

    private void OnControllerColliderHit(ControllerColliderHit hit){

        if (hit.gameObject.CompareTag("door"))
        {
            GameObject door = hit.gameObject;
            Vector3 PositionDoor = door.transform.position;
            door.transform.position = new Vector3(0, -10, 0);
            StartCoroutine(SpostaPortaConRitardo(door, PositionDoor));
        }

        if (hit.gameObject.CompareTag("Finish")){
            SceneManager.LoadScene("Menu");
        }
    }

    IEnumerator DestroyCoin(GameObject coin)
    {
        coinEffect.Play();
        yield return new WaitForSeconds(1);
        coin.GetComponent<MeshRenderer>().material.color = Color.red;
        gameManager.UpdateScore();
        yield return new WaitForSeconds(1);
        Destroy(coin.gameObject);
        
    }

    IEnumerator SpostaPortaConRitardo(GameObject door, Vector3 oldPosition)
    {
        door.transform.position = new Vector3(0, -10, 0);
        yield return new WaitForSeconds(3f);
        door.transform.position = oldPosition;
    }

}
