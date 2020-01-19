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
using System.Xml.Serialization;

namespace InventoryForm
{
    public partial class Form1 : Form
    {
        XmlSerializer xs;
        List<Item> listItem;
        string xmlFile = string.Format("{0}/Data/{1}", Path.GetDirectoryName(Application.ExecutablePath), "item.xml");
        public Form1()
        {
            InitializeComponent();
            listItem = new List<Item>();
            xs = new XmlSerializer(typeof(List<Item>));
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(xmlFile, FileMode.Create, FileAccess.Write);
            Item item = new Item();
            item.Name = nameTextBox.Text;
            item.Producer = nameTextBox.Text;
            item.Quanity = int.Parse(quantityTextBox.Text);

            listItem.Add(item);
            xs.Serialize(fs, listItem);
            fs.Close(); 
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(xmlFile, FileMode.Open, FileAccess.Read);
            listItem = (List<Item>)xs.Deserialize(fs);

            itemDataGridView.DataSource = listItem;
            fs.Close();
        }
    }
}
