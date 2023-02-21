using TMPro;
using UnityEngine;

public class RaycastTest : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private TextMeshProUGUI coins;

    private int nbCoins = 0;
    private RaycastHit hit;
    
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay (Input.mousePosition);
            if (Physics.Raycast (ray, out hit, 100)) {
                var objectHit = hit.transform.gameObject;
                
                if (objectHit.CompareTag("Brick"))
                    Destroy(objectHit);
                
                else if (objectHit.CompareTag("Mystery"))
                {
                    nbCoins++;
                    coins.text = "x" + (nbCoins < 10 ? "0" + nbCoins : nbCoins);
                    MysteryBlock.Instance.OnHit(objectHit.transform.position);
                }
            }
        }
    }
}
