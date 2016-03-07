using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThingWall.Data.Model
{
    /// <summary>
    /// PROTIP: Model to zwykła publiczna klasa z właściwościami prostych typów.
    /// </summary>
    public class ExampleItem
    {
        /// <summary>
        /// PROTIP: EF na zasadzie konwencji nazewnictwa
        /// potrafi nadać niektórym właściwościom specjalne znaczenie.
        /// Np. Id (lub ID, lub ExampleItemId / ID) zostaje automatycznie kluczem głównym.
        /// Można to zmodyfikować atrybutami, np [PrimaryKey]
        /// </summary>
        public int Id { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// PROTIP: virtual to wskazówka dla EF, że ta właściwość to tzw. Navigation Property.
        /// Wskazuje ona na rekord w innej tabeli, który może być doczytany dynamicznie.
        /// Bez virtual po prostu nie da się skorzystać z lazy loadingu, co wcale nie jest wadą.
        /// </summary>
        public virtual User Owner { get; set; }

        /// <summary>
        /// PROTIP: Warto do navigation property dołożyć jeszcze właściwość o typie takim jak Id
        /// we wskazywanym modelu (Id w klasie User jest typu string) i nazwie takiej jak nav. property + Id.
        /// EF automatycznie uzna tą właściwość za klucz obcy.
        /// Zachowanie to można zmodyfikować atrybutem [ForeignKey] na nav. property.
        /// </summary>
        public string OwnerId { get; set; }
    }
}
