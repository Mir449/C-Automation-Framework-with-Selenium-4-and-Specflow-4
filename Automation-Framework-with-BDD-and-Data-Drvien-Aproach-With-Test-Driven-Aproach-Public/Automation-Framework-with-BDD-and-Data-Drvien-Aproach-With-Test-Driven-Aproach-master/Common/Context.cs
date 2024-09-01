using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Renci.SshNet;
using Renci.SshNet.Common;

namespace Dependency_Verification.Common
{
    internal class Context
    {
        static HttpClient client;
        static SshClient sshClient;
        public Context() { 
        client = new HttpClient();
        }


        public void connectssh() {

            sshClient = new SshClient(System.Configuration.ConfigurationManager.AppSettings["CoreIP"], System.Configuration.ConfigurationManager.AppSettings["CoreUser"], System.Configuration.ConfigurationManager.AppSettings["CorePwd"]);
            sshClient.Connect();
            var command = sshClient.CreateCommand("bash --login -c 'cd Core;p2r p2_a_p2p 23153631236'");
            //     var command2 = sshClient.RunCommand("cd Core;p2r p2_a_p2p 23153631236");

            //  var rslt = command.BeginExecute();

           var rslt= command.Execute();
         /* try
            {
                IAsyncResult asyncResult = command.BeginExecute(null, null);
                bool completed = asyncResult.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(10)); // Set a timeout of 10 seconds
                if (completed)
                {
                    string result = command.EndExecute(asyncResult);
                    // Process the result
                }

            }
            catch(Exception ex)
            {

            }*/
            /*using (var reader = new StreamReader(command.OutputStream))
            {

                // Read the command output in a loop
                while (!result.IsCompleted || !reader.EndOfStream)
                {
                    // Read a line from the output
                    System.Diagnostics.Debug.WriteLine("valure");
                        string line = reader.ReadLine();
                    // Process the line as desired (e.g., print it)
                    System.Diagnostics.Debug.WriteLine(line);
                }
            }

            command.EndExecute(result);
*/
            sshClient.Disconnect();

        }

        public void baseurl(string url) { 
        client.BaseAddress = new Uri(url);
        }

        public void requestheaders()
        {

        }
    }
}
