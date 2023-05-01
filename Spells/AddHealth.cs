using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class AddHealth : Spell
{
    public AddHealth(int minPower, bool verbalComponent, bool motorComponent):base(minPower,verbalComponent,motorComponent){}
    public AddHealth():base(){}
    public override void Say(Wizard wizard, Wizard obj)
    {
        if(Learned)
        {
            Console.Write("Введите силу для произнесения заклинания: ");
            int digit = Convert.ToInt32(Console.ReadLine());

            if(digit + obj.Health > 10) 
            {
                wizard.Mana -= 2 * (10 -obj.Health);
                obj.Health = 10;
            }
            else 
            {
                obj.Health += digit;
                wizard.Mana -= 2 * wizard.Mana;
            }
        }
        else Console.WriteLine("Заклинание не выучено!");

    }

    public override void Say(Wizard wizard, Character obj)
    {
        if(Learned)
        {
            Console.Write("Введите силу для произнесения заклинания: ");
            int digit = Convert.ToInt32(Console.ReadLine());
            if(digit + obj.Health > 10) 
            {
                wizard.Mana -= 2 * (10 -obj.Health);
                obj.Health = 10;
            }
            else 
            {
                obj.Health += digit;
                wizard.Mana -= 2 * wizard.Mana;
            }
        }
        else Console.WriteLine("Заклинание не выучено!");
    }
    public override string ToString()
    {
        return "Добавить здоровье: Минимальная мощность(" + MinPower + "), Вербальный компонент(" + VerbalComponent + "), Моторный компонент(" + MotorComponent + ")";
    }
}