using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ConsoleApplication1
{
    class box
    {
        public int height;
        public int weight;
    }
    class Program
    {
        static void Main(string[] args)
        {
            XmlNodeList xnList;
            

            using (XmlReader reader= XmlReader.Create("C:\\Users\\s1\\Desktop\\ePMO\\New Model\\Diagram 1.bpmn"))
            {
                XmlDocument stripXML = new XmlDocument();
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        switch (reader.Name)
                        {

                            case "startEvent":
                                stripXML.LoadXml(stripNS(XElement.Parse(reader.ReadOuterXml())).ToString()); // suppose that myXmlString contains "<Names>...</Names>"
                                xnList = stripXML.SelectNodes("/startEvent/outgoing");
                                foreach (XmlNode xn in xnList)
                                {
                                    BPMNNodeData.GetBPMNNodeData("startEvent", reader["id"], xn.InnerText, null);
                                }
                                break;
                                
                            case "endEvent":
                                stripXML.LoadXml(stripNS(XElement.Parse(reader.ReadOuterXml())).ToString()); // suppose that myXmlString contains "<Names>...</Names>"
                                xnList = stripXML.SelectNodes("/endEvent/incoming");
                                foreach (XmlNode xn in xnList)
                                {
                                    BPMNNodeData.GetBPMNNodeData("endEvent", reader["id"], null, xn.InnerText);
                                }
                                break;
                        }
                    }
                    else 
                    {
                        Console.WriteLine(reader.Name);
                    }

                }
                


                
            }

            Console.WriteLine(BPMNNodeData.lstBPMNNodeData.Count);

            Console.ReadLine();


        }

        static XElement stripNS(XElement root)
        {
            return new XElement(
                root.Name.LocalName,
                root.HasElements ?
                    root.Elements().Select(el => stripNS(el)) :
                    (object)root.Value
            );
        }
    }


}
