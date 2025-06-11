using System;
using zkemkeeper; // Make sure to add a reference to ZKEM SDK COM library

namespace ZKTecoUserImage
{
    public class ZKManager
    {
        private CZKEM axCZKEM = new CZKEM();
        private string ip;
        private int port;

        public ZKManager(string ip, int port)
        {
            this.ip = ip;
            this.port = port;
        }

        public bool Connect()
        {
            return axCZKEM.Connect_Net(ip, port);
        }

        public void Disconnect()
        {
            axCZKEM.Disconnect();
        }

        public void RegisterEvents()
        {
            // Register for all events (65535)
            axCZKEM.RegEvent(1, 65535);
            axCZKEM.OnAttTransactionEx += new _IZKEMEvents_OnAttTransactionExEventHandler(OnAttTransactionEx);
        }

        private void OnAttTransactionEx(string EnrollNumber, int IsInValid, int AttState,
            int VerifyMethod, int Year, int Month, int Day,
            int Hour, int Minute, int Second, int WorkCode)
        {
            Console.WriteLine($"Attendance: User {EnrollNumber} at {Year}-{Month}-{Day} {Hour}:{Minute}:{Second}");

            // Try to get user photo
            string photoPath = $"user_{EnrollNumber}.jpg";
            int photoLen = 0;
            object photoData = new object();

            // This function may not be available on all models/SDK versions
            bool result = axCZKEM.GetUserPhoto(1, EnrollNumber, out photoData, out photoLen);
            if (result && photoLen > 0)
            {
                byte[] photoBytes = (byte[])photoData;
                System.IO.File.WriteAllBytes(photoPath, photoBytes);
                Console.WriteLine($"Saved user {EnrollNumber} photo to {photoPath}");
            }
            else
            {
                Console.WriteLine($"No photo available for user {EnrollNumber}");
            }
        }
    }
}