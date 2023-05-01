
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class StaffOfLihtning : Artifact
{
    public StaffOfLihtning(int power, bool renewability = true):base(power, renewability){}
    public StaffOfLihtning():base(){}
    public override void Use(Character obj)
    {
        Console.Write("Введите силу артифакта: ");
        int force = Convert.ToInt32(Console.ReadLine());
        if(Power != 0)
        {
            if(obj.Health - force < 0) 
            {
                obj.Health = 0;
                if(Power - force < 0) Power = 0;
                else Power -= force;
            }
            else obj.Health -= force; 
        }
        else Console.WriteLine("Артефакт непригодный");
    }

    public override void Use(Wizard obj)
    {
        Console.Write("Введите силу артифакта: ");
        int force = Convert.ToInt32(Console.ReadLine());
        if(Power != 0)
        {
            if(obj.Health - force < 0) 
            {
                obj.Health = 0;
                if(Power - force < 0) Power = 0;
                else Power -= force;
            }
            else obj.Health -= force; 
        }
        else Console.WriteLine("Артефакт непригодный");
    }

    public override string ToString()
    {
        return base.ToString() + "Посох \"Молния\"";
    }

}
