using UnityEngine;

public class GunFlip : MonoBehaviour
{
    // References to the gun and anchorArm
    public GameObject gun;
    public Transform anchorArm;
    public SpriteRenderer sprite;
    public GameObject firePoint;

    [SerializeField] GameObject player;

    // To store the previous rotation angle of the anchorArm
    private float previousRotation;

    // Start is called before the first frame update
    void Start()
    {
        if (anchorArm == null || gun == null)
        {
            Debug.LogError("Please assign the anchorArm and gun in the inspector.");
        }
        Vector3 currentPosition = firePoint.transform.localPosition;
        firePoint.transform.localPosition = currentPosition;

        previousRotation = anchorArm.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        float currentRotation = anchorArm.eulerAngles.z;
        float offset = (anchorArm.transform.position - player.transform.position).x;
        // Check if the anchorArm has passed through the 0-degree mark
        if (currentRotation >= 180f)
        {
            FlipGun1();
            
        }
        else if (currentRotation <= 180f)
        {
            FlipGun2();
        }

        // Store the current rotation for the next frame
        previousRotation = currentRotation;
    }

    // Function to flip the gun
 

    private void FlipGun1()
    {
        sprite.flipY = false;
        firePoint.transform.localPosition = new Vector3(0.3268053f, 0.193889f, 0f);
    }
    private void FlipGun2()
    {
        sprite.flipY = true;
        firePoint.transform.localPosition = new Vector3(0.3268053f, -0.193889f, 0f);
    }
}

