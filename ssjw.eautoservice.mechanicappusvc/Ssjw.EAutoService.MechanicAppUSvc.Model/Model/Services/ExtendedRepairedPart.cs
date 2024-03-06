namespace Ssjw.EAutoService.MechanicAppUSvc.Model.Model.Services
{
    public class ExtendedRepairedPart
    {
        public string CarPart { get; set; }
        public string CauseOfRepair { get; set; }

        public ExtendedRepairedPart() { }

        public ExtendedRepairedPart(string carPart, string causeOfRepair)
        {
            this.CarPart = carPart;
            this.CauseOfRepair = causeOfRepair;
        }

        public override string ToString()
        {
            return "Car part: " + CarPart + " Cause of repair: " + CauseOfRepair;
        }
    }
}
