using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Antidote : Spell
{
    public Antidote(int minPower, bool verbalComponent, bool motorComponent):base(minPower,verbalComponent,motorComponent){}
    public Antidote():base(){}
    public override void Say(Wizard wizard, Wizard obj)
    {
        if(Learned)
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
                        wizard.Mana -= 30;
                        break;
                    }
                    case 2:
                    {
                        obj.State = "ослаблен";
                        wizard.Mana -= 30;
                        break;
                    }
                    default:
                        throw new Exception("Не верный выбор");
                }
            }
            else Console.WriteLine("Персонаж не отравлен. ");
        }
        else Console.WriteLine("Заклинание не выучено!");
    }

    public override void Say(Wizard wizard, Character obj)
    {
        if(Learned)
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
                        wizard.Mana -= 30;
                        break;
                    }
                    case 2:
                    {
                        obj.State = "ослаблен";
                        wizard.Mana -= 30;
                        break;
                    }
                    default:
                        throw new Exception("Не верный выбор");
                }
            }
            else Console.WriteLine("Персонаж не отравлен. ");
        }
        else Console.WriteLine("Заклинание не выучено!");
    }

    public override string ToString()
    {
        return "Противоядие: Минимальная мощность(" + MinPower + "), Вербальный компонент(" + VerbalComponent + "), Моторный компонент(" + MotorComponent + ")";
    }
}
