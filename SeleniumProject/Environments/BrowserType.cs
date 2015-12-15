using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.Environments
{
    public enum BrowserType
    {
        [Description("IE")]
        IE = 0,
        [Description("Chrome")]
        Chrome = 1,
        [Description("NodeWebkit")]
        NodeWebkit = 2,
        [Description("GridChrome")]
        GridChrome = 3,
        [Description("GridIE")]
        GridIE = 4,
        

    }
}