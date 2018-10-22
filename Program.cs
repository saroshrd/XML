using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ConsoleApplication2
{
    class Program
    {
        public static string mainXML2 = "";

        static void Main(string[] args)
        {

            XmlDocument mainXML = new XmlDocument();

            mainXML.Load("C:\\Users\\s1\\Desktop\\ePMO\\New Model\\Diagram 1.bpmn");

            mainXML2 = mainXML.InnerXml.ToString();

            using (XmlReader reader = XmlReader.Create("C:\\Users\\s1\\Desktop\\ePMO\\New Model\\Diagram 1.bpmn"))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        switch (reader.Name)
                        {

                            case "startEvent":
                                setNodeData(reader.ReadOuterXml().ToString());
                                break;

                            case "endEvent":
                                setNodeData(reader.ReadOuterXml().ToString());
                                break;

                            case "task":
                                setNodeData(reader.ReadOuterXml().ToString());
                                break;

                            case "sequenceFlow":
                                setNodeData(reader.ReadOuterXml().ToString());
                                break;

                            case "exclusiveGateway":
                                setNodeData(reader.ReadOuterXml().ToString());
                                break;
                        }
                    }

                }
            }

            Console.WriteLine(BPMNNodeData.lstBPMNNodeData.Count);
            
            foreach(BPMNNodeData x1 in BPMNNodeData.lstBPMNNodeData)
            {
                Console.WriteLine("name=" + x1.Name +"    "+ "name=" + x1.Category+"    "+ "name=" + x1.BPMNId + "    " + "x=" + x1.XCoordinate + "    "+ "x=" + x1.YCoordinate);
            }

            Console.ReadLine();
        }


        static void setNodeData(string xmlData)
        {
            XmlDocument innerXML = new XmlDocument();
            innerXML.LoadXml(xmlData);

            XmlElement root = innerXML.DocumentElement;
            string id = root.Attributes["id"].Value;
            string name = "";

            try
            {
                name = root.Attributes["name"].Value;
            }
            catch (Exception e)
            {

            }
            string TagName = innerXML.DocumentElement.Name;


            XmlDocument doc2 = new XmlDocument();
            doc2.LoadXml(mainXML2);
            XDocument doc = XDocument.Parse(mainXML2);

            XElement selectedElement = doc.Descendants()
                .Where(x => (string)x.Attribute("bpmnElement") == id).FirstOrDefault();


            XmlTextReader reader = new XmlTextReader(new StringReader(selectedElement.ToString()));
            while (reader.Read())
            {
                if(reader.Name.ToString()== "Bounds")
                {
                    BPMNNodeData.GetBPMNNodeData(id, name, TagName,Int32.Parse(reader["x"]), Int32.Parse(reader["y"]));
                }
            }

        }

    }
}


