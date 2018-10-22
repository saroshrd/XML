using System;
using System.Collections.Generic;
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

            mainXML.Load("C:\\Users\\1392078\\Desktop\\ePMO\\New Model_3\\Diagram 1.bpmn");

            mainXML2 = mainXML.InnerXml.ToString();

            using (XmlReader reader = XmlReader.Create("C:\\Users\\1392078\\Desktop\\ePMO\\New Model_3\\Diagram 1.bpmn"))
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
                                sequenceFlowData(reader.ReadOuterXml().ToString());
                                break;

                            case "exclusiveGateway":
                                setNodeData(reader.ReadOuterXml().ToString());
                                break;
                        }
                    }

                }
            }
            Console.ReadLine();
        }


        static void setNodeData(string xmlData) {
            XmlDocument innerXML = new XmlDocument();
            innerXML.LoadXml(xmlData);

            XmlElement root = innerXML.DocumentElement;
            string id = root.Attributes["id"].Value;
            string name="";

            try
            {
                name = root.Attributes["name"].Value;
            }
            catch(Exception e)
            {

            }
            string TagName = innerXML.DocumentElement.Name;

            string xml = "<parent><f1 id='bar'><foo id='bar2' /><foo id='baz' /></f1></parent>";



            XDocument doc = XDocument.Parse(mainXML2);
            string idToFind = "Id_e9cfee48-6117-491d-b6bc-de1ee7d6cd97";
            XElement selectedElement = doc.Descendants()
                .Where(x => (string)x.Attribute("id") == idToFind).FirstOrDefault();
            Console.WriteLine(selectedElement);



            //Console.WriteLine("--------------");
            //Console.WriteLine(TagName);
            //Console.WriteLine(id);

        }

        static void sequenceFlowData(string xmlData)
        {

        }
    }


}