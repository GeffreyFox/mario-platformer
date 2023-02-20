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
                var go = hit.transform.gameObject;
                
                if (go.CompareTag("Brick"))
                    Destroy(go);
                
                else if (go.CompareTag("Mystery"))
                {
                    nbCoins++;
                    coins.text = "x" + (nbCoins < 10 ? "0" + nbCoins : nbCoins);
                    MysteryBlock.Instance.OnHit(go.transform.position);
                }
            }
        }
    }
}
