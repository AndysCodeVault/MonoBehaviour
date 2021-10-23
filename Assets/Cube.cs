using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private void Awake()
    {
        print("Cube Awakens!");
    }

    // Start is called before the first frame update
    void Start()
    {
        print("Cube Starting");
        StartCoroutine("ChangeColor");
    }

    IEnumerator ChangeColor()
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();
        Color startColor = renderer.material.color;
        Color endColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

        float duration = Random.Range(0.5f, 2.5f);
        float startTime = Time.time;
        float endTime = Time.time + duration;


        while (Time.time < endTime)
        {
            float elapsedTime = (Time.time - startTime);
            float pctComplete = elapsedTime / duration;            
            renderer.material.color = Color.Lerp(startColor, endColor, pctComplete);
            yield return null;
        }

        StartCoroutine("ChangeColor");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
