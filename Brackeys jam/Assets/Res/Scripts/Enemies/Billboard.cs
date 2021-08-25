using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Transform cam;

    // Start is called before the first frame update
    private void Start()
    {
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.LookAt(cam);

        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }
}