using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scrprnt
{
    internal class JiraIssue
    {
        public List<JiraAttachment> Attachments { get; set; }

        public Fields Fields { get; set; }


    }

}
