using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class OutputFormHandler
    {
        public void Update()
        {
            var handler = new ConnectionHandler();
            var table = handler.DownloadFromServer();
            //table.DefaultView.RowFilter = filterString();
            string filter = "";
        }
    }
}
