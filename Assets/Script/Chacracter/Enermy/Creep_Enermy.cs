using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creep_Enermy : Base_Enermy
{
    // Start is called before the first frame update
    void Start()
    {
        Enermy_Rotation_Default();
    }

    // Update is called once per frame
    void Update()
    {
        Enermy_Move();
    }
    public override void Enermy_Rotation_Default()
    {
        base.Enermy_Rotation_Default();
    }
    public override void Enermy_Move()
    {
        base.Enermy_Move();
    }
}
