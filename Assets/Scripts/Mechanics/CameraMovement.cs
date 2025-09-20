using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float minXPos;
    [SerializeField] private float maxXPos;
    [SerializeField] private float minYPos;
    [SerializeField] private float maxYPos;
    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.PlayerInstance) return;

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(GameManager.Instance.PlayerInstance.gameObject.transform.position.x, minXPos, maxXPos);
        pos.y = Mathf.Clamp(GameManager.Instance.PlayerInstance.gameObject.transform.position.y, minYPos, maxYPos);
        transform.position = pos;
    }
}