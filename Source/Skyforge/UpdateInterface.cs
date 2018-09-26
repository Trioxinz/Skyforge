using System;
using System.Reflection;
using System.Drawing;
using System.Windows.Forms;

namespace SkyforgeReforge
{
    // The interface that all applications need to implement in order to use the update interface
    public interface UpdateInterface
    {
        // The name of your application as you want displayed in the update form
        string ApplicationName { get; }

        // An identifier string views to identify your application in the update.XML
        // should be the same as your appID in the update.XML
        string ApplicationID { get; }

        // The current assembly
        Assembly ApplicationAssembly { get; }

        // The current application's icon to be displayed in the top left
        Icon ApplictionIcon { get; }

        // The location of the update.XML on the server
        Uri UpdateXMLLocation { get; }

        // The context of the program
        // For Windows forms applications, use 'this'
        // Console apps, reference System.Windows.Forms and return null
        Form Contex { get; }
    }
}
