using UnityEngine;
using System.Collections;

public class Sync : MonoBehaviour {
    private Vector3 trueLoc;
    Quaternion trueRot;
    PhotonView punView;

	// Use this for initialization
	void Start () {
        punView.GetComponent<PhotonView>();
	}

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.isReading)
        {
            if(!punView.isMine)
            {
                this.trueLoc = (Vector3)stream.ReceiveNext();
            }
        }
        else
        {
            if(punView.isMine)
            {
                stream.SendNext(transform.position);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
	    if(!punView.isMine)
        {
            transform.position = Vector3.Lerp(transform.position, trueLoc, Time.deltaTime * 5);
            transform.rotation = Quaternion.Lerp(transform.rotation, trueRot, Time.deltaTime * 5);
        }
	}
}
