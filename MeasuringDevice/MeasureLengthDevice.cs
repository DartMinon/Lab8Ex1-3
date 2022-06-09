using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DeviceControl;

namespace MeasuringDevice
{
    public class MeasureLengthDevice : MeasureDataDevice
    {
        public MeasureLengthDevice(Units deviceUnits)
        {
            unitsToUse = deviceUnits;
            measurementType = DeviceType.LENGTH;
        }

        public override decimal MetricValue()
        {
            decimal metricMostRecentMeasure;

            if (unitsToUse == Units.Metric)
            {
                metricMostRecentMeasure = Convert.ToDecimal(mostRecentMeasure);
            }
            else
            {
                decimal decimalImperialValue = Convert.ToDecimal(mostRecentMeasure);
                decimal conversionFactor = 25.4M;
                metricMostRecentMeasure = decimalImperialValue * conversionFactor;
            }

            return metricMostRecentMeasure;
        }

        public override decimal ImperialValue()
        {
            decimal imperialMostRecentMeasure;

            if (unitsToUse == Units.Imperial)
            {
                imperialMostRecentMeasure = Convert.ToDecimal(mostRecentMeasure);
            }
            else
            {
                decimal decimalMetricValue = Convert.ToDecimal(mostRecentMeasure);
                decimal conversionFactor = 0.3937M;
                imperialMostRecentMeasure = decimalMetricValue * conversionFactor;
            }

            return imperialMostRecentMeasure;
        }
    }
}
