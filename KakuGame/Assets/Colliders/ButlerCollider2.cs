using System;
using UnityEngine;

public class ButlerCollider2 : MonoBehaviour
{
    GameObject ftipbl;
    GameObject shoulderbl;
    GameObject ftipbr;
    GameObject shoulderbr;
    GameObject headb;
    GameObject bipbl;
    GameObject bipbr;
    GameObject footbl;
    GameObject footbr;

    GameObject cubebla;
    GameObject cubebra;
    GameObject cubebb;
    GameObject cubebll;
    GameObject cubebrl;

    void Start()
    {
        ftipbl = GameObject.Find("fingertip_bl2");
        shoulderbl = GameObject.Find("shoulder_bl2");
        ftipbr = GameObject.Find("fingertip_br2");
        shoulderbr = GameObject.Find("shoulder_br2");
        headb = GameObject.Find("head_b2");
        bipbl = GameObject.Find("bip_bl2");
        bipbr = GameObject.Find("bip_br2");
        footbl = GameObject.Find("foot_bl2");
        footbr = GameObject.Find("foot_br2");

        cubebla = GameObject.Find("Cube_bla2");
        cubebra = GameObject.Find("Cube_bra2");
        cubebb = GameObject.Find("Cube_bb2");
        cubebll = GameObject.Find("Cube_bll2");
        cubebrl = GameObject.Find("Cube_brl2");
    }

    void FixedUpdate()
    {
        cubebla.transform.position = new Vector3(0,  (ftipbl.transform.position.y + shoulderbl.transform.position.y) / 2, (ftipbl.transform.position.z + shoulderbl.transform.position.z) / 2);
        cubebla.transform.localScale = new Vector3(1, Math.Max(Math.Abs(ftipbl.transform.position.y - shoulderbl.transform.position.y), 0.1f), Math.Max(Math.Abs(ftipbl.transform.position.z - shoulderbl.transform.position.z), 0.12f));
        cubebra.transform.position = new Vector3(0,  (ftipbr.transform.position.y + shoulderbr.transform.position.y) / 2, (ftipbr.transform.position.z + shoulderbr.transform.position.z) / 2);
        cubebra.transform.localScale = new Vector3(1, Math.Max(Math.Abs(ftipbr.transform.position.y - shoulderbr.transform.position.y), 0.1f), Math.Max(Math.Abs(ftipbr.transform.position.z - shoulderbr.transform.position.z), 0.12f));
        cubebb.transform.position = new Vector3(0, (headb.transform.position.y + bipbl.transform.position.y) / 2, (headb.transform.position.z + bipbl.transform.position.z) / 2);
        cubebb.transform.localScale = new Vector3(1, Math.Max(Math.Abs(headb.transform.position.y - bipbl.transform.position.y), 0.2f), Math.Max(Math.Abs(headb.transform.position.z - bipbl.transform.position.z), 0.2f));
        cubebll.transform.position = new Vector3(0, (bipbl.transform.position.y + footbl.transform.position.y) / 2, (bipbl.transform.position.z + footbl.transform.position.z) / 2);
        cubebll.transform.localScale = new Vector3(1, Math.Max(Math.Abs(bipbl.transform.position.y - footbl.transform.position.y), 0.08f), Math.Max(Math.Abs(bipbl.transform.position.z - footbl.transform.position.z), 0.08f));
        cubebrl.transform.position = new Vector3(0, (bipbr.transform.position.y + footbr.transform.position.y) / 2, (bipbr.transform.position.z + footbr.transform.position.z) / 2);
        cubebrl.transform.localScale = new Vector3(1, Math.Max(Math.Abs(bipbr.transform.position.y - footbr.transform.position.y), 0.08f), Math.Max(Math.Abs(bipbr.transform.position.z - footbr.transform.position.z), 0.08f));
        Physics.SyncTransforms();
    }
}