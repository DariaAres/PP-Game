using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Revive : Spell
{
    public Revive(int minPower, bool verbalComponent, bool motorComponent):base(minPower,verbalComponent,motorComponent){}
    public Revive():base(){}

    public override void Say(Wizard wizard, Wizard obj)
    {
        if(Learned)
        {
            if(obj.State == "мертв")
            {
                Console.Write("Выберите состояние(1-здоров; 2-ослаблен): ");
                int i = Convert.ToInt32(Console.ReadLine());
                switch(i)
                {
                    case 1:
                    {
                        obj.State = "здоров";
                        obj.Health = 1;
                        wizard.Mana -= 150;
                        break;
                    }
                    case 2:
                    {
                        obj.State = "ослаблен";
                        obj.Health = 1;
                        wizard.Mana -= 150;
                        break;
                    }
                    default:
                        throw new Exception("Не верный выбор");
                }
            }
            else Console.WriteLine("Персонаж не мертв. ");
        }
        else Console.WriteLine("Заклинание не выучено!");
    }

    public override void Say(Wizard wizard, Character obj)
    {
        if(Learned)
        {
            if(obj.State == "мертв")
            {
                Console.Write("Выберите состояние(1-здоров; 2-ослаблен): ");
                int i = Convert.ToInt32(Console.ReadLine());
                switch(i)
                {
                    case 1:
                    {
                        obj.State = "здоров";
                        obj.Health = 1;
                        wizard.Mana -= 150;
                        break;
                    }
                    case 2:
                    {
                        obj.State = "ослаблен";
                        obj.Health = 1;
                        wizard.Mana -= 150;
                        break;
                    }
                    default:
                        throw new Exception("Не верный выбор");
                }
            }
            else Console.WriteLine("Персонаж не мертв. ");
        }
        else Console.WriteLine("Заклинание не выучено!");
    }

    public override string ToString()
    {
        return ": Минимальная мощность(" + MinPower + "), Вербальный компонент(" + VerbalComponent + "), Моторный компонент(" + MotorComponent + ")";
    }
}
