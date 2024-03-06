namespace Ssjw.EAutoService.ServicesDataUSvc.Model.Model
{
    public class RepairedPart
    {
        public string CarPart { get; set; }
        public string CauseOfRepair { get; set; }

        public RepairedPart() { }

        public RepairedPart(string carPart, string causeOfRepair)
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
