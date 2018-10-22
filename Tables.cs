using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class BPMNNodeData
    {
        public string BPMNId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }


        public static List<BPMNNodeData> lstBPMNNodeData = new List<BPMNNodeData>();
        public static List<BPMNNodeData> GetBPMNNodeData(string UID, string name, string Category, int XCor, int YCor)
        {
            lstBPMNNodeData.Add(new BPMNNodeData()
            {
                BPMNId = UID,
                Name = name,
                Category = Category,
                XCoordinate = XCor,
                YCoordinate = YCor
            });

            return lstBPMNNodeData;

        }
    }

    class BPMNSequenceFlowData
    {
        public string SequnceFlowId { get; set; }
        public string BPMNId { get; set; }
        public string SourceRef { get; set; }
        public string TargetRef { get; set; }


        public static List<BPMNSequenceFlowData> lstSequenceFlowData = new List<BPMNSequenceFlowData>();

        public static List<BPMNSequenceFlowData> GetBPMNNodeData(string UID, string BPMNId, string SourceRef, string TargetRef)
        {
            lstSequenceFlowData.Add(new BPMNSequenceFlowData()
            {
                SequnceFlowId = UID,
                BPMNId = BPMNId,
                SourceRef = SourceRef,
                TargetRef = TargetRef
            });

            return lstSequenceFlowData;

        }

    }
}