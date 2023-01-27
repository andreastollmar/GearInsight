using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testWoW.Interface;

namespace testWoW
{
    public class Character
    {
        public Head Head { get; set; } = new Head();
        public Neck Neck { get; set; } = new Neck();
        public Shoulder Shoulder { get; set; } = new Shoulder();
        public Chest Chest { get; set; } = new Chest();
        public Waist Waist { get; set; } = new Waist();
        public Legs Legs { get; set; } = new Legs();
        public Feet Feet { get; set; } = new Feet();
        public Wrist Wrist { get; set; } = new Wrist();
        public Gloves Gloves { get; set; } = new Gloves();
        public Ring1 Ring1 { get; set; } = new Ring1();
        public Ring2 Ring2 { get; set; } = new Ring2();
        public Trinket1 Trinket1 { get; set; } = new Trinket1();
        public Trinket2 Trinket2 { get; set; } = new Trinket2();
        public Cloak Cloak { get; set; } = new Cloak();
        public Mainhand Mainhand { get; set; } = new Mainhand();
        public Offhand Offhand { get; set; } = new Offhand();
        public Tabard Tabard { get; set; } = new Tabard();
        public List<IEquipment> equipment { get; set; }

        //public Character()
        //{
        //    equipment = Item.CreateItems();
        //}
    }
}
