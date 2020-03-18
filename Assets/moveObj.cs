using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveObj : MonoBehaviour
{
    public Vector3 point;
    //public Vector3 countVar;
    public GameObject intrObjts;
    private Kino.AnalogGlitch analogGlitch;
    // Start is called before the first frame update

    void Awake()
    {
        analogGlitch = GetComponent<Kino.AnalogGlitch>();  
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * 20 * Time.deltaTime, Space.Self);
            //countVar = Vector3.up * 20 * Time.deltaTime;
            
        }
        else if (Input.GetKey(KeyCode.D))

        {
            transform.Rotate(-Vector3.up * 20 * Time.deltaTime, Space.Self);

        }
        intrObjts.GetComponent<Kino.AnalogGlitch>().colorDrift = transform.rotation.y;
    }
}
