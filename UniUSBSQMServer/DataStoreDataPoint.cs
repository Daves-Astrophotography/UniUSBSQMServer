using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniUSBSQMServer
{
    public class DataStoreDataPoint
    {

        public DateTime Timestamp { get; set; }
        public double RawMPAS { get; set; }
        public double AvgMPAS { get; set; }
        public double AvgTemp { get; set; }

        public double NELM { get; set; }

        public DataStoreDataPoint(){
            this.Timestamp = DateTime.Now;
            this.RawMPAS = 0;
            this.AvgMPAS = 0;
            this.AvgTemp = 0;
            this.NELM = 0;
        }

        public DataStoreDataPoint(DateTime timestamp, double rawMpas, double avTemp, double avMpas, double nelm)
        {
            this.Timestamp = timestamp;
            this.RawMPAS = rawMpas;
            this.AvgMPAS = avMpas;
            this.AvgTemp = avTemp;
            this.NELM = nelm;
        }

        public override string ToString()
        {
            return $"{Timestamp:yyyy-MM-dd HH:mm:ss}: Raw: {RawMPAS:#0.00} mag/arcsec\u00b2, Avg: {AvgMPAS:#0.00} mag/arcsec\u00b2, Temp: {AvgTemp:#0.0} \u00b0C, NELM: {NELM:#0.00}";
        }

    }
}
