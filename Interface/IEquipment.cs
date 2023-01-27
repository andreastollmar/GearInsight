using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testWoW.Interface
{
    public interface IEquipment
    {
        public string Icon { get; set; }
        public int wowheadId { get; set; }
    }

    public class Item
    {
        public static List<IEquipment> CreateItems()
        {
            List<IEquipment> equipment = new List<IEquipment>();
            equipment.Add(new Head());
            equipment.Add(new Neck());
            equipment.Add(new Shoulder());
            equipment.Add(new Chest());
            equipment.Add(new Waist());
            equipment.Add(new Legs());
            equipment.Add(new Feet());
            equipment.Add(new Wrist());
            equipment.Add(new Gloves());
            equipment.Add(new Ring1());
            equipment.Add(new Ring2());
            equipment.Add(new Trinket1());
            equipment.Add(new Trinket2());
            equipment.Add(new Cloak());
            equipment.Add(new Mainhand());
            equipment.Add(new Offhand());
            equipment.Add(new Tabard());
            return equipment;
        }
    }

    public class Head : Item, IEquipment
    {
        public string Icon { get; set; }
        public int wowheadId { get; set; }
        // hover = någon href som ger komplett item
        // hyperlink till wowhead
    }
    public class Neck : Item, IEquipment
    {
        public string Icon { get; set; }
        public int wowheadId { get; set; }
        // hover = någon href som ger komplett item
        // hyperlink till wowhead
    }
    public class Shoulder : Item, IEquipment
    {
        public string Icon { get; set; }
        public int wowheadId { get; set; }
        // hover = någon href som ger komplett item
        // hyperlink till wowhead
    }
    public class Chest : Item, IEquipment
    {
        public string Icon { get; set; }
        public int wowheadId { get; set; }
        // hover = någon href som ger komplett item
        // hyperlink till wowhead
    }
    public class Waist : Item, IEquipment
    {
        public string Icon { get; set; }
        public int wowheadId { get; set; }
        // hover = någon href som ger komplett item
        // hyperlink till wowhead
    }
    public class Legs : Item, IEquipment
    {
        public string Icon { get; set; }
        public int wowheadId { get; set; }
        // hover = någon href som ger komplett item
        // hyperlink till wowhead
    }
    public class Feet : Item, IEquipment
    {
        public string Icon { get; set; }
        public int wowheadId { get; set; }
        // hover = någon href som ger komplett item
        // hyperlink till wowhead
    }
    public class Wrist : Item, IEquipment
    {
        public string Icon { get; set; }
        public int wowheadId { get; set; }
        // hover = någon href som ger komplett item
        // hyperlink till wowhead
    }
    public class Gloves : Item, IEquipment
    {
        public string Icon { get; set; }
        public int wowheadId { get; set; }
        // hover = någon href som ger komplett item
        // hyperlink till wowhead
    }
    public class Ring1 : Item, IEquipment
    {
        public string Icon { get; set; }
        public int wowheadId { get; set; }
        // hover = någon href som ger komplett item
        // hyperlink till wowhead
    }
    public class Ring2 : Item, IEquipment
    {
        public string Icon { get; set; }
        public int wowheadId { get; set; }
        // hover = någon href som ger komplett item
        // hyperlink till wowhead
    }
    public class Trinket1 : Item, IEquipment
    {
        public string Icon { get; set; }
        public int wowheadId { get; set; }
        // hover = någon href som ger komplett item
        // hyperlink till wowhead
    }
    public class Trinket2 : Item, IEquipment
    {
        public string Icon { get; set; }
        public int wowheadId { get; set; }
        // hover = någon href som ger komplett item
        // hyperlink till wowhead
    }
    public class Cloak : Item, IEquipment
    {
        public string Icon { get; set; }
        public int wowheadId { get; set; }
        // hover = någon href som ger komplett item
        // hyperlink till wowhead
    }
    public class Mainhand : Item, IEquipment
    {
        public string Icon { get; set; }
        public int wowheadId { get; set; }
        // hover = någon href som ger komplett item
        // hyperlink till wowhead
    }
    public class Offhand : Item, IEquipment
    {
        public string Icon { get; set; }
        public int wowheadId { get; set; }
        // hover = någon href som ger komplett item
        // hyperlink till wowhead
    }
    public class Tabard : Item, IEquipment
    {
        public string Icon { get; set; }
        public int wowheadId { get; set; }
        // hover = någon href som ger komplett item
        // hyperlink till wowhead
    }
}
