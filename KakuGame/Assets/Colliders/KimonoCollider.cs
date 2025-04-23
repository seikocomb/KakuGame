using System;
using UnityEngine;

public class KimonoCollider : MonoBehaviour
{
    Animator animator;
    AnimationController kimonoAC;
    BoxCollider sensu;

    GameObject ftipkl;
    GameObject shoulderkl;
    GameObject ftipkr;
    GameObject shoulderkr;
    GameObject headk;
    GameObject bipkl;
    GameObject bipkr;
    GameObject footkl;
    GameObject footkr;

    GameObject cubekla;
    GameObject cubekra;
    GameObject cubekb;
    GameObject cubekll;
    GameObject cubekrl;

    void Start()
    {
        animator = GetComponent<Animator>();
        kimonoAC = new AnimationController(animator);
        sensu = GameObject.Find("sensu").GetComponent<BoxCollider>();

        ftipkl = GameObject.Find("fingertip_kl");
        shoulderkl = GameObject.Find("shoulder_kl");
        ftipkr = GameObject.Find("fingertip_kr");
        shoulderkr = GameObject.Find("shoulder_kr");
        headk = GameObject.Find("head_k");
        bipkl = GameObject.Find("bip_kl");
        bipkr = GameObject.Find("bip_kr");
        footkl = GameObject.Find("foot_kl");
        footkr = GameObject.Find("foot_kr");

        cubekla = GameObject.Find("Cube_kla");
        cubekra = GameObject.Find("Cube_kra");
        cubekb = GameObject.Find("Cube_kb");
        cubekll = GameObject.Find("Cube_kll");
        cubekrl = GameObject.Find("Cube_krl");
    }

    void FixedUpdate()
    {
        cubekla.transform.position = new Vector3(0,  (ftipkl.transform.position.y + shoulderkl.transform.position.y) / 2, (ftipkl.transform.position.z + shoulderkl.transform.position.z) / 2);
        cubekla.transform.localScale = new Vector3(1, Math.Max(Math.Abs(ftipkl.transform.position.y - shoulderkl.transform.position.y), 0.1f), Math.Max(Math.Abs(ftipkl.transform.position.z - shoulderkl.transform.position.z), 0.12f));
        cubekra.transform.position = new Vector3(0,  (ftipkr.transform.position.y + shoulderkr.transform.position.y) / 2, (ftipkr.transform.position.z + shoulderkr.transform.position.z) / 2);
        cubekra.transform.localScale = new Vector3(1, Math.Max(Math.Abs(ftipkr.transform.position.y - shoulderkr.transform.position.y), 0.1f), Math.Max(Math.Abs(ftipkr.transform.position.z - shoulderkr.transform.position.z), 0.12f));
        cubekb.transform.position = new Vector3(0, (headk.transform.position.y + bipkl.transform.position.y) / 2, (headk.transform.position.z + bipkl.transform.position.z) / 2);
        cubekb.transform.localScale = new Vector3(1, Math.Max(Math.Abs(headk.transform.position.y - bipkl.transform.position.y), 0.2f), Math.Max(Math.Abs(headk.transform.position.z - bipkl.transform.position.z), 0.2f));
        cubekll.transform.position = new Vector3(0, (bipkl.transform.position.y + footkl.transform.position.y) / 2, (bipkl.transform.position.z + footkl.transform.position.z) / 2);
        cubekll.transform.localScale = new Vector3(1, Math.Max(Math.Abs(bipkl.transform.position.y - footkl.transform.position.y), 0.08f), Math.Max(Math.Abs(bipkl.transform.position.z - footkl.transform.position.z), 0.08f));
        cubekrl.transform.position = new Vector3(0, (bipkr.transform.position.y + footkr.transform.position.y) / 2, (bipkr.transform.position.z + footkr.transform.position.z) / 2);
        cubekrl.transform.localScale = new Vector3(1, Math.Max(Math.Abs(bipkr.transform.position.y - footkr.transform.position.y), 0.08f), Math.Max(Math.Abs(bipkr.transform.position.z - footkr.transform.position.z), 0.08f));
        if(kimonoAC.IsWalk)
        {
            sensu.size = new Vector3(11, 6, 0.03f);
        }
        else if(kimonoAC.IsCrouch)
        {
            if(kimonoAC.IsKick)
            {
                sensu.size = new Vector3(0.06f, 0.06f, 0.06f);
            }
            else
            {
                sensu.size = new Vector3(0, 0, 0);
            }
        }
        else if(kimonoAC.IsJump)
        {
            sensu.size = new Vector3(11, 6, 0.03f);
        }
        else
        {
            sensu.size = new Vector3(11, 6, 0.03f);
        }
        Physics.SyncTransforms();
    }
}