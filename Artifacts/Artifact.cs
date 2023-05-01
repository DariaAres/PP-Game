using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

abstract class Artifact: IMagic
{
    private int power;
    private bool renewability;

    public int Power
    {
        get=>power;
        set
        {
            if(value < 0) throw new Exception("Мана меньше нуля. ");
            power = value;
        }
    }
    
    public bool Renewability { get; set; }
    public Artifact(int power, bool renewability)
    {
        Power = power;
        Renewability = renewability;
    }
    public Artifact(){}

    public void MagicImpact(Character obj)
    {
        if(obj.Health < Power) Console.WriteLine("Не хватает маны. ");
        else obj.Health -= Power;
    }
    public void MagicImpact(Wizard obj)
    {
        if(obj.Health < Power) Console.WriteLine("Не хватает маны. ");
        else obj.Health -= Power;
    }
    public virtual void Use(Character obj){}

    public virtual void Use(Wizard obj){}

    public override string ToString()
    {
        return "Артефакт - ";
    }
}