

using System.Configuration;

namespace Data.StoredProcedure
{
    public class Conexction
    {
        public string GetConnectionString()
        {
            string conexionString = "";
            var prod = EncryptionManager.Decrypt("DnGSNiEDyELYKyAJW5l0025tuH5UdV8KhDpuMov19fi/s1sc6L51juiMAuKYrr/wjoWA5Oped33RVDppqouAUHOiFxu8MTVatm9EKhHmcVuCyi1KxKeFc7ksuNHi5T+SNa7yVysH1lbhMRwWHfRCTYbH/X58OXOVeGRZpabN4fQ5FezNIwsWgdt/CtwRUpXakflSD2K4Knv3VkuaBvL1NAYC6lQtG0P3Ycl2Im8XqeB+uzHxwVSVxvtCrrEwwkl69Bk68driwOPDDUYi86pzKCvCh+s3tpoxPWxZTbf5ymsx/+RUa94dcYsZY+aYxbv+FgTdy8lMSC0GkJuD4Afrm4vvAyFkFDgwhjcO97aaIipOVTB1VyRiht8AE0nRYvPQgj8tHEA5yQ9G9MCv7nkCcy925oX35HNOo9IDepcEfY5JvEnEMPEmc1tctCZp8vvk8/WxKGAgxotgoQrNeHE84PcCpHUY9UV6BiKJe3TBWuwFW2MIAmv3nfewKqeXliX4r5EvgNjzSztAo+wyqHB/7ZdW/qngDdmREKvoCPyVArzUTtBjGEdFmeDs9gP1yEAX");
            var encrypt = EncryptionManager.Encrypt(prod);
            conexionString = prod;

            return conexionString;
        }
    }
}
