using UnityEngine;

public class CheckerGround : MonoBehaviour
{
    [SerializeField] private float maxDistance;
    public bool IsGrounded => _isGrounded;
    private bool _isGrounded;
    
    private void Update()
    {
        Ray ray = new Ray(this.transform.position,Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(ray,out hit, maxDistance ))
        {
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }
    }
}