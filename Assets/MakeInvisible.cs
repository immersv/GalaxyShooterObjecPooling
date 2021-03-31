using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeInvisible : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);

    }
}
