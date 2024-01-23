using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sdms_connector
{
    public partial class ParsingView : Form
    {
        public ParsingView(string url)
        {
            InitializeComponent();

            wbParsing.Navigate(url);
        }
    }
}
