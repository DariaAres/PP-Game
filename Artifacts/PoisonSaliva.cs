
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class PoisonSaliva : Artifact
{
    public PoisonSaliva(int power, bool renewability = true):base(power, renewability){}
    public PoisonSaliva():base(){}
    public override void Use(Wizard obj)
    {
        Console.Write("Введите силу артифакта: ");
        int power = Convert.ToInt32(Console.ReadLine());
        if(obj.State == "здоров" || obj.State == "ослаблен")
        {
            obj.State = "здоров";
            if(obj.Health - power < 0) obj.Health = 0;
            else obj.Health -= power;
            
        }
        else Console.WriteLine("Персонаж не здоров ");
    }

    public override void Use(Character obj)
    {
        Console.Write("Введите силу артифакта: ");
        int power = Convert.ToInt32(Console.ReadLine());
        if(obj.State == "здоров" || obj.State == "ослаблен")
        {
            obj.State = "здоров";
            if(obj.Health - power < 0) obj.Health = 0;
            else obj.Health -= power;
            
        }
        else Console.WriteLine("Персонаж не здоров ");
    }

    public override string ToString()
    {
        return base.ToString() + "Ядовитая слюна";
    }

}
