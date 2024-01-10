using AppWithLocks.Primitives;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AppWithLocks.Managers
{
    class WindowsParams
    {
        private static string identifier(string wmiClass, string wmiProperty)
        //Return a hardware identifier
        {
            string result = "";
            System.Management.ManagementClass mc = new System.Management.ManagementClass(wmiClass);
            System.Management.ManagementObjectCollection moc = mc.GetInstances();
            foreach (System.Management.ManagementObject mo in moc)
            {
                //Only get the first one
                if (result == "")
                {
                    try
                    {
                        result = mo[wmiProperty].ToString();
                        break;
                    }
                    catch
                    {
                    }
                }
            }
            return result;
        }

        public static string GetDiskSerialNumber()
        {
            return identifier("Win32_DiskDrive", "SerialNumber");
        }

        public static string GetProcessorId()
        {
            return identifier("Win32_processor", "ProcessorID");
        }

        public static string GetMotherboardSerial()
        {
            return identifier("Win32_BaseBoard", "SerialNumber");
        }

        public static string GetBIOS()
        {
            return identifier("Win32_BIOS", "Version");
        }

        public static string GetVolumeSerial()
        {
            ManagementObject disk = new ManagementObject("Win32_LogicalDisk.DeviceID=\"" + "C:" + "\"");
            //bind our management object
            disk.Get();

            return disk["VolumeSerialNumber"].ToString();
        }

        public static string GetHwid(TypeActivate typeActivate)
        {
            string hwid = "";
            ManagementObjectSearcher searcher = null;

            if (typeActivate == TypeActivate.ActivateTypeProcessorAndDisk ||
                typeActivate == TypeActivate.ActivateTypeDisk)
            {
                // Get the primary hard drive serial number
                searcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_DiskDrive WHERE Index = 0");
                foreach (ManagementObject obj in searcher.Get())
                {
                    hwid += obj["SerialNumber"].ToString();
                    break;
                }
            }

            return hwid;
        }
    }
}
