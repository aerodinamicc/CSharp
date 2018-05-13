using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingTaxes
{
    public delegate decimal CalcTaxes(decimal price, bool isHighRisk);

    public abstract class ShippingZones
    {
        public virtual bool IsHighRisk() => false;

        public virtual decimal CalcFee(decimal price, bool isHighRisk)
        {
            return price;
        }

        public static ShippingZones GetDestination(string zone)
        {
            if (zone == "z1")
            {
                return new ZoneOne();
            }
            if (zone == "z2")
            {
                return new ZoneTwo();
            }
            if (zone == "z3")
            {
                return new ZoneThree();
            }
            if (zone == "z4")
            {
                return new ZoneFour();
            }

            return null;
        }
    }

    internal class ZoneFour : ShippingZones
    {

        public override bool IsHighRisk()
        {
            return true;
        }

        public override decimal CalcFee(decimal price, bool isHighRisk)
        {
            if (isHighRisk)
            {
                return price * 0.04m + 25;
            }

            return price * 0.04m;
        }
    }

    internal class ZoneThree : ShippingZones
    {
        public override decimal CalcFee(decimal price, bool isHighRisk)
        {
            if (isHighRisk)
            {
                return price * 0.08m + 25;
            }

            return price * 0.08m;
        }
    }

    internal class ZoneTwo : ShippingZones
    {
        public override bool IsHighRisk()
        {
            return true;
        }

        public override decimal CalcFee(decimal price, bool isHighRisk)
        {
            if (isHighRisk)
            {
                return price * 0.12m + 25;
            }

            return price * 0.12m;
        }
    }

    internal class ZoneOne : ShippingZones
    {
        public override decimal CalcFee(decimal price, bool isHighRisk)
        {
            if (isHighRisk)
            {
                return price * 0.25m + 25;
            }

            return price * 0.25m;
        }
    }
}
