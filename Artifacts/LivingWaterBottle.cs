
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class LivingWaterButtle : Artifact
{
    public LivingWaterButtle(int power, bool renewability = false):base(power,renewability){}
    public LivingWaterButtle():base(){}
    public override void Use(Character obj)
    {
        Console.Write("Выбрать бутылку(1-маленькая, 2-средняя, 3-большая)\nВыбор: ");
        switch(Convert.ToInt32(Console.ReadLine()))
        {
            case 1: {
                if(obj.MaxHealth-obj.Health < 10) obj.Health = obj.MaxHealth;
                else obj.Health += 10;
                break; 
            }
            case 2: {
                if(obj.MaxHealth-obj.Health < 25) obj.Health = obj.MaxHealth;
                else obj.Health += 25;
                break; 
            }
            case 3: {
                if(obj.MaxHealth-obj.Health <500) obj.Health = obj.MaxHealth;
                else obj.Health += 50;
                break; 
            }
            default: throw new Exception("Нет такого варианта выбора");
        }
    }

    public override string ToString()
    {
        return base.ToString() + "Бутылка живой воды";
    }
}
