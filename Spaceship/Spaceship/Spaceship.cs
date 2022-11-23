using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spaceship
{
    public class Spaceship
    {
        private string parkingNumber;
        private string regNum;
        private DateTime time;

        Spaceship(string parkingNumber, string regNum) 
        {
            this.parkingNumber = parkingNumber;
            this.regNum = regNum;
            this.time= DateTime.Now;
        }

        public string getParkingNumber()
        {
            return parkingNumber;
        }

        public string getRegNum()
        {
            return regNum;
        }

        public DateTime getTime()
        {
            return time;
        }
    }
}
