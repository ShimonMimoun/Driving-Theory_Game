using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pedestrianScript : MonoBehaviour
{
    [SerializeField] private Animator m_animator;
    [SerializeField] private GameObject StartPoint;
    [SerializeField] private GameObject EndPoint;
    [SerializeField] float alpha = 0.01f;
    [SerializeField] float speed = 3;
    public AudioClip crushSound;
    public ParticleSystem explosionParticle;
    private Transform destination;
    private bool endDest = true;
    [SerializeField] float WaitTime = 3;
    private bool move = true;
    public AudioSource playerAudio;
    private bool die = false;

    private void Start()
    {
        destination = EndPoint.transform;
        explosionParticle.Stop();
    }
    void Update()
    {
        if (move && !die)
        {
            float step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, destination.position, step);
            // Check if the position of the cube and sphere are approximately equal.
            if (Vector3.Distance(transform.position, destination.position) < alpha)
            {
                m_animator.SetBool("Locking_Around", true);
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
                transform.LookAt(destination);
                move = false;
                StartCoroutine(WalkerWait());
            }
        }
    }
    IEnumerator WalkerWait()
    {
        yield return new WaitForSeconds(WaitTime);
        m_animator.SetBool("Locking_Around", false);
        move = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            m_animator.SetBool("Death_b", true);
            m_animator.SetInteger("DeathType_int", 1);
            move = false;
            if (!die)
            {
                explosionParticle.Play();
                playerAudio.PlayOneShot(crushSound);
                gameObject.GetComponent<BoxCollider>().enabled = false;
            }
            die = true;
        }
    }
}
