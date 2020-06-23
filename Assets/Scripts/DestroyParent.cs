using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyParent : MonoBehaviour
{


    public void ChangeParents()
    {
        Transform temp = transform.parent.parent;
        Destroy(transform.parent.gameObject);
        transform.parent = temp;
    }
}
