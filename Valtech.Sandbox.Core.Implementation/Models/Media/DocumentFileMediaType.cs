using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web;
using Valtech.Sandbox.Core.Models.Interfaces.Media;

namespace Valtech.Sandbox.Core.Implementation.Models.Media
{
    [AdministrationSettings(
        CodeOnly = true,
        GroupName = CoreGroupNames.MediaTypeGroupName)]
    [ContentType(
        DisplayName = "Document",
        GUID = "C40D2723-DEF5-4F6C-A93C-3723C63099C9",
        GroupName = CoreGroupNames.MediaTypeGroupName,
        Order = 20)]
    [MediaDescriptor(ExtensionString = "pdf")]
    public class DocumentFileMediaType : MediaData, IDocument
    {   
        
    }
}
