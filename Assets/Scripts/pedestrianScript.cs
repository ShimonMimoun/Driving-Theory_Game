using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pedestrianScript : MonoBehaviour
{
    [SerializeField] private Animator m_animator;
    [SerializeField] private Rigidbody m_rigidBody;
    [SerializeField] private GameObject StartPoint;
    [SerializeField] private GameObject EndPoint;
    [SerializeField] float TurnAngle = 180f;
    [SerializeField] float alpha = 0.01f;
    [SerializeField] float speed = 10;
    [SerializeField] float check = 1;
    private Transform destination;
    private bool endDest = true;
    [SerializeField] float WaitTime = 2;
    private bool move = true;

    private void Start()
    {
        destination = EndPoint.transform;
    }
    void Update()
    {
        if (move)
        {
            float step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, destination.position, step);
            m_animator.SetFloat("MoveSpeed", speed);
            // Check if the position of the cube and sphere are approximately equal.
            if (Vector3.Distance(transform.position, destination.position) < alpha)
            {

                gameObject.transform.Rotate(0.0f, TurnAngle, 0.0f);
                if (endDest)
                {
                    destination = StartPoint.transform;
                    endDest = false;
                }
                else
                {
                    destination = EndPoint.transform;
                    endDest = true;
                }
                StartCoroutine(WalkerWait());
            }
        }
    }
    IEnumerator WalkerWait()
    {
        move = false;
        yield return new WaitForSeconds(WaitTime);
        move = true;
    }
}
