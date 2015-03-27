using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XMLOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateXml(@"D:\Test\Books.xml");
            ReadXml(@"D:\Test\Books.xml");
            Console.ReadLine();
        }

        private static void CreateXml(string filePath)
        {
            //1、创建XML文档对象
            XmlDocument doc = new XmlDocument();

            //2、创建第一个行描述信息，并且添加到doc文档中
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            doc.AppendChild(dec);

            //3、创建根节点，将根节点添加到文档中
            XmlElement root = doc.CreateElement("Books");
            doc.AppendChild(root);

            //4-1、给根节点创建子节点book1，将book1添加到根节点
            XmlElement book1 = doc.CreateElement("Book");
            root.AppendChild(book1);
            //4-2、给book1添加子节点
            XmlElement book1Name = doc.CreateElement("Name");
            book1Name.InnerText = "肖申克的救赎";
            XmlElement book1Price = doc.CreateElement("Price");
            book1Price.InnerText = "36.0";
            XmlElement book1Author = doc.CreateElement("Author");
            book1Author.InnerText = "斯蒂芬金";
            book1.AppendChild(book1Name);
            book1.AppendChild(book1Price);
            book1.AppendChild(book1Author);

            //5-1、给根节点创建子节点book2，将book2添加到根节点
            XmlElement book2 = doc.CreateElement("Book");
            root.AppendChild(book2);
            //5-2、给book2添加子节点
            XmlElement book2Name = doc.CreateElement("Name");
            book2Name.InnerText = "白夜行";
            XmlElement book2Price = doc.CreateElement("Price");
            book2Price.InnerText = "24.0";
            XmlElement book2Author = doc.CreateElement("Author");
            book2Author.InnerText = "东野圭吾";
            book2.AppendChild(book2Name);
            book2.AppendChild(book2Price);
            book2.AppendChild(book2Author);
            //5-3、给节点book2添加属性——SetAttribute
            book2.SetAttribute("Id", "24");
            book2.SetAttribute("Count", "16");

            //6、保存xml到指定目录，默认会覆盖原文件
            doc.Save(filePath);

            Console.WriteLine("创建{0}成功", filePath);
        }

        private static void ReadXml(string filePath)
        {
            //1、创建XML文档对象
            XmlDocument doc = new XmlDocument();

            //2、加载指定路径的XML
            doc.Load(filePath);

            //3、获得根节点
            XmlElement root = doc.DocumentElement;

            //4-1、获得根节点的所有子节点
            //XmlNodeList allNodes = root.ChildNodes;
            //foreach (XmlNode node in allNodes)
            //{
            //    Console.WriteLine(node.InnerText);
            //}

            //4-2、获得某一级别的节点集合
            //XmlNodeList booksList = doc.SelectNodes("/Books/Book");
            //foreach (XmlNode node in booksList)
            //{
            //    Console.WriteLine(node.InnerText);
            //}

            //4-3、通过属性值获得单个指定的节点，并改变某个属性的值
            XmlNode baiYeXing = doc.SelectSingleNode("/Books/Book[@Id='24']");
            Console.WriteLine(baiYeXing.InnerText);
            Console.WriteLine(baiYeXing.Attributes["Count"].Value);
            baiYeXing.Attributes["Count"].Value = "9";
            Console.WriteLine(baiYeXing.Attributes["Count"].Value);

            doc.Save(filePath);
        }
    }
}
