using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSC.BL
{
    public class DBConnection
    {
        public DBConnection()
        {
            ConStr = "Data Source=DESKTOP-VGG92GA;Initial Catalog=DBACSC;Integrated Security=True";
        }
        public string ConStr { get; private set; }

        public override string ToString()
        {
            return ConStr.ToString();
        }
    }
}
