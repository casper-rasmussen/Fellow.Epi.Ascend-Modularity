using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Framework.Blobs;
using EPiServer.Framework.DataAnnotations;
using Valtech.Sandbox.Core.Models.Interfaces.Media;

namespace Valtech.Sandbox.Core.Implementation.Models.Media
{
    [AdministrationSettings(
       CodeOnly = true,
       GroupName = CoreGroupNames.MediaTypeGroupName)]
    [ContentType(
        DisplayName = "Image",
        GUID = "97DF969D-EA8F-4F61-8298-A8B767C85729",
        GroupName = CoreGroupNames.MediaTypeGroupName,
        Order = 20)]
    [MediaDescriptor(ExtensionString = "jpg,jpeg,jpe,ico,gif,bmp,png")]
    public class ImageFileMediaType : ImageData, IImage
    {
    }
}
