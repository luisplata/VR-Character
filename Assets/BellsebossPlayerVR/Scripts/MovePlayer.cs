using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float speed, speedRotation;
    [SerializeField] private HandActionsCustom leftHand, rightHand;
    [SerializeField] private CheckerGround cheker;
    [SerializeField] private Rigidbody rb;

    // Update is called once per frame
    void Update()
    {
        var gravity = cheker.IsGrounded ? Vector3.down/8 : Vector3.down/2;
        var _direction = leftHand.GetStick();
        var transformDirection = transform.TransformDirection(new Vector3(_direction.x, 0, _direction.y) + gravity) * (Time.deltaTime * speed);
        //ServiceLocator.Instance.GetService<DebugAdapter>().Log($"transformDirection {transformDirection}");
        rb.velocity = transformDirection;
        var rotationX = rightHand.GetStick().x;
        transform.Rotate(0, rotationX * speedRotation * Time.deltaTime, 0, Space.Self);
    }
}