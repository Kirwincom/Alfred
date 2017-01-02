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
            MessageBox.Show(actionList.ToString());
            foreach (var Command in actionList)
            {
                richTextBox1.Text += Command.CommandString;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.Text =  actionList.Count.ToString();
            foreach (var Command in actionList)
            {
                richTextBox1.Text += Command.CommandString;
            }
        }



    }
    ///
    /// Define the classes to be use
    /// 
    // Data structure
    // <ActionSequence>
    //    <CommandAction>
    //       <ActionID>1</ActionId>
    //       <ActionType>Say</ActionType>
    //       <Duration>0</Duration>
    //       <Delay>0</Delay>
    //       <KeyCodes />
    //       <Context>Engaging turbo</Context>
    //    </CommandAction>
    // </ActionSequence>
    //

    public class CommandAction
    {
        public string ActionID { get; set; }
        public string ActionType { get; set; }    //default this value to Say
        public int Duration { get; set; }
        public int Delay { get; set; }
        public string KeyCodes { get; set; }
        public string Context { get; set; }
    }
    public class Command
    {
        public string CommandID { get; set; }
        public string CommandString { get; set; }
        public CommandAction[] ActionSequence { get; set; }

    }
}
