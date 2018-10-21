using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    
    class BPMNNodeData
    {
        public string category { get; set; }
        public string UID { get; set; }
        public string incoming { get; set; }
        public string outgoing { get; set; }


        public static List<BPMNNodeData> lstBPMNNodeData = new List<BPMNNodeData>();
        public static List<BPMNNodeData> GetBPMNNodeData(string category,string UID,string incoming, string outgoing)
        {
            lstBPMNNodeData.Add(new BPMNNodeData(){
                                category =category,
                                UID=UID,
                                incoming=incoming,
                                outgoing=outgoing});

            return lstBPMNNodeData;

        }


    }
}
