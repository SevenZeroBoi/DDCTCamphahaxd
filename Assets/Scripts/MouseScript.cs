using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class MouseScript : MonoBehaviour
{
    public static MouseScript instance;
    private void Awake()
    {
        instance = this;
    }

    public string currentMousePosition = "NONE";
    public GameObject boxcheck;

    public GameObject[] selfList;
    private GameObject[] itemOnSelf;

    public GameObject holdingItem = null;

    public bool isItemOnHold = false;

    public TMP_Text textcursor;
    public TextMeshProUGUI textcursorpos;

    void Start()
    {
        itemOnSelf = new GameObject[CombinationSystem.instance.mainIngredients.Length];
        itemOnSelf = CombinationSystem.instance.mainIngredients.Concat(CombinationSystem.instance.elementIngredients).ToArray();
    }

    private void Update()
    {
        CursorHitbox();
        FollowingText();

        if (Input.GetMouseButtonDown(0) && !isItemOnHold)
        {
            isItemOnHold=true;
            CheckShelfTag();
        }
        if (Input.GetMouseButtonUp(0))
        {
            isItemOnHold=false;
            if (holdingItem != null) holdingItem.GetComponent<Rigidbody2D>().gravityScale = 4;
            holdingItem = null;
        }

        if (holdingItem != null)
        {
            holdingItem.transform.position = boxcheck.transform.position;
        }
    }

    void FollowingText()
    {
        if (currentMousePosition != "NONE")
        {
            textcursor.text = currentMousePosition;
        }
        else
        {
            textcursor.text = "";
            textcursorpos.transform.position = boxcheck.transform.position;
            textcursorpos.transform.rotation = boxcheck.transform.rotation;
            textcursorpos.transform.localScale = boxcheck.transform.localScale;
        }
    }

    void CursorHitbox()
    {
        Vector3 mousepos = Input.mousePosition;
        Vector3 campos = Camera.main.ScreenToWorldPoint(new Vector3(mousepos.x, mousepos.y, Camera.main.nearClipPlane));
        boxcheck.transform.position = campos;
    }

    void CheckShelfTag()
    {
        for (int i = 0; i < selfList.Length ; i++)
        {
            if (currentMousePosition == "NONE") break;
            else if (selfList[i].tag == currentMousePosition)
            {
                holdingItem = Instantiate(itemOnSelf[i], boxcheck.transform.position, Quaternion.identity);
                break;
            }
            
        }
    }

   
}

