using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Transactions.Helpers.XML
{
    public static class Serialize
    {
        static Dictionary<Type, XmlSerializer> serializers = new Dictionary<Type, XmlSerializer>();

        public static void Save<T>(T obj, string filePath, string encode)
        {
            using (FileStream stream = File.Create(filePath))
            {
                var type = obj.GetType(); 

                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "http://www.w3.org/2001/XMLSchema");
                
                XmlSerializer serializer = GetSerializer(type);

                XmlWriter xmlWriter = XmlWriter.Create(stream, new XmlWriterSettings { OmitXmlDeclaration = false, 
                    Encoding = Encoding.GetEncoding(encode), 
                    NamespaceHandling = NamespaceHandling.OmitDuplicates
                });

                serializer.Serialize(xmlWriter, obj, ns);
            }
        }
        
        public static T Deserialize<T>(T obj, string filePath)
        {
            TextReader tr = new StreamReader(filePath); 
            XmlSerializer serializer = GetSerializer(obj.GetType()); 
            obj = (T)serializer.Deserialize(tr);  
            tr.Close();  
            return obj;
        }

        public static XmlSerializer GetSerializer<T>()
        {
            return GetSerializer(typeof(T));
        }

        public static XmlSerializer GetSerializer(Type type)
        {
            if (serializers.ContainsKey(type))
            {
                return serializers[type];
            }
            else
            {
                var serializer = new XmlSerializer(type); 
                serializers.Add(type, serializer); 
                return serializer;
            }
        }
    }
}

