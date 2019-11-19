using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Sims4TuitionXMLGenerator
{
    public partial class Form1 : Form
    {
        List<string> artHistoryList = new List<string>();
        List<string> biologyList = new List<string>();
        List<string> communicationsList = new List<string>();
        List<string> computerScienceList = new List<string>();
        List<string> culinaryArtsList = new List<string>();
        List<string> dramaList = new List<string>();
        List<string> economicsList = new List<string>();
        List<string> fineArtsList = new List<string>();
        List<string> historyList = new List<string>();
        List<string> languageAndLiteratureList = new List<string>();
        List<string> physicsList = new List<string>();
        List<string> psychologyList = new List<string>();
        List<string> villainyList = new List<string>();
        List<string> subjectsList = new List<string>(new string[] { "ArtHistory", "Biology", "Communications", "ComputerScience", "CulinaryArts", "Drama", "Economics", "FineArts", "History", "LanguageAndLiterature", "Physics", "Psychology", "Villainy" });
        List<string> classList = new List<string>(new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L" });

        string firstPartXML = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n" +
                             "<SimData version=\"0x00000101\" u=\"0x0000001D\">\r\n" +
                             "<Instances>\r\n<I name=\"university_CourseData_";
        string secondPartXML = (char)34 + " schema=\"UniversityCourseData\" type=\"Object\">\r\n" +
                               "<T name=\"cost\">";
        string thirdPartXML = "</T>\r\n" +
                                 "<T name=\"icon\">";
        string fourthPartXML = "</T>\r\n" +
                                 "<L name=\"university_course_mapping\">\r\n" +
                                 "<U type=\"Object\" schema=\"UniversityCourseDataMapping\">\r\n" +
                                 "<T name=\"key\">219731</T>\r\n" +
                                 "<U name=\"value\" schema=\"UniversityCourseDisplayData\">\r\n" +
                                 "<T name=\"course_description\">";
        string fifthPartXML = "</T>\r\n" +
                               "<T name=\"course_name\">";
        string sixthPartXML = "</T>\r\n" +
                                "</U>\r\n" +
                                "</U>\r\n" +
                                "<U type=\"Object\" schema=\"UniversityCourseDataMapping\">\r\n" +
                                "<T name=\"key\">219732</T>\r\n" +
                                "<U name=\"value\" schema=\"UniversityCourseDisplayData\">\r\n" +
                                "<T name=\"course_description\">";
        string seventhPartXML = "</T>\r\n" +
                                 "<T name=\"course_name\">";
        string eighthPartXML = "</T>\r\n" +
                              "</U>\r\n" +
                              "</U>\r\n" +
                              "</L>\r\n" +
                              "</I>\r\n" +
                              "</Instances>\r\n" +
                              "<Schemas>\r\n" +
                              "<Schema name=\"UniversityCourseData\" schema_hash=\"0x2835DF15\">\r\n" +
                              "<Columns>\r\n" +
                              "<Column name=\"cost\" type=\"Int32\" flags=\"0x00000000\" />\r\n" +
                              "<Column name=\"icon\" type=\"ResourceKey\" flags=\"0x00000000\" />\r\n" +
                              "<Column name=\"university_course_mapping\" type=\"Vector\" flags=\"0x00000000\" />\r\n" +
                              "</Columns>\r\n" +
                              "</Schema>\r\n" +
                              "<Schema name=\"UniversityCourseDataMapping\" schema_hash=\"0x827A3BD8\">\r\n" +
                              "<Columns>\r\n" +
                              "<Column name=\"key\" type=\"TableSetReference\" flags=\"0x00000000\" />\r\n" +
                              "<Column name=\"value\" type=\"Object\" flags=\"0x00000000\" />\r\n" +
                              "</Columns>\r\n" +
                              "</Schema>\r\n" +
                              "<Schema name=\"UniversityCourseDisplayData\" schema_hash=\"0x8A2D8C3B\">\r\n" +
                              "<Columns>\r\n" +
                              "<Column name=\"course_description\" type=\"LocalizationKey\" flags=\"0x00000000\" />\r\n" +
                              "<Column name=\"course_name\" type=\"LocalizationKey\" flags=\"0x00000000\" />\r\n" +
                              "</Columns>\r\n" +
                              "</Schema>\r\n" +
                              "</Schemas>\r\n" +
                              "</SimData>";
        string[,,] iconArray = new string[1, 2, 5] { { { "00B2D882-00000000-13BD114FBCDA48EE", "0x8BF04F9C", "0x583E5273", "0xB6E26C6C", "0x1836FBA3" }, { "00B2D882-00000000-13BD114FBCDA48EE", "0x19FDB779", "0x57820B7C", "0xA9E6C8C5", "0x32148FC0" } } };
        string iconString = "00B2D882-00000000-13BD114FBCDA48EE";
        string courseDesc1String = "0x8BF04F9C";
        string courseName1String = "0x583E5273";
        string courseDesc2String = "0xB6E26C6C";
        string courseName2String = "0x1836FBA3";
        public Form1()
        {
            InitializeComponent();
        }

        private void getFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse CSV File",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "csv",
                Filter = "csv files (*.csv)|*.csv",
                FilterIndex = 2,
                RestoreDirectory = true,
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePathTextBox.Text = openFileDialog1.FileName;
                try
                {
                    using (var reader = new StreamReader(File.OpenRead(filePathTextBox.Text)))
                    {
                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                            var values = line.Split(';');

                            artHistoryList.Add(values[1]);
                            biologyList.Add(values[2]);
                            communicationsList.Add(values[3]);
                            computerScienceList.Add(values[4]);
                            culinaryArtsList.Add(values[5]);
                            dramaList.Add(values[6]);
                            economicsList.Add(values[7]);
                            fineArtsList.Add(values[8]);
                            historyList.Add(values[9]);
                            languageAndLiteratureList.Add(values[10]);
                            physicsList.Add(values[11]);
                            psychologyList.Add(values[12]);
                            villainyList.Add(values[13]);
                        }
                    }
                }
                catch (System.IO.IOException)
                {
                    MessageBox.Show("Close the CSV file and try again.");
                    filePathTextBox.Text = "";
                    return;
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    directoryPathTextBox.Text = fbd.SelectedPath;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string finalString = "";
            int fCount = Directory.GetFiles(directoryPathTextBox.Text, "*.SimData.xml", SearchOption.TopDirectoryOnly).Length;
            if (fCount != 156)
            {
                MessageBox.Show("Wrong amount of files in directory, there should be 156 ending at .SimData.xml\r\nProcess uncompleted");
                return;
            }

            string[] fileEntries = Directory.GetFiles(directoryPathTextBox.Text);
            foreach (string fileName in fileEntries)
            {
                string line = File.ReadLines(fileName).Skip(5).Take(1).First();
                iconString = line.Substring(line.IndexOf(">")+1, 34);
                line = File.ReadLines(fileName).Skip(10).Take(1).First();
                courseDesc1String = line.Substring(line.IndexOf(">")+1, 10);
                line = File.ReadLines(fileName).Skip(11).Take(1).First();
                courseName1String = line.Substring(line.IndexOf(">")+1, 10);
                line = File.ReadLines(fileName).Skip(17).Take(1).First();
                courseDesc2String = line.Substring(line.IndexOf(">")+1, 10);
                line = File.ReadLines(fileName).Skip(18).Take(1).First();
                courseName2String = line.Substring(line.IndexOf(">")+1, 10);
                line = File.ReadLines(fileName).Skip(3).Take(1).First();
                for (int i = 0; i<13; i++)
                {
                    if (line.Contains(("_" + subjectsList[i]) + "_"))
                    {
                        for (int j = 0; j<12; j++)
                        {
                            if (line.Contains(("Class" + classList[j])))
                            {
                                switch (i+1)
                                {
                                    case 1:
                                        finalString = firstPartXML + artHistoryList[0] + "_Class" + classList[j] + secondPartXML + artHistoryList[j + 1] + thirdPartXML + iconString + fourthPartXML + courseDesc1String + fifthPartXML + courseName1String + sixthPartXML + courseDesc2String + seventhPartXML + courseName2String + eighthPartXML;
                                        break;
                                    case 2:
                                        finalString = firstPartXML + biologyList[0] + "_Class" + classList[j] + secondPartXML + biologyList[j + 1] + thirdPartXML + iconString + fourthPartXML + courseDesc1String + fifthPartXML + courseName1String + sixthPartXML + courseDesc2String + seventhPartXML + courseName2String + eighthPartXML;
                                        break;
                                    case 3:
                                        finalString = firstPartXML + communicationsList[0] + "_Class" + classList[j] + secondPartXML + communicationsList[j + 1] + thirdPartXML + iconString + fourthPartXML + courseDesc1String + fifthPartXML + courseName1String + sixthPartXML + courseDesc2String + seventhPartXML + courseName2String + eighthPartXML;
                                        break;
                                    case 4:
                                        finalString = firstPartXML + computerScienceList[0] + "_Class" + classList[j] + secondPartXML + computerScienceList[j + 1] + thirdPartXML + iconString + fourthPartXML + courseDesc1String + fifthPartXML + courseName1String + sixthPartXML + courseDesc2String + seventhPartXML + courseName2String + eighthPartXML;
                                        break;
                                    case 5:
                                        finalString = firstPartXML + culinaryArtsList[0] + "_Class" + classList[j] + secondPartXML + culinaryArtsList[j + 1] + thirdPartXML + iconString + fourthPartXML + courseDesc1String + fifthPartXML + courseName1String + sixthPartXML + courseDesc2String + seventhPartXML + courseName2String + eighthPartXML;
                                        break;
                                    case 6:
                                        finalString = firstPartXML + dramaList[0] + "_Class" + classList[j] + secondPartXML + dramaList[j + 1] + thirdPartXML + iconString + fourthPartXML + courseDesc1String + fifthPartXML + courseName1String + sixthPartXML + courseDesc2String + seventhPartXML + courseName2String + eighthPartXML;
                                        break;
                                    case 7:
                                        finalString = firstPartXML + economicsList[0] + "_Class" + classList[j] + secondPartXML + economicsList[j + 1] + thirdPartXML + iconString + fourthPartXML + courseDesc1String + fifthPartXML + courseName1String + sixthPartXML + courseDesc2String + seventhPartXML + courseName2String + eighthPartXML;
                                        break;
                                    case 8:
                                        finalString = firstPartXML + fineArtsList[0] + "_Class" + classList[j] + secondPartXML + fineArtsList[j + 1] + thirdPartXML + iconString + fourthPartXML + courseDesc1String + fifthPartXML + courseName1String + sixthPartXML + courseDesc2String + seventhPartXML + courseName2String + eighthPartXML;
                                        break;
                                    case 9:
                                        finalString = firstPartXML + historyList[0] + "_Class" + classList[j] + secondPartXML + historyList[j + 1] + thirdPartXML + iconString + fourthPartXML + courseDesc1String + fifthPartXML + courseName1String + sixthPartXML + courseDesc2String + seventhPartXML + courseName2String + eighthPartXML;
                                        break;
                                    case 10:
                                        finalString = firstPartXML + languageAndLiteratureList[0] + "_Class" + classList[j] + secondPartXML + languageAndLiteratureList[j + 1] + thirdPartXML + iconString + fourthPartXML + courseDesc1String + fifthPartXML + courseName1String + sixthPartXML + courseDesc2String + seventhPartXML + courseName2String + eighthPartXML;
                                        break;
                                    case 11:
                                        finalString = firstPartXML + physicsList[0] + "_Class" + classList[j] + secondPartXML + physicsList[j + 1] + thirdPartXML + iconString + fourthPartXML + courseDesc1String + fifthPartXML + courseName1String + sixthPartXML + courseDesc2String + seventhPartXML + courseName2String + eighthPartXML;
                                        break;
                                    case 12:
                                        finalString = firstPartXML + psychologyList[0] + "_Class" + classList[j] + secondPartXML + psychologyList[j + 1] + thirdPartXML + iconString + fourthPartXML + courseDesc1String + fifthPartXML + courseName1String + sixthPartXML + courseDesc2String + seventhPartXML + courseName2String + eighthPartXML;
                                        break;
                                    case 13:
                                        finalString = firstPartXML + villainyList[0] + "_Class" + classList[j] + secondPartXML + villainyList[j + 1] + thirdPartXML + iconString + fourthPartXML + courseDesc1String + fifthPartXML + courseName1String + sixthPartXML + courseDesc2String + seventhPartXML + courseName2String + eighthPartXML;
                                        break;
                                }
                                File.WriteAllText(fileName, finalString);
                            }
                        }
                        
                    }
                }
            }
            MessageBox.Show("Ready!/r/nYou can close the program and import files.");
        }
    }
}
