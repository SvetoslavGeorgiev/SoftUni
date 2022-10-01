namespace CarDealer.Dtos.Export
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml.Serialization;

    [XmlType("part")]
    public class ExportPartsDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }


        [XmlAttribute("price")]
        public decimal Price { get; set; }

    }
}
