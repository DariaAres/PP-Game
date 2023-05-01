
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class BasiliskEye : Artifact
{
    public BasiliskEye(int power, bool renewability = false):base(power, renewability){}
    public BasiliskEye():base(){}
    public override void Use(Wizard obj)
    {
        if(obj.State != "мертв")
            obj.State = "парализован";
        else Console.WriteLine("Персонаж мертв ");
    }

    public override void Use(Character obj)
    {
        if(obj.State != "мертв")
            obj.State = "парализован";
        else Console.WriteLine("Персонаж мертв ");
    }

    public override string ToString()
    {
        return base.ToString() + "Глаз василиска";
    }

}
