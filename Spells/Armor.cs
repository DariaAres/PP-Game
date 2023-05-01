using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Armor : Spell
{
    public Armor(int minPower, bool verbalComponent, bool motorComponent):base(minPower,verbalComponent,motorComponent){}
    public Armor():base(){}
    public void Say(Wizard wizard, Wizard obj, int digit)
    {
        
    }

    public override void Say(Wizard wizard, Character obj)
    {
        if(Learned)
        {
            Console.Write("Введите силу для произнесения заклинания: ");
            int digit = Convert.ToInt32(Console.ReadLine());
            DateTime date = DateTime.Now.AddSeconds(digit);
            int temp = obj.Health;
            while(DateTime.Now < date)
            {
                obj.Health = 10;
                wizard.Mana -= 50;
            }
            obj.Health = temp;
        }
        else Console.WriteLine("Заклинание не выучено!");
    }

    public override string ToString()
    {
        return "Броня: Минимальная мощность(" + MinPower + "), Вербальный компонент(" + VerbalComponent + "), Моторный компонент(" + MotorComponent + ")";
    }
}