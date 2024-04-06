using UnityEngine;

public class BlueLimbMovement : MonoBehaviour
{
    public Transform leftArm, rightArm, leftLeg, rightLeg;
    public float amplitude = 10f;
    public float frequency = 5f;

    private Vector3 leftArmInitialRotation, rightArmInitialRotation, leftLegInitialRotation, rightLegInitialRotation;

    void Start()
    {
        leftArmInitialRotation = leftArm.localEulerAngles;
        rightArmInitialRotation = rightArm.localEulerAngles;
        leftLegInitialRotation = leftLeg.localEulerAngles;
        rightLegInitialRotation = rightLeg.localEulerAngles;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            float time = Time.time * frequency;
            AnimateLimb(leftArm, leftArmInitialRotation, Mathf.Sin(time) * amplitude);
            AnimateLimb(rightArm, rightArmInitialRotation, -Mathf.Sin(time) * amplitude);
            AnimateLimb(leftLeg, leftLegInitialRotation, -Mathf.Sin(time) * amplitude);
            AnimateLimb(rightLeg, rightLegInitialRotation, Mathf.Sin(time) * amplitude);
        }
    }

    private void AnimateLimb(Transform limb, Vector3 initialRotation, float rotationAmount)
    {
        limb.localRotation = Quaternion.Euler(new Vector3(0, 0, initialRotation.z + rotationAmount));
    }
}
