using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class PlayerControll : MonoBehaviourPunCallbacks
{
    public PhotonView PV;
    public Renderer m_renderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PV.IsMine)
        {
            float speed = 7;
            float h = Input.GetAxisRaw("Horizontal"); // аб©Л ют╥бе╟
            float v = Input.GetAxisRaw("Vertical");
            transform.Translate(new Vector3(h * Time.deltaTime * speed, v * Time.deltaTime * speed, 0));
        }
        else 
        {
            
        }
    }
    public void setColor(float color)
    {
        PV.RPC("sendColor", RpcTarget.AllBuffered, color);
    }
    [PunRPC]
    void sendColor(float color)
    {
        m_renderer.material.color = new Color(color, color, color);
    }
}
