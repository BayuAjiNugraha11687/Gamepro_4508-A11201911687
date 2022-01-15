using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    Gun[] guns;
    public Vector2 jumpForce = new Vector2(0,300);
    bool shoot;
    // Start is called before the first frame update
    void Start()
    {
        guns = transform.GetComponentsInChildren<Gun>();
    }

    // Update is called once per frame
    void Update()
    {   
        shoot = Input.GetKeyDown(KeyCode.Space);
        if (shoot)
        {
            shoot = false;
                foreach(Gun gun in guns)
                {
                    gun.Shoot();
                }
        }
        if (Input.GetKeyDown("space")){
            GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
            GetComponent<Rigidbody2D> ().AddForce(jumpForce);
        }
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.y > Screen.height || screenPosition.y < 0)
            Die ();
    }
    void Die()
    {
        Debug.Log("game over");
        SceneManager.LoadScene ("Menu");
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Die ();
    }
}
