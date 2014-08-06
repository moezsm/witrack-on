using System.Collections.Generic;
using System.Linq;

using Thermo.DAL;

namespace Thermo.Models
{
    /// <summary>
    /// work as fruit repository
    /// </summary>
    public static class FruitRepository
    {
        /// <summary>
        /// for get fruit for specific id
        /// </summary>
        public static Fruit Get(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id.Equals(id));
        }

        /// <summary>
        /// for get all fruits
        /// </summary>
        public static IEnumerable<Fruit> GetAll()
        {
          ModuleEquipementContext db = new ModuleEquipementContext();
            List<Equipement> equipements = db.Equipements.ToList();
            var names = new string[50];
            var ids = new int[50];
            int i = 0;
            foreach (var equipement in equipements )
                                {
                                    names[i] = equipement.Name;
                                    ids[i] = equipement.EquipementID;
                                    i++;
                                }
            List<Fruit> fruits = new List<Fruit>();
            for (int j = 0; j < i; j++)
            {
                var fru = new Fruit { Name = names[0], Id = ids[0] };
                fruits.Add(fru);
            }                   

            return fruits;
        }
    }
}