using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;

namespace TestXML_inout
{

    public partial class Form1 : Form
    {
        public static List<Command> actionList;
        public Form1()
        {
            InitializeComponent();
            LoadCommands();

        }

        // Load commands from XML file into a List
        public void LoadCommands()
        {
            //XmlReader reader = XmlReader.Create("./Profiles/Default.xml");
            actionList = (
                from e in XDocument.Load("./Profiles/Default.xml").Root.Elements("Command")
                select new Command
                {
                    CommandID = (string)e.Element("CommandID"),
                    CommandString = (string)e.Element("CommandString"),
                    ActionSequence = (
                        from A in e.Elements("ActionSequence").Elements("CommandAction")
                        select new CommandAction
                        {
                            ActionID = (string)A.Element("ActionID"),
                            ActionType = (string)A.Element("ActionType"),
                            Duration = (int)A.Element("Duration"),
                            Delay = (int)A.Element("Delay"),
                            KeyCodes = (string)A.Element("KeyCodes"),
                            Context = (string)A.Element("Context")
                        })
                        .ToArray()

                })
                .ToList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show(actionList.ToString());
            foreach (var Command in actionList)
            {
                //richTextBox1.Text += Environment.NewLine + Command.CommandString;
                richTextBox1.AppendText(Environment.NewLine + Command.CommandString);

            }
        }



    }


}
