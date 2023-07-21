using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeControls : MonoBehaviour
{
    #region Instance
    private static SwipeControls instance;
    public static SwipeControls Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SwipeControls>();
                if (instance == null)
                {
                    instance = new GameObject("Spawned SwipeControls", typeof(SwipeControls)).GetComponent<SwipeControls>();
                }
            }

            return instance;
        }
        set
        {
            instance = value;
        }
    }
    #endregion

    private float deadzone = 5f;
    public bool swipeleft, swiperight;
    private Vector2 swipedelta, starttouch;
    private float lasttap;
    private float sqrdeadzone;

    public Animator anim;


    #region public properties
    public Vector2 Swipedelta { get { return swipedelta; } }
    public bool Swipeleft { get { return swipeleft; } }
    public bool Swiperight { get { return swiperight; } }
    #endregion

    private void Start()
    {
        sqrdeadzone = deadzone * deadzone;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {

    }

    public void LateUpdate()
    {
        swipeleft = swiperight = false;

        UpdateMobile();

        if (Input.GetKeyDown(KeyCode.A))
        {
            swipeleft = true;
            print("ngiri");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            swiperight = true;
            print("nganan");
        }
    }

    public void UpdateMobile()
    {
        if (Input.touches.Length != 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                starttouch = Input.mousePosition;               
                Debug.Log(Time.time - lasttap);
                lasttap = Time.time;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                starttouch = swipedelta = Vector2.zero;
            }
        }

        swipedelta = Vector2.zero;

        if(starttouch != Vector2.zero && Input.touches.Length != 0)
        {
            swipedelta = Input.touches[0].position - starttouch;
        }

        if(swipedelta.sqrMagnitude > sqrdeadzone)
        {
            float x = swipedelta.x;
            float y = swipedelta.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                if (x < 0)
                {
                    swipeleft = true;
                    anim.SetBool("ngiri", true);
                }
                else
                {
                    swiperight = true;
                    anim.SetBool("nganan", true);
                }
            }
            anim.SetBool("ngiri", false);
            anim.SetBool("nganan", false);
            starttouch = swipedelta = Vector2.zero;
        }
    }

}
