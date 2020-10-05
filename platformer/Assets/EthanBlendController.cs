using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

public class EthanBlendController : MonoBehaviour
{

    private Animator animator;
    private float move = 1;
    private float amplify = 7;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", move);
    }
}
