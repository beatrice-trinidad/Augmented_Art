using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveObj : MonoBehaviour
{
    public Vector3 point;
    //public Vector3 countVar;
    public GameObject intrObjts;
    public GameObject intrObjtsAnalog;
    public GameObject intrWalls;
    public GameObject intrWalls2;
    public GameObject intrWalls3;
    public GameObject Bloom;
    public GameObject opacity;

    private Kino.AnalogGlitch analogGlitch;
    private Kvant.Lattice lattice;
    // Start is called before the first frame update

    void Awake()
    {
        analogGlitch = GetComponent<Kino.AnalogGlitch>();
        lattice = GetComponent<Kvant.Lattice>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * 360 * Time.deltaTime, Space.Self);
            //countVar = Vector3.up * 20 * Time.deltaTime;
            
        }
        else if (Input.GetKey(KeyCode.D))

        {
            transform.Rotate(-Vector3.up * 20 * Time.deltaTime, Space.Self);

        }
        intrObjts.GetComponent<Kino.AnalogGlitch>().colorDrift = transform.rotation.y/5;
        intrObjtsAnalog.GetComponent<Kino.DigitalGlitch>().intensity = transform.rotation.y/3;
        //lattice.noiseElevation = transform.rotation.y;
        intrWalls.GetComponent<Kvant.Lattice>().noiseElevation = transform.rotation.y*30;
        intrWalls2.GetComponent<Kvant.Lattice>().noiseElevation = transform.rotation.y * 30;
        intrWalls3.GetComponent<Kvant.Lattice>().noiseElevation = transform.rotation.y * 30;

        //Bloom.GetComponent<Kino.Bloom>().intensity = transform.rotation.y * 5;
        //opacity.GetComponent<Kino.Ramp>().opacity = transform.rotation.y * 5;
    }
}
