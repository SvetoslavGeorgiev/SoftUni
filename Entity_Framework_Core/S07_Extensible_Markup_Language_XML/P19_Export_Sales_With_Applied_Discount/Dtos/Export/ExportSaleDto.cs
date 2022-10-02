namespace CarDealer.Dtos.Export
{
    using System.Xml.Serialization;

    [XmlType("sale")]
    public class ExportSaleDto
    {
        [XmlElement("car")]
        public ExportSaleCarDto Car { get; set; }

        [XmlElement("discount")]
        public string Discount { get; set; }

        [XmlElement("customer-name")]
        public string CustomerName { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("price-with-discount")]
        public decimal PriceWithDiscount { get; set; }
    }
}
