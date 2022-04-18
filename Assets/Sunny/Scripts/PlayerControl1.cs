using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl1 : MonoBehaviour
{
    public LayerMask floorMask;
    public GameObject wuqiObj;
    public Transform Parent;

    

    public AudioSource AudiC;

    //弹窗界面
    public GameObject ObjPanel;
    public Text ObjText;

    // Start is called before the first frame update
    void Start()
    {
      

        

    }

    // Update is called once per frame
    void Update()
    {
        Turning();
        if (GameManager.Instance.CoinParent.transform.childCount == 0)
        {
            GameManager.Instance.successObj.SetActive(true);
        }
    }
    //生成物体
    public void createObj()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            AudiC.Play();
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            Destroy(other.gameObject);
            print("9999");
            GameManager.Instance.Count++;
            GameManager.Instance.txt_score.text = GameManager.Instance.Count.ToString();
            if (GameManager.Instance.CoinParent.transform.childCount == 0)
            {
                GameManager.Instance.successObj.SetActive(true);
            }

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        print("888");
       
    }


    private void OnCollisionExit(Collision collision)
    {
        print("111");
        if (collision.transform.tag == "coin")
        {
            print("2222");

        }
    }


    public void ClosePanel()
    {
        ObjPanel.SetActive(false);
    }

    //人物跟随鼠标旋转
    void Turning()
    {


       Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 2000, floorMask))
        {
            if (hitInfo.transform.CompareTag("Player"))
            {
                return;
            }
            Vector3 target = hitInfo.point;
            target.y = transform.position.y;
            transform.LookAt(target);

        }

    }

}
