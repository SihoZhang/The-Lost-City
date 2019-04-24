using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockTarget : MonoBehaviour
{
    [SerializeField] GameObject target;
    private void Update()
    {
        transform.LookAt(target.transform.position);
    }
}
