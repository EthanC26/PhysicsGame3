using UnityEngine;

public class GroundCheck : MonoBehaviour
{

    //groundcheck variables

    [SerializeField, Range(0.01f, 0.1f)] private float groundCheckRadius = 0.02f;
    [SerializeField] private LayerMask isGroundLayer;
    private Transform groundCheck;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //groundcheck initaliaztion
        GameObject newGameObject = new GameObject();
        newGameObject.transform.SetParent(transform);
        newGameObject.transform.localPosition = new Vector3 (0,-0.5f,0);
        newGameObject.name = "GroundCheck";
        groundCheck = newGameObject.transform;
    }

    // Update is called once per frame
    public bool isGrounded()
    {
        if (!groundCheck) return false;
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGroundLayer);
    }


}