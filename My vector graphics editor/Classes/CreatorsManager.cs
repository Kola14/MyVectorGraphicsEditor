using Figures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace MyVectorGraphicsEditor.Classes
{
    class CreatorsManager
    {
        public Dictionary<string, FigureCreator> Creators { get; private set; } = new Dictionary<string, FigureCreator>();

        private string configPath = @"C:\Users\Kola\source\repos\MyVectorGraphicEditor\My vector graphics editor\Config.xml";
        private string customCreatorPath = @"C:\Users\Kola\source\repos\MyVectorGraphicEditor\My vector graphics editor\bin\Debug\netcoreapp3.1\";

        public void LoadConfig()
        {
            //TODO change these ugly strings
            //TODO make the creatorPath self buildable
            var creatorPath = "MyVectorGraphicsEditor.Classes.Figures.Creators.";

            var config = new XmlDocument();

            config.Load(configPath);

            var root = config.DocumentElement;

            if (root is null) return;

            foreach (XmlElement node in root)
            {
                var figure = node?.GetAttribute("name");

                if (figure is null) return;

                var creatorName = node?.FirstChild?.InnerText;
                string fullCreatorName = creatorPath + creatorName;
                FigureCreator creator;
                if (node?.GetAttribute("isSerialized") == "false")
                {
                    creator = (FigureCreator)Type.GetType(fullCreatorName)?.GetMethod("GetInstance")?.Invoke(null, null);
                }
                else
                {
                    fullCreatorName = customCreatorPath + creatorName;
                    //TODO: finish up creator deserialization
                    creator = DeserializeCreator(fullCreatorName);
                }
                Creators[figure] = creator;
            }
        }

        public void SaveCreator(FigureCreator creator, string figureName)
        {
            SerializeCreator(creator, figureName);
            SaveCreatorToConfig(figureName);
        }

        public void AddCreator(FigureCreator creator, string figureName)
        {
            Creators[figureName] = creator;
        }

        private void SerializeCreator(FigureCreator creator, string figureName)
        {
            var formatter = new BinaryFormatter();

            using (var fileStream = new FileStream(figureName, FileMode.Create))
            {
                formatter.Serialize(fileStream, creator);

                fileStream.Close();
            }
        }

        private FigureCreator DeserializeCreator(string fileName)
        {
            var formatter = new BinaryFormatter();
            FigureCreator creator;

            using (var fileStream = new FileStream(fileName, FileMode.Open))
            {
                creator = (FigureCreator)formatter.Deserialize(fileStream);
                fileStream.Close();
            }

            return creator;
        }

        private void SaveCreatorToConfig(string figureName)
        {
            var doc = XDocument.Load(configPath);
            XElement figures = doc.Element("figures");

            figures.Add(new XElement("figure",
                new XAttribute("name", figureName),
                new XAttribute("isSerialized", "true"),
                new XElement("creator", figureName)));

            doc.Save(configPath);
        }
    }
}
