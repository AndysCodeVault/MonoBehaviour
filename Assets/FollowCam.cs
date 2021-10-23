using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public GameObject FollowObject;
    private Transform _followOffset;

    // Start is called before the first frame update
    void Start()
    {
        _followOffset = gameObject.transform.Find("Offset");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (FollowObject != null)
        {
            gameObject.transform.position = FollowObject.transform.position - _followOffset.localPosition;
            gameObject.transform.rotation.SetLookRotation(FollowObject.transform.position);
        }
    }
}
