using UnityEngine;

public class PupilBehaviour : MonoBehaviour
{
    public GameObject Player;
    private Vector3 basePosition;
    [SerializeField]
    private SpriteRenderer BackEye;
    [SerializeField]
    private SpriteRenderer Tree;
    [SerializeField]
    private SpriteRenderer mySpriteRendered;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mySpriteRendered = this.gameObject.GetComponent<SpriteRenderer>();
        Player = FindFirstObjectByType<FlowerSystem>().gameObject;
        basePosition = transform.localPosition;
        Tree = transform.parent.parent.parent.GetComponent<SpriteRenderer>();
        BackEye = transform.parent.GetComponent<SpriteRenderer>();
        BackEye.sortingOrder = Tree.sortingOrder - 2;
        BackEye.sortingLayerName = Tree.sortingLayerName;
        this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = Tree.sortingOrder - 1;
        mySpriteRendered.sortingLayerName = Tree.sortingLayerName;

    }

    // Update is called once per frame
    void Update()
    {
        var direction = Player.transform.position - transform.parent.position;
        float dirX = Mathf.Clamp(direction.x, -0.5f, 0.5f);
        float dirY = Mathf.Clamp(direction.y, -0.5f, 0.5f);
        transform.localPosition = new Vector3(basePosition.x + dirX, basePosition.y + dirY, 0);
        
    }
}
