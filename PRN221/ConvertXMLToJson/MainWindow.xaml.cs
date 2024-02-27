using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace ConvertXMLToJson
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string jsonContent;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLoadXml_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
                openFileDialog.Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == true)
                {
                    using (StreamReader reader = File.OpenText(openFileDialog.FileName))
                    {
                        XDocument xmlDocument = XDocument.Load(reader);

                        if (xmlDocument != null && xmlDocument.Root != null)
                        {
                            MessageBox.Show(xmlDocument.ToString(), "XML Content", MessageBoxButton.OK, MessageBoxImage.Information);
                            string jsonContent = ConvertXmlToJson(xmlDocument);
                            SaveJsonToFile(jsonContent, "output.json");
                            MessageBox.Show("XML data converted to JSON and saved successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show("Invalid XML content or empty XML file.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading or converting XML file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private string ConvertXmlToJson(XDocument xmlDocument)
        {
            var rootElement = xmlDocument.Root;
            var jsonElement = ConvertXmlElementToJsonElement(rootElement);

            return JsonSerializer.Serialize(jsonElement, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }

        private JsonElement ConvertXmlElementToJsonElement(XElement xmlElement)
        {
            if (xmlElement.HasElements)
            {
                var jsonObject = new JsonObject();
                foreach (var childElement in xmlElement.Elements())
                {
                    jsonObject[childElement.Name.LocalName] = ConvertXmlElementToJsonElement(childElement);
                }
                return JsonSerializer.Deserialize<JsonElement>(jsonObject.ToString());
            }
            else
            {
                return JsonDocument.Parse($"\"{xmlElement.Value}\"").RootElement;
            }
        }

        private void SaveJsonToFile(string jsonContent, string filePath)
        {
            File.WriteAllText(filePath, jsonContent);
        }

        private class JsonObject : Dictionary<string, JsonElement>
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
