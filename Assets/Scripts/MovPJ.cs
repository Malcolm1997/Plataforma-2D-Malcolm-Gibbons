using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPJ : MonoBehaviour
{
    public GameObject PJ;
    float mov = 5f;
    float salto = 8f;
    Rigidbody rb;
    bool piso = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            PJ.transform.position = PJ.transform.position + new Vector3(-mov * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            PJ.transform.position = PJ.transform.position + new Vector3(mov * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if(piso == true) {
                rb.velocity =Vector2.up * salto;
                piso = false;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Piso"))
        {
            piso = true;
        }
        if (collision.gameObject.CompareTag("DangerZone"))
        {
            PJ.transform.position = new Vector3(-8, -2, 0);
        }
        if (collision.gameObject.CompareTag("Win"))
        {
            Debug.Log("Gane");
        }
    }
}
