namespace Ssjw.EAutoService.CarPartsDataUSvc.Logic
{
    using Ssjw.EAutoService.CarPartsDataUSvc.Model.Model;
    using System.Text.Json;
    using System.Diagnostics;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Linq;

    public class CarPartsDataReaderSaver
    {
        private static string bodyPartsFileName = "BodyParts.json";
        private static string liquidsFileName = "Liquids.json";
        private static string mechanicalPartsFileName = "MechanicalParts.json";

        private const string carPartsDataNamespace = "cpdata";
        private const string carPartsDataSchema = "http://tempuri.org/CarPartsData.xsd";

        public void ReadFiles()
        {
            CarPartsData.mechanicalParts = JsonSerializer.Deserialize<List<MechanicalPart>>(File.ReadAllText(mechanicalPartsFileName));
            CarPartsData.bodyParts = JsonSerializer.Deserialize<List<BodyPart>>(File.ReadAllText(bodyPartsFileName));
            CarPartsData.liquids = JsonSerializer.Deserialize<List<Liquid>>(File.ReadAllText(liquidsFileName));
        }

        public void WriteFiles()
        {
            File.WriteAllText(bodyPartsFileName, JsonSerializer.Serialize(CarPartsData.bodyParts));
            File.WriteAllText(liquidsFileName, JsonSerializer.Serialize(CarPartsData.liquids));
            File.WriteAllText(mechanicalPartsFileName, JsonSerializer.Serialize(CarPartsData.mechanicalParts));
            if (false)
            {
                this.WriteXmlFiles();
            }
        }

        public void WriteXmlFiles()
        {
            DateTime now = DateTime.Now;

            XNamespace cpdata = "http://tempuri.org/CarPartsData.xsd";

            XElement carPartsData = new XElement(cpdata + "CarPartsData");

            carPartsData.SetAttributeValue(XNamespace.Xmlns + "cpdata", "http://tempuri.org/CarPartsData.xsd");
            carPartsData.SetAttributeValue("modified", now.Date);

            XElement mechanicalPartsXml = new XElement(cpdata + "mechanicalParts");
            XElement bodyPartsXml = new XElement(cpdata + "bodyParts");
            XElement liquidsXml = new XElement(cpdata + "liquids");

            foreach (BodyPart bodyPart in CarPartsData.bodyParts)
            {
                OtherProperties otherProperties = bodyPart.OtherProperties;

                XElement bodyPartXml = new XElement(cpdata + "bodyPart"
                    , new XAttribute("id", bodyPart.Id)
                    , new XAttribute("bodyType", bodyPart.BodyType)
                    , new XAttribute("colour", bodyPart.Colour)
                    , new XAttribute("material", bodyPart.Material)
                    , new XAttribute("price", bodyPart.Price)
                    , new XAttribute("counter", bodyPart.Counter)
                    );

                XElement otherPropertiesXml = new XElement(cpdata + "otherProperties");
                XElement propertiesXml = new XElement(cpdata + "properties");

                foreach (Property property in otherProperties.Properties)
                {
                    XElement propertyXml = new XElement(cpdata + "property",
                        new XAttribute("name", property.Name),
                        new XAttribute("description", property.Description));

                    propertiesXml.Add(propertyXml);
                }

                otherPropertiesXml.Add(propertiesXml);
                bodyPartXml.Add(otherPropertiesXml);
                bodyPartsXml.Add(bodyPartXml);
            }

            foreach (MechanicalPart mechanicalPart in CarPartsData.mechanicalParts)
            {
                OtherProperties otherProperties = mechanicalPart.OtherProperties;

                XElement mechanicalPartXml = new XElement(cpdata + "mechanicalPart"
                    , new XAttribute("id", mechanicalPart.Id)
                    , new XAttribute("category", mechanicalPart.Category)
                    , new XAttribute("price", mechanicalPart.Price)
                    , new XAttribute("sizeX", mechanicalPart.SizeX)
                    , new XAttribute("sizeY", mechanicalPart.SizeY)
                    , new XAttribute("sizeZ", mechanicalPart.SizeZ)
                    , new XAttribute("description", mechanicalPart.Description)
                    , new XAttribute("counter", mechanicalPart.Counter)
                    );

                XElement otherPropertiesXml = new XElement(cpdata + "otherProperties");
                XElement propertiesXml = new XElement(cpdata + "properties");

                foreach (Property property in otherProperties.Properties)
                {
                    XElement propertyXml = new XElement(cpdata + "property",
                        new XAttribute("name", property.Name),
                        new XAttribute("description", property.Description));

                    propertiesXml.Add(propertyXml);
                }

                otherPropertiesXml.Add(propertiesXml);
                mechanicalPartXml.Add(otherPropertiesXml);
                mechanicalPartsXml.Add(mechanicalPartXml);
            }

            foreach (Liquid liquid in CarPartsData.liquids)
            {
                OtherProperties otherProperties = liquid.OtherProperties;

                XElement liquidXml = new XElement(cpdata + "liquid"
                    , new XAttribute("id", liquid.Id)
                    , new XAttribute("category", liquid.Category)
                    , new XAttribute("density", liquid.Density)
                    , new XAttribute("containsPb", liquid.ContainsPb)
                    , new XAttribute("price", liquid.Price)
                    , new XAttribute("counter", liquid.Counter)
                    );

                XElement otherPropertiesXml = new XElement(cpdata + "otherProperties");
                XElement propertiesXml = new XElement(cpdata + "properties");

                foreach (Property property in otherProperties.Properties)
                {
                    XElement propertyXml = new XElement(cpdata + "property",
                        new XAttribute("name", property.Name),
                        new XAttribute("description", property.Description));

                    propertiesXml.Add(propertyXml);
                }

                otherPropertiesXml.Add(propertiesXml);
                liquidXml.Add(otherPropertiesXml);
                liquidsXml.Add(liquidXml);
            }

            carPartsData.Add(mechanicalPartsXml);
            carPartsData.Add(bodyPartsXml);
            carPartsData.Add(liquidsXml);

            carPartsData.Save("CarPartsData.xml");
        }

        public XmlDocument ReadNetworkXml(string xmlFilename, string xsdFilename)
        {
            Debug.Assert(condition: !String.IsNullOrWhiteSpace(xmlFilename) && !String.IsNullOrWhiteSpace(xsdFilename));

            XmlDocument networkXmlDocument = new XmlDocument();

            XmlReaderSettings xmlReaderSettings = this.GetXmlReaderSettings(xsdFilename);

            using (XmlReader xmlReader = XmlReader.Create(xmlFilename, xmlReaderSettings))
            {
                networkXmlDocument.Load(xmlReader);
            }

            return networkXmlDocument;
        }

        private XmlReaderSettings GetXmlReaderSettings(string xsdFilename)
        {
            Debug.Assert(condition: !String.IsNullOrWhiteSpace(xsdFilename));

            XmlReaderSettings xmlReaderSettings = new XmlReaderSettings();

            xmlReaderSettings.Schemas.Add(null, xsdFilename);
            xmlReaderSettings.ValidationType = ValidationType.Schema;
            xmlReaderSettings.ValidationEventHandler += new ValidationEventHandler(this.ValidationEventHandler);

            return xmlReaderSettings;
        }
        private void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            throw e.Exception;
        }

        public List<BodyPart> ReadBodyParts(XmlDocument carPartsDataXmlDocument)
        {
            List<BodyPart> bodyPartList = new List<BodyPart>();

            XmlNamespaceManager xmlNamespaceManager = CarPartsDataReaderSaver.GetXmlNamespaceManager(carPartsDataXmlDocument);

            string xPath = String.Format("/cpdata:CarPartsData/cpdata:bodyParts/cpdata:bodyPart");

            XmlNodeList bodyPartsXmlNodes = carPartsDataXmlDocument.DocumentElement.SelectNodes(xPath, xmlNamespaceManager);

            foreach (XmlElement xmlElement in bodyPartsXmlNodes)
            {
                bodyPartList.Add(CarPartsDataReaderSaver.ConvertXmlElementToBodyPart(xmlElement, xmlNamespaceManager));
            }

            return bodyPartList;
        }

        public List<Liquid> ReadLiquids(XmlDocument carPartsDataXmlDocument)
        {
            List<Liquid> liquidList = new List<Liquid>();

            XmlNamespaceManager xmlNamespaceManager = CarPartsDataReaderSaver.GetXmlNamespaceManager(carPartsDataXmlDocument);

            string xPath = String.Format("/cpdata:CarPartsData/cpdata:liquids/cpdata:liquid");

            XmlNodeList bodyPartsXmlNodes = carPartsDataXmlDocument.DocumentElement.SelectNodes(xPath, xmlNamespaceManager);

            foreach (XmlElement xmlElement in bodyPartsXmlNodes)
            {
                liquidList.Add(CarPartsDataReaderSaver.ConvertXmlElementToLiquid(xmlElement, xmlNamespaceManager));
            }

            return liquidList;
        }

        public List<MechanicalPart> ReadMechanicalParts(XmlDocument carPartsDataXmlDocument)
        {
            List<MechanicalPart> mechanicalPartList = new List<MechanicalPart>();

            XmlNamespaceManager xmlNamespaceManager = CarPartsDataReaderSaver.GetXmlNamespaceManager(carPartsDataXmlDocument);

            string xPath = String.Format("/cpdata:CarPartsData/cpdata:mechanicalParts/cpdata:mechanicalPart");

            XmlNodeList bodyPartsXmlNodes = carPartsDataXmlDocument.DocumentElement.SelectNodes(xPath, xmlNamespaceManager);

            foreach (XmlElement xmlElement in bodyPartsXmlNodes)
            {
                mechanicalPartList.Add(CarPartsDataReaderSaver.ConvertXmlElementToMechanicalPart(xmlElement, xmlNamespaceManager));
            }

            return mechanicalPartList;
        }

        private static XmlNamespaceManager GetXmlNamespaceManager(XmlDocument carPartsDataXmlDocument)
        {
            XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(carPartsDataXmlDocument.NameTable);

            xmlNamespaceManager.AddNamespace(carPartsDataNamespace, carPartsDataSchema);

            return xmlNamespaceManager;
        }

        private static BodyPart ConvertXmlElementToBodyPart(XmlElement xmlElement, XmlNamespaceManager xmlNamespaceManager)
        {
            const string idAttribute = "id";
            const string bodyTypeAttribute = "bodyType";
            const string materialAttribute = "material";
            const string priceAttribute = "price";
            const string colourAttribute = "colour";
            const string counterAttribute = "counter";

            string id = xmlElement.GetAttribute(idAttribute);
            string bodyType = xmlElement.GetAttribute(bodyTypeAttribute);
            string material = xmlElement.GetAttribute(materialAttribute);
            decimal price = decimal.Parse(xmlElement.GetAttribute(priceAttribute), System.Globalization.CultureInfo.InvariantCulture);
            string colour = xmlElement.GetAttribute(colourAttribute);
            int counter = int.Parse(xmlElement.GetAttribute(counterAttribute));

            return new BodyPart(id, bodyType, material, price, colour, counter, GetOtherPropertiesFromXml(xmlElement, xmlNamespaceManager));
        }

        private static Liquid ConvertXmlElementToLiquid(XmlElement xmlElement, XmlNamespaceManager xmlNamespaceManager)
        {
            const string idAttribute = "id";
            const string categoryAttribute = "category";
            const string densityAttribute = "density";
            const string cointainsPbAttribute = "containsPb";
            const string priceAttribute = "price";
            const string counterAttribute = "counter";

            string id = xmlElement.GetAttribute(idAttribute);
            string category = xmlElement.GetAttribute(categoryAttribute);
            int density = int.Parse(xmlElement.GetAttribute(densityAttribute));
            decimal price = decimal.Parse(xmlElement.GetAttribute(priceAttribute), System.Globalization.CultureInfo.InvariantCulture);
            bool cointainsPb = bool.Parse(xmlElement.GetAttribute(cointainsPbAttribute));
            int counter = int.Parse(xmlElement.GetAttribute(counterAttribute));

            return new Liquid(id, category, density, cointainsPb, price, counter, GetOtherPropertiesFromXml(xmlElement, xmlNamespaceManager));
        }

        private static MechanicalPart ConvertXmlElementToMechanicalPart(XmlElement xmlElement, XmlNamespaceManager xmlNamespaceManager)
        {
            const string idAttribute = "id";
            const string descriptionTypeAttribute = "description";
            const string sizeXlAttribute = "sizeX";
            const string sizeYlAttribute = "sizeY";
            const string sizeZlAttribute = "sizeZ";
            const string priceAttribute = "price";
            const string categoryAttribute = "category";
            const string counterAttribute = "counter";

            string id = xmlElement.GetAttribute(idAttribute);
            string description = xmlElement.GetAttribute(descriptionTypeAttribute);
            int sizeX = int.Parse(xmlElement.GetAttribute(sizeXlAttribute));
            int sizeY = int.Parse(xmlElement.GetAttribute(sizeYlAttribute));
            int sizeZ = int.Parse(xmlElement.GetAttribute(sizeZlAttribute));
            decimal price = decimal.Parse(xmlElement.GetAttribute(priceAttribute), System.Globalization.CultureInfo.InvariantCulture);
            string category = xmlElement.GetAttribute(categoryAttribute);
            int counter = int.Parse(xmlElement.GetAttribute(counterAttribute));

            return new MechanicalPart(id, category, price, sizeX, sizeY, sizeZ, description, counter, GetOtherPropertiesFromXml(xmlElement, xmlNamespaceManager));
        }

        private static OtherProperties GetOtherPropertiesFromXml(XmlElement xmlElement, XmlNamespaceManager xmlNamespaceManager)
        {
            const string otherPropertiesElement = "cpdata:otherProperties";
            const string nameAttibute = "name";
            const string descriptionAttibute = "description";

            XmlElement otherPropertiesXmlElement = xmlElement.SelectSingleNode(otherPropertiesElement, xmlNamespaceManager) as XmlElement;

            XmlElement propertiesXmlList = otherPropertiesXmlElement.SelectSingleNode("cpdata:properties", xmlNamespaceManager) as XmlElement;

            XmlNodeList propertyXmlList = propertiesXmlList.GetElementsByTagName("cpdata:property");

            List<Property> properties = new List<Property>();

            foreach (XmlElement propertyXml in propertyXmlList)
            {
                properties.Add(new Property(propertyXml.GetAttribute(nameAttibute), propertyXml.GetAttribute(descriptionAttibute)));
            }

            OtherProperties otherProperties = new OtherProperties(properties);

            return otherProperties;
        }
    }
}
