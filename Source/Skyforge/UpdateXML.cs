using System;
using System.Net;
using System.Xml;

namespace SkyforgeReforge
{
    // Contains of the information
    internal class UpdateXML
    {
        private Version version;
        private Uri uri;
        private string fileName;
        private string md5;
        private string sha512;
        private string description;
        private string launchArgs;

        // The update version number
        internal Version Version
        {
            get { return this.version;  }
        }

        // The location of the update binary
        internal Uri Uri
        {
            get { return this.uri; }
        }

        // The file name of the binary for use on the local computer
        internal string FileName
        {
            get { return this.fileName; }
        }

        //The MD5 of the updates binary
        internal string MD5
        {
            get { return this.md5; }
        }

        //The SHA512 of the updates binary
        internal string SHA512
        {
            get { return this.sha512; }
        }

        // The update's description
        internal string Description
        {
            get { return this.description; }
        }

        // The arguments to pass to the updated application on startup
        internal string LaunchArgs
        {
            get { return this.launchArgs; }
        }
        
        // creates a new UpdateXML object
        internal UpdateXML(Version version, Uri uri, string fileName, string md5, string sha512, string description, string launchArgs)
        {
            this.version = version;
            this.uri = uri;
            this.fileName = fileName;
            this.md5 = md5;
            this.sha512 = sha512;
            this.description = description;
            this.launchArgs = launchArgs;
        }

        // Checks if updates version is newer than the local computers version
        internal bool IsNewerThan(Version version)
        {
            return this.version > version;
        }

        // Checks the Uri to make sure the file exists
        internal static bool ExistsOnServer(Uri location)
        {
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(location.AbsoluteUri);
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                resp.Close();

                return resp.StatusCode == HttpStatusCode.OK;
            }
            catch
            {
                return false;
            }
        }

        // Parses the update.XML into UpdateXML object
        internal static UpdateXML Parse(Uri location, string appID)
        {
            Version version = null;
            string url = "", fileName = "", md5 = "", sha512= "", description = "", launchArgs = "";
            try
            {
                // Load the document
                XmlDocument doc = new XmlDocument();
                doc.Load(location.AbsoluteUri);

                // Gets the appID's node with the update info
                // This allows you to store all your program's update nodes in one file
                XmlNode node = doc.DocumentElement.SelectSingleNode("//update [@appId='" + appID + "']");

                // If the node doesn't exist, there is no update
                if (node == null)
                {
                    return null;
                }

                // Parse data
                version = Version.Parse(node["version"].InnerText);
                url = node["url"].InnerText;
                fileName = node["fileName"].InnerText;
                md5 = node["md5"].InnerText;
                sha512 = node["sha512"].InnerText;
                description = node["description"].InnerText;
                launchArgs = node["launchArgs"].InnerText;

                return new UpdateXML(version, new Uri(url), fileName, md5, sha512, description, launchArgs);
            }
            catch
            {
                return null;
            }
        }
    }
}
