using System.Drawing;
using System.IO;

namespace L2_login
{
    public static partial class Util
    {
        public static Bitmap Dds2BMP(byte[] Bytes)
        {
            try
            {
                using var s = new MemoryStream(Bytes);
                //Bitmap(Stream) lazily keeps a reference to the source stream, which is
                //disposed when this method returns; clone into an independent Bitmap so
                //it keeps working once the caller stores it (e.g. in an ImageList).
                using var decoded = new Bitmap(s);
                return new Bitmap(decoded);
            }
            catch
            {
                return null;
            }
        }
    }
}
