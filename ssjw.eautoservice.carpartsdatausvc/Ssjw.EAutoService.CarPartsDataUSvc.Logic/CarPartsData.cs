namespace Ssjw.EAutoService.CarPartsDataUSvc.Logic
{
    using Ssjw.EAutoService.CarPartsDataUSvc.Model.Model;
    using Ssjw.EAutoService.CarPartsDataUSvc.Model.Services;
    using System.Xml;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CarPartsData : IBodyPartsData, ILiquidsData, IMechanicalPartsData, ICarParts
    {
        public static List<MechanicalPart> mechanicalParts = new List<MechanicalPart>();
        public static List<BodyPart> bodyParts = new List<BodyPart>();
        public static List<Liquid> liquids = new List<Liquid>();

        private static CarPartsDataReaderSaver readerSaver;
        private static int bodyPartCounter = 0;
        private static int liquidCounter = 0;
        private static int mechanicalPartCounter = 0;

        private static readonly object carPartsDataReaderSaverLock = new object();

        private static XmlDocument carPartsDataXmlDocument;

        private const string carPartsDataXmlFilename = "CarPartsData.xml";
        private const string carPartsDataXsdFilename = "CarPartsData.xsd";

        static CarPartsData()
        {
            lock (CarPartsData.carPartsDataReaderSaverLock)
            {
                readerSaver = new CarPartsDataReaderSaver();

                if (true)
                {
                    readerSaver.ReadFiles();
                }
                else
                {
                    CarPartsData.carPartsDataXmlDocument = readerSaver.ReadNetworkXml(carPartsDataXmlFilename, carPartsDataXsdFilename);
                    CarPartsData.bodyParts = readerSaver.ReadBodyParts(carPartsDataXmlDocument);
                    CarPartsData.liquids = readerSaver.ReadLiquids(carPartsDataXmlDocument);
                    CarPartsData.mechanicalParts = readerSaver.ReadMechanicalParts(carPartsDataXmlDocument);
                }

                if (bodyParts.Count() != 0)
                {
                    bodyPartCounter = int.Parse(bodyParts.Last().Id.Remove(0, 1));
                    bodyPartCounter++;
                }
                if (mechanicalParts.Count() != 0)
                {
                    mechanicalPartCounter = int.Parse(mechanicalParts.Last().Id.Remove(0, 1));
                    mechanicalPartCounter++;
                }
                if (liquids.Count() != 0)
                {
                    liquidCounter = int.Parse(liquids.Last().Id.Remove(0, 1));
                    liquidCounter++;
                }
            }
        }

        public List<MechanicalPart> FindMechanicalPartByDimensions(double sizeX, double sizeY, double sizeZ)
        {
            List<MechanicalPart> foundMechanicalParts = new List<MechanicalPart>();
            foreach (MechanicalPart mechanicalPart in mechanicalParts)
            {
                if (mechanicalPart.SizeX <= (sizeX) && mechanicalPart.SizeY <= (sizeY) && mechanicalPart.SizeZ <= (sizeZ) && mechanicalPart.Counter > 0)
                {
                    foundMechanicalParts.Add(mechanicalPart);
                }
            }
            return foundMechanicalParts;
        }

        public List<MechanicalPart> FindMechanicalPartByPrice(decimal minPrice, decimal maxPrice)
        {
            List<MechanicalPart> foundMechanicalParts = new List<MechanicalPart>();
            foreach (MechanicalPart mechanicalPart in mechanicalParts)
            {
                if (mechanicalPart.Price <= maxPrice && mechanicalPart.Price >= minPrice && mechanicalPart.Counter > 0)
                {
                    foundMechanicalParts.Add(mechanicalPart);
                }
            }
            return foundMechanicalParts;
        }

        public List<MechanicalPart> FindMechanicalPartByCategory(string category)
        {
            List<MechanicalPart> foundMechanicalParts = new List<MechanicalPart>();
            foreach (MechanicalPart mechanicalPart in mechanicalParts)
            {
                if (mechanicalPart.Category.Equals(category) && mechanicalPart.Counter > 0)
                {
                    foundMechanicalParts.Add(mechanicalPart);
                }
            }
            return foundMechanicalParts;
        }

        public List<MechanicalPart> GetAllMechanicalParts()
        {
            List<MechanicalPart> availableMechanicalParts = new List<MechanicalPart>();
            foreach (MechanicalPart mechanicalPart in mechanicalParts)
            {
                if (mechanicalPart.Counter > 0)
                {
                    availableMechanicalParts.Add(mechanicalPart);
                }
            }

            return availableMechanicalParts;
        }

        public List<MechanicalPart> GetAvailableAndUnavailableMechanicalParts()
        {
            return mechanicalParts;
        }

        public MechanicalPart GetMechanicalPartById(String id)
        {
            foreach (MechanicalPart mechanicalPart in mechanicalParts)
            {
                if (mechanicalPart.Id == id)
                    return mechanicalPart;
            }

            return null;
        }

        public void AddMechanicalPart(MechanicalPart mechanicalPart)
        {
            string id = "m" + mechanicalPartCounter;
            mechanicalPart.Id = id;
            mechanicalParts.Add(mechanicalPart);
            mechanicalPartCounter++;
            readerSaver.WriteFiles();
        }

        public List<BodyPart> FindBodyPartByBodyType(string bodyType)
        {
            List<BodyPart> foundBodyParts = new List<BodyPart>();
            foreach (BodyPart bodyPart in bodyParts)
            {
                if (bodyPart.BodyType.Equals(bodyType) && bodyPart.Counter > 0)
                {
                    foundBodyParts.Add(bodyPart);
                }
            }
            return foundBodyParts;
        }

        public List<BodyPart> FindBodyPartByPrice(decimal minPrice, decimal maxPrice)
        {
            List<BodyPart> foundBodyParts = new List<BodyPart>();
            foreach (BodyPart bodyPart in bodyParts)
            {
                if (bodyPart.Price <= maxPrice && bodyPart.Price >= minPrice && bodyPart.Counter > 0)
                {
                    foundBodyParts.Add(bodyPart);
                }
            }
            return foundBodyParts;
        }

        public List<BodyPart> FindBodyPartByMaterial(string material)
        {
            List<BodyPart> foundBodyParts = new List<BodyPart>();
            foreach (BodyPart bodyPart in bodyParts)
            {
                if (bodyPart.Material.Equals(material) && bodyPart.Counter > 0 )
                {
                    foundBodyParts.Add(bodyPart);
                }
            }
            return foundBodyParts;
        }

        public List<BodyPart> GetAllBodyParts()
        {
            List<BodyPart> availableBodyParts = new List<BodyPart>();
            foreach (BodyPart bodyPart in bodyParts)
            {
                if (bodyPart.Counter != 0)
                {
                    availableBodyParts.Add(bodyPart);
                }
            }
           
            return availableBodyParts;
        }

        public List<BodyPart> GetAvailableAndUnavailableBodyParts()
        {
            return bodyParts;
        }

        public BodyPart GetBodyPartById(String id)
        {
            foreach (BodyPart bodyPart in bodyParts)
            {
                if (bodyPart.Id == id)
                    return bodyPart;
            }

            return null;
        }

        public void AddBodyPart(BodyPart bodyPart)
        {
            string id = "b" + bodyPartCounter;
            bodyPart.Id = id;
            bodyParts.Add(bodyPart);
            bodyPartCounter++;
            readerSaver.WriteFiles();
        }

        public List<Liquid> FindLiquidByCategory(string category)
        {
            List<Liquid> foundLiquids = new List<Liquid>();
            foreach (Liquid liquid in liquids)
            {
                if (liquid.Category.Equals(category) && liquid.Counter > 0)
                {
                    foundLiquids.Add(liquid);
                }
            }
            return foundLiquids;
        }

        public List<Liquid> FindLiquidByPrice(decimal minPrice, decimal maxPrice)
        {
            List<Liquid> foundLiquids = new List<Liquid>();
            foreach (Liquid liquid in liquids)
            {
                if (liquid.Price <= maxPrice && liquid.Price >= minPrice && liquid.Counter > 0)
                {
                    foundLiquids.Add(liquid);
                }
            }
            return foundLiquids;
        }

        public List<Liquid> FindLiquidByDensity(int density)
        {
            List<Liquid> foundLiquids = new List<Liquid>();
            foreach (Liquid liquid in liquids)
            {
                if (liquid.Density.Equals(density) && liquid.Counter > 0)
                {
                    foundLiquids.Add(liquid);
                }
            }
            return foundLiquids;
        }

        public List<Liquid> GetAllLiquids()
        {
            List<Liquid> availableLiquids = new List<Liquid>();
            foreach (Liquid liquid in liquids)
            {
                if (liquid.Counter != 0)
                {
                    availableLiquids.Add(liquid);
                }
            }

            return availableLiquids;
        }

        public List<Liquid> GetAvailableAndUnavailableLiquids()
        {
            return liquids;
        }

        public Liquid GetLiquidById(String id)
        {
            foreach (Liquid liquid in liquids)
            {
                if (liquid.Id == id)
                    return liquid;
            }

            return null;
        }

        public void AddLiquid(Liquid liquid)
        {
            string id = "l" + liquidCounter;
            liquid.Id = id;
            liquids.Add(liquid);
            liquidCounter++;
            readerSaver.WriteFiles();
        }

        public void RemoveCarPart(string id)
        {
            char type = id[0];
            switch (type)
            {
                case 'm':
                    bool mNotNull = GetMechanicalPartById(id) != null;
                    if (mNotNull)
                    {
                        MechanicalPart mechanicalPart = GetMechanicalPartById(id);
                        mechanicalPart.Counter--;
                    }
                    break;

                case 'b':
                    bool bNotNull = GetBodyPartById(id) != null;
                    if (bNotNull)
                    {
                        BodyPart bodyPart = GetBodyPartById(id);
                        bodyPart.Counter--;
                    }
                    break;

                case 'l':
                    bool lNotNull = GetLiquidById(id) != null;
                    if (lNotNull)
                    {
                        Liquid liquid = GetLiquidById(id);
                        liquid.Counter--;
                    }
                    break;
            }
            readerSaver.WriteFiles();
        }

        public void DeleteCarPart(string id)
        {
            char type = id[0];
            switch (type)
            {
                case 'm':
                    bool mNotNull = GetMechanicalPartById(id) != null;
                    if (mNotNull)
                    {
                        MechanicalPart mechanicalPart = GetMechanicalPartById(id);
                        mechanicalParts.Remove(mechanicalPart);
                    }
                    break;

                case 'b':
                    bool bNotNull = GetBodyPartById(id) != null;
                    if (bNotNull)
                    {
                        BodyPart bodyPart = GetBodyPartById(id);
                        bodyParts.Remove(bodyPart);
                    }
                    break;

                case 'l':
                    bool lNotNull = GetLiquidById(id) != null;
                    if (lNotNull)
                    {
                        Liquid liquid = GetLiquidById(id);
                        liquids.Remove(liquid);
                    }
                    break;
            }
            readerSaver.WriteFiles();
        }

        public void ChangeNumberOfAvailableParts(string id, int number)
        {
            char type = id[0];
            switch (type)
            {
                case 'm':
                    bool mNotNull = GetMechanicalPartById(id) != null;
                    if (mNotNull)
                    {
                        MechanicalPart mechanicalPart = GetMechanicalPartById(id);
                        mechanicalPart.Counter = number;
                    }
                    break;

                case 'b':
                    bool bNotNull = GetBodyPartById(id) != null;
                    if (bNotNull)
                    {
                        BodyPart bodyPart = GetBodyPartById(id);
                        bodyPart.Counter = number;
                    }
                    break;

                case 'l':
                    bool lNotNull = GetLiquidById(id) != null;
                    if (lNotNull)
                    {
                        Liquid liquid = GetLiquidById(id);
                        liquid.Counter = number;
                    }
                    break;
            }
            readerSaver.WriteFiles();
        }

        public int GetNumberOfAvailableParts(string id)
        {
            char type = id[0];
            switch (type)
            {
                case 'm':
                    bool mNotNull = GetMechanicalPartById(id) != null;
                    if (mNotNull)
                    {
                        MechanicalPart mechanicalPart = GetMechanicalPartById(id);
                        return mechanicalPart.Counter;
                    }
                    break;

                case 'b':
                    bool bNotNull = GetBodyPartById(id) != null;
                    if (bNotNull)
                    {
                        BodyPart bodyPart = GetBodyPartById(id);
                        return bodyPart.Counter;
                    }
                    break;

                case 'l':
                    bool lNotNull = GetLiquidById(id) != null;
                    if (lNotNull)
                    {
                        Liquid liquid = GetLiquidById(id);
                        return liquid.Counter;
                    }
                    break;
            }

            return -1;
        }
    }
}
