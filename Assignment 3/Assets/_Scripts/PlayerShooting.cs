using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;

public class PlayerShooting : MonoBehaviour {

    //public instance variables
    public ParticleSystem muzzleFlash;
    public GameObject impact;
    public Animator rifleAnimator;
    public AudioSource bulletFireSound;

    //Private instance variable
    private GameObject[] _impacts;
    private int _currentImpact = 0;
    private int _maxImpact = 5;

    private bool _shooting = false;

	// Use this for initialization
	void Start () {
        this._impacts = new GameObject[this._maxImpact];
        for(int impactCount = 0; impactCount < this._maxImpact; impactCount++)
        {
            this._impacts[impactCount] = (GameObject) Instantiate(this.impact);
        }
	}
	
	// Update is called once per frame
	void Update () {

        //Play Muzzle Flash and shoot impact when left mouse button pressed
        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            this._shooting = true;
            this.muzzleFlash.Play();
            this.bulletFireSound.Play();
            this.rifleAnimator.SetTrigger("Fire");
        }

        if (CrossPlatformInputManager.GetButtonUp("Fire1"))
        {
            this._shooting = false;
        }

    }

    //Physics effects
    void FixedUpdate()
    {

    }
}
