
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class FrogLegsDecoct : Artifact
{
    public FrogLegsDecoct(int power, bool renewability = false):base(power, renewability){}
    public FrogLegsDecoct():base(){}
    public override void Use(Wizard obj)
    {
        if(obj.State == "отравлен")
        {
            Console.Write("Выберите состояние(1-здоров; 2-ослаблен): ");
            int i = Convert.ToInt32(Console.ReadLine());
            switch(i)
            {
                case 1:
                {
                    obj.State = "здоров";
                    break;
                }
                case 2:
                {
                    obj.State = "ослаблен";
                    break;
                }
                default:
                    throw new Exception("Не верный выбор");
            }
        }
        else Console.WriteLine("Персонаж не отравлен. ");
    }

    public override void Use(Character obj)
    {
        if(obj.State == "отравлен")
        {
            Console.Write("Выберите состояние(1-здоров; 2-ослаблен): ");
            int i = Convert.ToInt32(Console.ReadLine());
            switch(i)
            {
                case 1:
                {
                    obj.State = "здоров";
                    break;
                }
                case 2:
                {
                    obj.State = "ослаблен";
                    break;
                }
                default:
                    throw new Exception("Не верный выбор");
            }
        }
    }

    public override string ToString()
    {
        return base.ToString() + "Декокт из лягушачьих лапок";
    }

}
