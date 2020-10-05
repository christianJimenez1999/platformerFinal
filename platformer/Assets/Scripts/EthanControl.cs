using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EthanControl : MonoBehaviour
{
    private Animator animator;
    public float moveAmplify = 1;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Horizontal") * moveAmplify;
        //new Vector3;
        animator.SetFloat("Speed",Mathf.Abs(move));
    }
}
