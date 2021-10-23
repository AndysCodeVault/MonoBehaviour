using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    private void Awake()
    {
        print("Sphere Awakens!");
    }

    // Start is called before the first frame update
    void Start()
    {
        print("Sphere Starting");
        StartCoroutine("Orbit");
    }

    IEnumerator Orbit()
    {
        Transform cube = GameObject.Find("Cube").transform;
        float radius = 3f;
        while(true)
        {
            float x = Mathf.Cos(Time.time) * radius + cube.position.x;
            float y = cube.position.y;
            float z = Mathf.Sin(Time.time) * radius + cube.position.z;

            transform.position = new Vector3(x, y, z);
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
