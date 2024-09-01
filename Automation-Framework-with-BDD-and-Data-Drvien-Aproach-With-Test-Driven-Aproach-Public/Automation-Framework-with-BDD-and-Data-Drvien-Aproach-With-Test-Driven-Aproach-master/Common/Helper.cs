using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dependency_Verification.Driver;
namespace Dependency_Verification.Common
{
    internal class Helper
    {
        Drivers driver = new Drivers();

        public void dynamite(string validator, string module)
        {
            String Xpath = "";
            //"{\"batchId\":\""+batch_id+"\"}"
            //String Xpath = "//*[@id='treeview']//ul[@class='k-group k-treeview-lines']//li[@data-uid=\'"+data_UID+"\']//child::span[1]";
            //String Xpath = "//*[@id='treeview']//ul[@class='k-group k-treeview-lines']//li[@data-uid=\'"+data_UID+"\']/div/child::span[1]";

            if (validator == "clicking")
            {
                Xpath = "//*[@id='treeview']//ul[@class='k-group k-treeview-lines']//input[@title=\'" + module + "\']//ancestor::span[1]//preceding::span[1]";

            }
            else if (validator == "selecting")
            {
                Xpath = "//*[@id='treeview']//ul[@class='k-group k-treeview-lines']//input[@title=\'" + module + "\']//ancestor::span[1]";
            }
            else
            {
                throw new Exception("Invalid Spec, Validator should be either clicking or selecting " + validator);

            }
            driver.btn(Xpath);
        }

    }
}
