using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WhiteBoard.Model
{
    public class Sketch
    {
        public int Id { get; set; }
        public string ProjectLink { get; set; }
        public DateTime DateCreated { get; set; }
        public string ProjectName { get; set; }
    }
}
