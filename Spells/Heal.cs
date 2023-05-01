using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Heal : Spell
{
    public Heal(int minPower, bool verbalComponent, bool motorComponent):base(minPower,verbalComponent,motorComponent){}
    public Heal():base(){}
    public override void Say(Wizard wizard, Wizard obj)
    {
        if(Learned)
        {
            if(obj.State == "болен")
            {
                Console.Write("Выберите состояние(1-здоров; 2-ослаблен): ");
                int i = Convert.ToInt32(Console.ReadLine());
                switch(i)
                {
                    case 1:
                    {
                        obj.State = "здоров";
                        if(wizard.Mana - 20 < 0) wizard.Mana = 0;
                        else wizard.Mana -= 20;
                        break;
                    }
                    case 2:
                    {
                        obj.State = "ослаблен";
                        if(wizard.Mana - 20 < 0) wizard.Mana = 0;
                        else wizard.Mana -= 20;
                        break;
                    }
                    default:
                        throw new Exception("Не верный выбор");
                }
            }
            else Console.WriteLine("Персонаж не болен. ");
        }
        else Console.WriteLine("Заклинание не выучено!");
    }

    public override void Say(Wizard wizard, Character obj)
    {
        if(Learned)
        {
            if(obj.State == "болен")
            {
                Console.Write("Выберите состояние(1-здоров; 2-ослаблен): ");
                int i = Convert.ToInt32(Console.ReadLine());
                switch(i)
                {
                    case 1:
                    {
                        obj.State = "здоров";
                        if(wizard.Mana - 20 < 0) wizard.Mana = 0;
                        else wizard.Mana -= 20;
                        break;
                    }
                    case 2:
                    {
                        obj.State = "ослаблен";
                        if(wizard.Mana - 20 < 0) wizard.Mana = 0;
                        else wizard.Mana -= 20;
                        break;
                    }
                    default:
                        throw new Exception("Не верный выбор");
                }
            }
            else Console.WriteLine("Персонаж не болен. ");
        }
        else Console.WriteLine("Заклинание не выучено!");
    }

    public override string ToString()
    {
        return "Вылечить: Минимальная мощность(" + MinPower + "), Вербальный компонент(" + VerbalComponent + "), Моторный компонент(" + MotorComponent + ")";
    }
}
