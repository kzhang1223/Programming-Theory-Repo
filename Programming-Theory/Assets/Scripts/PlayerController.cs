using DoorScript;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float m_speed = 5.0f;
    private float m_sensitivity = 3.0f;

    // ENCAPSULATION
    public float speed 
    {  
        get { return m_speed; } 
        set {
            if (value < 0.0f)
            {
                Debug.LogError("You can't set a negative speed");
            } else
            {
                m_speed = value;
            }
        } 
    }
    //ENCAPSULATION
    public float sensitivity
    {
        get { return m_sensitivity; }
        set
        {
            if (value < 0.0f)
            {
                Debug.LogError("You can't set a negative sensitivity");
            }
            else
            {
                m_sensitivity = value;
            }
        }
    }

    [SerializeField] GameObject door;  
    [SerializeField] GameObject inventory;
    [SerializeField] GameObject menu;
    //[SerializeField] GameObject door2;

    private UIManager uiManager;

    // Start is called before the first frame update
    void Start()
    {
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        MoveCamera();
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

        if (speed > 0 && sensitivity > 0)
        {
            if (Input.GetKey(KeyCode.R))
            {
                if (!GameManager.instance.buttonSound.isPlaying)
                {
                    GameManager.instance.buttonSound.Play();
                }
                inventory.SetActive(true);
                speed = 0;
                sensitivity = 0;
            }
            else if (Input.GetKey(KeyCode.Escape))
            {
                if (!GameManager.instance.buttonSound.isPlaying)
                {
                    GameManager.instance.buttonSound.Play();
                }
                menu.SetActive(true);
                speed = 0;
                sensitivity = 0;
            }
        }
    }

    // Moves player using WASD
    void MovePlayer()
    {
        Vector3 movementDir = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
        {
            movementDir += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movementDir += Vector3.right;
        }
        if (Input.GetKey(KeyCode.W))
        {
            movementDir += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movementDir += Vector3.back;
        }

        if (movementDir != Vector3.zero)
        {
            if (!GameManager.instance.walkingSound.isPlaying)
            {
                GameManager.instance.walkingSound.Play();
            }
        } else
        {
            GameManager.instance.walkingSound.Stop();
        }
        transform.Translate(movementDir * Time.deltaTime * speed);
    }

    void MoveCamera()
    {
        float mouse = Input.GetAxis("Mouse X");
        Vector3 look = new Vector3(0, mouse * sensitivity, 0);
        transform.Rotate(look);
    }

    void OpenDoorOnE()
    {
        if (Input.GetKey(KeyCode.E))
        {
            door.GetComponent<Door>().OpenDoor();
        }
    }

    //void OpenDoor2OnE()
    //{
    //    if (Input.GetKey(KeyCode.E))
    //    {
    //        door2.GetComponent<Door>().OpenDoor();
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Door") || other.CompareTag("Door2"))
        {
            uiManager.TurnOnDoorInstructions();
        }
        else if (other.CompareTag("Egg") || other.CompareTag("Egg2"))
        {
            uiManager.TurnOnEggInstructions();
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (!door.GetComponent<Door>().open && other.CompareTag("Door"))
        {
            OpenDoorOnE();
        } 
        //else if (!door2.GetComponent<Door>().open && other.CompareTag("Door2"))
        //{
        //    OpenDoor2OnE();
        //}
        else if (other.CompareTag("Egg"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                GameManager.instance.eggSound.Play();
                GameManager.instance.walkingSound.Stop();
                SceneManager.LoadScene(1);
            }
        }
        else if (other.CompareTag("Egg2"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                SceneManager.LoadScene(1);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            uiManager.TurnOffDoorInstructions();
            door.GetComponent<Door>().open = false;
        }
        //else if (other.CompareTag("Door2"))
        //{
        //    uiManager.TurnOffDoorInstructions();
        //    door2.GetComponent<Door>().open = false;
        //}
        else if (other.CompareTag("Egg") || other.CompareTag("Egg2"))
        {
            uiManager.TurnOffEggInstructions();
        }
    }
}
