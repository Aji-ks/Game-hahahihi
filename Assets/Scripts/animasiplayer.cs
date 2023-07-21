using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animasiplayer : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        anim.SetBool("nganan", true);
        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetBool("nganan", true);
        }
        if (!Input.GetKeyDown(KeyCode.D))
        {
            anim.SetBool("nganan", false);
        }

        anim.SetBool("ngiri", true);
        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetBool("ngiri", true);
        }
        if (!Input.GetKeyDown(KeyCode.A))
        {
            anim.SetBool("ngiri", false);
        }
    }
}
