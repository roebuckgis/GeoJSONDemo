using System.Collections;
using System.Data.SqlTypes;
using System.Xml;
using Microsoft.SqlServer.Server;

namespace XMLfromWebServiceCLR
{
    public partial class UserDefinedFunctions
    {
        [SqlFunction(SystemDataAccess = SystemDataAccessKind.None,
            FillRowMethodName = "FillXMLRow", TableDefinition = "ListItems xml")]
        public static IEnumerable GetXmlFromService(string restEndpoint)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(restEndpoint);
            req.Timeout = 300000;
            System.Net.WebResponse resp = req.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(sr.ReadToEnd());
            XmlNode node = xmlDocument;
            return node;

        }
        private static void FillXMLRow(object obj, out SqlXml list)
        {
            XmlNode node = (XmlNode)obj;
            XmlReader reader = new XmlNodeReader(node);
            list = new SqlXml(reader);
        }
    };
}

